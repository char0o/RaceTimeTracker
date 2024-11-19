using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RacetimeTrackerAPI.Controllers.Viewmodels;

public class UserVM
{
    public string Name { get; set; }
    public string Password { get; set; }

    [JsonConstructor]
    public UserVM(string name, string password)
    {
        Name = name;
        this.Password = password;
    }
    
    public UserVM(DTOs.User user)
    {
        Name = user.Name;
        this.Password = user.PasswordHash;
    }
    
    public DTOs.User ToDTO()
    {
        return new DTOs.User(0, this.Name, this.Password);
    }
}