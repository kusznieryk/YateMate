using Microsoft.AspNetCore.SignalR;
using YateMate.Aplicacion.Entidades;

namespace YateMate.Hubs;

public class SignalRHub : Hub
{
    public async Task SendMessageAsync(MensajeChat message, string userName)
    {
        await Clients.All.SendAsync(Constants.SignalRConstants.ReceiveMessage, message, userName);
    }
    
    public void SendMessageTo(MensajeChat message, string userNameFrom, string userIdTo)
    {
        Clients.User(userIdTo).SendAsync(Constants.SignalRConstants.ReceiveMessage, message, userNameFrom);
    }
}