using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Manager;

public class ChatManager : IChatManager
{
    private readonly HttpClient _httpClient;

    public ChatManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<MensajeChat>> GetConversationAsync(string contactId)
    {
        return await _httpClient.GetFromJsonAsync<List<MensajeChat>>($"api/chat/{contactId}");
    }
    public async Task<ApplicationUser> GetUserDetailsAsync(string userId)
    {
        return await _httpClient.GetFromJsonAsync<ApplicationUser>($"api/chat/users/{userId}");
    }
    public async Task<List<ApplicationUser>> GetUsersAsync()
    {
        var data = await _httpClient.GetFromJsonAsync<List<ApplicationUser>>("api/chat/users");
        return data;
    }
    public async Task SaveMessageAsync(MensajeChat message)
    {
        await _httpClient.PostAsJsonAsync("api/chat", message);
    }
}