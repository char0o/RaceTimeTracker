using System.Net.Http;
using System.Text;
using System.Text.Json;
using RacetimeTrackerClient.Model;

namespace RacetimeTrackerClient.Services;

public class LoginService
{
    private readonly HttpClient _httpClient;

    public LoginService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> Login(User user)
    {
        string content = JsonSerializer.Serialize(user);
        HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "api/Connect", httpContent);

        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        
        return true;
    }
}