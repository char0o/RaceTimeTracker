using System.Text.Json.Serialization;

namespace RacetimeTrackerClient.Model;

public class User
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }

    public User(string name, string password)
    {
        Name = name;
        Password = password;
    }
}