using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
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
    [Parameter] public string CurrentUserId { get; set; }
    [Parameter] public string CurrentUserEmail { get; set; }
    private List<MensajeChat> messages = new List<MensajeChat>();
    
    [Inject]
    AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    
    [Inject] private AgregarMensajeUseCase AgregarMensajeUseCase { get; set; }
    [Inject] private ObtenerContactosDeUseCase ObtenerContactosDeUseCase { get; set; }
    [Inject] private ObtenerApplicationUserUseCase ObtenerApplicationUserUseCase { get; set; }
    [Inject] private ObtenerMensajesEntreUseCase ObtenerMensajesEntreUseCase { get; set; }
    
    [Inject] private NavigationManager NavigationManager { get; set; }

    [Inject] private IJSRuntime _jsRuntime { get; set; }
    
    public List<ApplicationUser> ChatUsers = new List<ApplicationUser>();
    [Parameter] public string ContactEmail { get; set; }
    [Parameter] public string ContactId { get; set; }
    [Parameter] public string ContactName { get; set; }

    private string img = "";
    
    [CascadingParameter]
    private Task<AuthenticationState>? AuthenticationState { get; set; } 
    
    private async Task SubmitAsync()
    {
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
            
            await hubConnection.SendAsync("SendMessageAsync", chatHistory, CurrentUserEmail);
            Console.WriteLine($"{CurrentUserEmail} Enviando mensaje a {ContactId}");

            CurrentMessage = string.Empty;
            img = string.Empty;
        }
    }
    protected override async Task OnInitializedAsync()
    {
        if (hubConnection == null)
        {
            hubConnection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri("/signalRHub")).Build();
        }
        if (hubConnection.State == HubConnectionState.Disconnected)
        {
            await hubConnection.StartAsync();
        }
        hubConnection.On<MensajeChat, string>("ReceiveMessage", async (message, userName) =>
        {
            if ((ContactId == message.ToUserId && CurrentUserId == message.FromUserId) || (ContactId == message.FromUserId && CurrentUserId == message.ToUserId))
            {
        
                if ((ContactId == message.ToUserId && CurrentUserId == message.FromUserId))
                {
                    messages.Add(new MensajeChat { Message = message.Message, CreatedDate = message.CreatedDate, IsImage = message.IsImage, FromUser = new ApplicationUser() { Email = CurrentUserEmail } } );
                }
                else if ((ContactId == message.FromUserId && CurrentUserId == message.ToUserId))
                {
                    messages.Add(new MensajeChat { Message = message.Message, CreatedDate = message.CreatedDate, IsImage = message.IsImage, FromUser = new ApplicationUser() { Email = ContactEmail } });
                }
                Console.WriteLine($"se recibio un mensaje, mail actual es {CurrentUserEmail}");
                await InvokeAsync(StateHasChanged);
            }
        }); 
        
        // Console.WriteLine("consegui contactos"); //se ejecuta
        
        if (AuthenticationState is not null)
        {
            var authState = await AuthenticationState;
            var user = authState.User;
            CurrentUserId = user.Claims.FirstOrDefault()?.Value!;
            CurrentUserEmail = user.Identity?.Name!;
        }
        Console.WriteLine($"mail usuario actual {CurrentUserEmail} Id usuario actual {CurrentUserId}'");
        
        GetContactos();
        
        if (!string.IsNullOrEmpty(ContactId))
        {
            LoadUserChat(ContactId);
        }
    }
    
    void LoadUserChat(string userId)
    {
        var contact = ObtenerApplicationUserUseCase.Ejecutar(userId);
        ContactId = contact.Id;
        ContactEmail = contact.Email;
        ContactName = contact.Nombre;
        // NavigationManager.NavigateTo($"chat/{ContactId}");
        messages = new List<MensajeChat>();
        messages = ObtenerMensajesEntreUseCase.Ejecutar(userId, CurrentUserId);
        Console.WriteLine($"Loaded user chat {contact.Email}");
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
        var buffer = new byte[file.Size];
        var reader = file.OpenReadStream(long.MaxValue);
        await reader.ReadExactlyAsync(buffer);
        var imagesrc = Convert.ToBase64String(buffer);
        reader.Close();
        img = $"data:{file.ContentType};base64,{imagesrc}";
        CurrentMessage = img;
        //await InvokeAsync(StateHasChanged); //ver si es necesario
    }
}

//