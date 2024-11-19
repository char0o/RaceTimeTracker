using System.Collections;
using System.Net.Http;
using System.Text.Json;
using RacetimeTrackerClient.Model;

namespace RacetimeTrackerClient.Services;

public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("api/user");
        
        response.EnsureSuccessStatusCode();
        
        string jsonResponse = await response.Content.ReadAsStringAsync();
        
        List<User>? users = JsonSerializer.Deserialize<List<User>>(jsonResponse);
        
        return users ?? new List<User>();
    }
}