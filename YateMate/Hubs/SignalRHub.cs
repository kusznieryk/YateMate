using Microsoft.AspNetCore.SignalR;
using YateMate.Aplicacion.Entidades;

namespace YateMate.Hubs;

public class SignalRHub : Hub
{
    public async Task SendMessageAsync(MensajeChat message, string userName)
    {
        await Clients.All.SendAsync("ReceiveMessage", message, userName);
    }
    public async Task ChatNotificationAsync(string message, string receiverUserId, string senderUserId)
    {
        await Clients.All.SendAsync("ReceiveChatNotification", message, receiverUserId, senderUserId);
    }
}