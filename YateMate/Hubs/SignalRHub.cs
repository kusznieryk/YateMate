using Microsoft.AspNetCore.SignalR;
using YateMate.Aplicacion.Entidades;

namespace YateMate.Hubs;

public class SignalRHub : Hub
{
    public async Task SendMessageAsync(MensajeChat message, string userName)
    {
        await Clients.All.SendAsync("ReceiveMessage", message, userName);
    }
    
    public void SendMessageTo(MensajeChat message, string userNameFrom, string userIdTo)
    {
        Clients.User(userIdTo).SendAsync("ReceiveMessage", message, userNameFrom);
    }
}