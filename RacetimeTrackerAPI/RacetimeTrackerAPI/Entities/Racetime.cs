using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RacetimeTrackerAPI.Entities;

[Table("racetime")]
public partial class Racetime
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("date", TypeName = "datetime")]
    public DateTime Date { get; set; }

    [Column("userId")]
    public int UserId { get; set; }

    [Column("groupId")]
    public int GroupId { get; set; }

    [Column("trackId")]
    public int TrackId { get; set; }

    [Column("carClass")]
    [StringLength(1)]
    [Unicode(false)]
    public string CarClass { get; set; } = null!;

    [ForeignKey("GroupId")]
    [InverseProperty("Racetimes")]
    public virtual Group Group { get; set; } = null!;

    [ForeignKey("TrackId")]
    [InverseProperty("Racetimes")]
    public virtual Track Track { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Racetimes")]
    public virtual User User { get; set; } = null!;
}
