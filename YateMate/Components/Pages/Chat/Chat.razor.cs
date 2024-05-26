using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.SignalR.Client;
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
    
    [Inject] //no se puede hacer @inject aca
    AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    
    [Inject] private AgregarMensajeUseCase AgregarMensajeUseCase { get; set; }
    [Inject] private ObtenerContactosDeUseCase ObtenerContactosDeUseCase { get; set; }
    [Inject] private ObtenerApplicationUserUseCase ObtenerApplicationUserUseCase { get; set; }
    [Inject] private ObtenerMensajesEntreUseCase ObtenerMensajesEntreUseCase { get; set; }
    
    [Inject] private NavigationManager NavigationManager { get; set; }
    
    public List<ApplicationUser> ChatUsers = new List<ApplicationUser>();
    [Parameter] public string ContactEmail { get; set; }
    [Parameter] public string ContactId { get; set; }
    
    [CascadingParameter]
    private Task<AuthenticationState>? AuthenticationState { get; set; } 
    
    private async Task SubmitAsync()
    {
        Console.WriteLine($"{CurrentUserEmail} Enviando mensaje a {ContactId}");
        
        if (!string.IsNullOrEmpty(CurrentMessage) && !string.IsNullOrEmpty(ContactId))
        {
            var chatHistory = new MensajeChat()
            {
                Message = CurrentMessage,
                ToUserId = ContactId,
                CreatedDate = DateTime.Now,
                FromUserId = CurrentUserId
            };
            AgregarMensajeUseCase.Ejecutar(chatHistory);
            
            await hubConnection.SendAsync("SendMessageAsync", chatHistory, CurrentUserEmail);
            CurrentMessage = string.Empty;
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
                    messages.Add(new MensajeChat { Message = message.Message, CreatedDate = message.CreatedDate, FromUser = new ApplicationUser() { Email = CurrentUserEmail } } );
                    // await hubConnection.SendAsync("ChatNotificationAsync", $"New Message From {userName}", ContactId, CurrentUserId);
                }
                else if ((ContactId == message.FromUserId && CurrentUserId == message.ToUserId))
                {
                    messages.Add(new MensajeChat { Message = message.Message, CreatedDate = message.CreatedDate, FromUser = new ApplicationUser() { Email = ContactEmail } });
                }
                await InvokeAsync(StateHasChanged);
            }
        }); 
        
        // Console.WriteLine("consegiu contactos"); //se ejecuta
        
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
}

//