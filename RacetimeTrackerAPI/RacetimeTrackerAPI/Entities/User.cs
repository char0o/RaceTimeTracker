using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RacetimeTrackerAPI.Entities;

[Table("user")]
public partial class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("passwordHash")]
    [StringLength(255)]
    [Unicode(false)]
    public string PasswordHash { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Racetime> Racetimes { get; set; } = new List<Racetime>();

    public User()
    {
        
    }
    
    public User(DTOs.User dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        this.PasswordHash = dto.PasswordHash;
    }
        
    public DTOs.User ToDTO()
    {
        return new DTOs.User(Id, Name, this.PasswordHash);
    }
}
