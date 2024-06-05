using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.UseCases.Mensaje;
using YateMate.Aplicacion.UseCases.ApplicationUser;

namespace YateMate.Components.Pages.Chat;

public partial class Chat
{
    [CascadingParameter] public HubConnection hubConnection { get; set; }
    [Parameter] public string CurrentMessage { get; set; }

    [Parameter]
    public ApplicationUser CurrentUser { get; set; }
    [Parameter] public string CurrentUserId { get; set; }
    
    private List<MensajeChat> messages = new();
    
    [Inject]
    AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    
    [Inject] private AgregarMensajeUseCase AgregarMensajeUseCase { get; set; }
    [Inject] private ObtenerContactosDeUseCase ObtenerContactosDeUseCase { get; set; }
    [Inject] private ObtenerApplicationUserUseCase ObtenerApplicationUserUseCase { get; set; }
    [Inject] private ObtenerMensajesEntreUseCase ObtenerMensajesEntreUseCase { get; set; }
    
    [Inject] private NavigationManager NavigationManager { get; set; }

    [Inject] private IJSRuntime _jsRuntime { get; set; }
    
    public List<ApplicationUser> ChatUsers = new List<ApplicationUser>();
    [Parameter] public string ContactId { get; set; }
    
    [Parameter] public ApplicationUser Contacto { get; set; }

    private string img = "";

    private bool _isImgTooBig;
    
    [CascadingParameter]
    private Task<AuthenticationState>? AuthenticationState { get; set; } 
    
    public async Task Enter(KeyboardEventArgs e)
    {
        if (e.Code == "Enter" || e.Code == "NumpadEnter")
        {
            await SubmitAsync();
        }
        
    }
    private async Task SubmitAsync()
    {
        if (!string.IsNullOrEmpty(img)) 
            CurrentMessage = img;
        
        if (!string.IsNullOrEmpty(CurrentMessage) && !string.IsNullOrEmpty(ContactId))
        {
            var chatHistory = new MensajeChat()
            {
                Message = CurrentMessage,
                ToUserId = ContactId,
                CreatedDate = DateTime.Now,
                FromUserId = CurrentUserId,
                IsImage = !string.IsNullOrEmpty(img)
            };
            AgregarMensajeUseCase.Ejecutar(chatHistory);
            
            await hubConnection.SendAsync(Constants.SignalRConstants.SendMessage, chatHistory, CurrentUser.Email);
            Console.WriteLine($"{CurrentUser.Email} Enviando mensaje a {ContactId}");

            CurrentMessage = string.Empty;
            img = string.Empty;
        }
    }
    protected override async Task OnInitializedAsync()
    {
        //lo pongo aca porq adentro de loadUserChat se carga despues del rendereo de la pagina y me explota todo
        if (!string.IsNullOrEmpty(ContactId)) Contacto = ObtenerApplicationUserUseCase.Ejecutar(ContactId); 
        if (hubConnection == null) 
        {
            hubConnection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri(Constants.SignalRConstants.HubPath)).Build();
        }
        if (hubConnection.State == HubConnectionState.Disconnected)
        {
            await hubConnection.StartAsync();
        }
        hubConnection.On<MensajeChat, string>(Constants.SignalRConstants.ReceiveMessage, async (message, userName) =>
        {
            if ((ContactId == message.ToUserId && CurrentUserId == message.FromUserId) || (ContactId == message.FromUserId && CurrentUserId == message.ToUserId))
            {
        
                if ((ContactId == message.ToUserId && CurrentUserId == message.FromUserId)) //si lo envie yo
                {
                    messages.Add(new MensajeChat { Message = message.Message, CreatedDate = message.CreatedDate, IsImage = message.IsImage, FromUser = CurrentUser } );
                }
                else if ((ContactId == message.FromUserId && CurrentUserId == message.ToUserId))
                {
                    messages.Add(new MensajeChat { Message = message.Message, CreatedDate = message.CreatedDate, IsImage = message.IsImage, FromUser = Contacto });
                }
                Console.WriteLine($"se recibio un mensaje, mail actual es {CurrentUser.Email}");
                await InvokeAsync(StateHasChanged);
            }
        }); 
        
        // Console.WriteLine("consegui contactos"); //se ejecuta
        
        if (AuthenticationState is not null)
        {
            var authState = await AuthenticationState;
            var user = authState.User;
            CurrentUserId = user.Claims.FirstOrDefault()?.Value!;
            CurrentUser = ObtenerApplicationUserUseCase.Ejecutar(CurrentUserId)!;
            
        }
        Console.WriteLine($"mail usuario actual {CurrentUser.Email} Id usuario actual {CurrentUserId}'");
        
        GetContactos();
        
        if (!string.IsNullOrEmpty(ContactId))
        {
            LoadUserChat(ContactId);
        }
    }
    
    void LoadUserChat(string userId)
    {
        ContactId = Contacto.Id;
        messages = ObtenerMensajesEntreUseCase.Ejecutar(userId, CurrentUserId);
        Console.WriteLine($"Loaded user chat {Contacto.Email}");
    }
    private void GetContactos()
    {
        ChatUsers = ObtenerContactosDeUseCase.Ejecutar(CurrentUserId);
        // Console.WriteLine(ChatUsers.Count);
    }
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await _jsRuntime.InvokeAsync<string>("ScrollToBottom", "chatContainer");
    }

    private async Task saveImage(IBrowserFile file)
    {
        
        if (file.Size > Constants.SignalRConstants.MaximumMessageSize)
        {
            Console.WriteLine($"Usuario mando mensaje mayor al maximo. Bytes: {file.Size}");
            img = "";
            CurrentMessage = "";
            _isImgTooBig = true;
            return;

        }
        var buffer = new byte[file.Size];
        var reader = file.OpenReadStream(long.MaxValue);
        await reader.ReadExactlyAsync(buffer);
        var imagesrc = Convert.ToBase64String(buffer);
        reader.Close();
        img = $"data:{file.ContentType};base64,{imagesrc}";
        _isImgTooBig = false;
        CurrentMessage = "Imagen seleccionada";
    }
}
