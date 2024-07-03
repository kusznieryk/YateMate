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
            $"http://127.0.0.1:1880/duenioinhabilitado/");
        
        request.Headers.Add("Dni", $"{dni}");
        
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine("duenio" + responseBody);
        return JsonSerializer.Deserialize<bool>(responseBody);
    }

    public async Task<bool> EstaBienInhabilitado(string identificador)
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://127.0.0.1:1880/bieninhibido/");
        
        request.Headers.Add("identificador", $"{identificador}");
        
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Bien" + responseBody);
        return JsonSerializer.Deserialize<bool>(responseBody);
    }
    
    public async Task<bool> EsDuenioDe(int dni, string identificador)
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://127.0.0.1:1880/esduenio/");
        
        request.Headers.Add("Dni", $"{dni}");
        request.Headers.Add("identificador", $"{identificador}");
        
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine("duenio y bien" + responseBody);
        return JsonSerializer.Deserialize<bool>(responseBody);
    }
    
}