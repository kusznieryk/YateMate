using System.Text.Json;

namespace YateMate.Aplicacion.Entidades;

public class ApiCaller
{
    private readonly HttpClient _httpClient;

    public ApiCaller(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<bool> EstaDuenioInhibido(int dni)
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            "http://127.0.0.1:1880/");
        
        request.Headers.Add("Dni", $"{dni}");
        
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<bool>(responseBody);
    }

    public async Task<bool> EstaBienInhabilitado(string identificador)
    {
        // var request = new HttpRequestMessage(HttpMethod.Get,
        //     "http://127.0.0.1:1880/");
        //
        // request.Headers.Add("identificador", $"{identificador}");
        //
        // var response = await _httpClient.SendAsync(request);
        // response.EnsureSuccessStatusCode();
        // var responseBody = await response.Content.ReadAsStringAsync();
        // return JsonSerializer.Deserialize<bool>(responseBody);
        return false;
    }
    
    public async Task<bool> EsDuenioDe(int dni, string identificador)
    {
        // var request = new HttpRequestMessage(HttpMethod.Get,
        //     "http://127.0.0.1:1880/");
        //
        // request.Headers.Add("identificador", $"{identificador}");
        //
        // var response = await _httpClient.SendAsync(request);
        // response.EnsureSuccessStatusCode();
        // var responseBody = await response.Content.ReadAsStringAsync();
        // return JsonSerializer.Deserialize<bool>(responseBody);
        return false;
    }
    
    public async Task<string> Prueba()
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            "https://jsonplaceholder.typicode.com/todos/1");
        
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;
    }
    
}