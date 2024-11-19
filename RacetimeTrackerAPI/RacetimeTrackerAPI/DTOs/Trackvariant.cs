using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RacetimeTrackerAPI.DTOs;

[Table("trackvariant")]
public partial class Trackvariant
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Variant")]
    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
