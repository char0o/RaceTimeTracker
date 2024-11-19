using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RacetimeTrackerAPI.DTOs;

[Table("track")]
public partial class Track
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("variantId")]
    public int VariantId { get; set; }

    [InverseProperty("Track")]
    public virtual ICollection<Racetime> Racetimes { get; set; } = new List<Racetime>();

    [ForeignKey("VariantId")]
    [InverseProperty("Tracks")]
    public virtual Trackvariant Variant { get; set; } = null!;
}
