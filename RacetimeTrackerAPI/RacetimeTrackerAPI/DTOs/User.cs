using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RacetimeTrackerAPI.DTOs;

[Table("user")]
public partial class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Racetime> Racetimes { get; set; } = new List<Racetime>();

    public User(int id, string name, string passwordHash)
    {
        Id = id;
        Name = name;
        this.PasswordHash = passwordHash;
    }



    public DTOs.User ToDTO()
    {
        return new DTOs.User(Id, Name, this.PasswordHash);
    }
}
