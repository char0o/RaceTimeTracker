using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RacetimeTrackerAPI.Entities;
using Racetime = RacetimeTrackerAPI.Entities.Racetime;
using Track = RacetimeTrackerAPI.Entities.Track;
using Trackvariant = RacetimeTrackerAPI.Entities.Trackvariant;
using User = RacetimeTrackerAPI.Entities.User;
using Usergroup = RacetimeTrackerAPI.Entities.Usergroup;


namespace RacetimeTrackerAPI.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Entities.Group> Groups { get; set; }

    public virtual DbSet<Entities.Racetime> Racetimes { get; set; }

    public virtual DbSet<Entities.Track> Tracks { get; set; }

    public virtual DbSet<Entities.Trackvariant> Trackvariants { get; set; }

    public virtual DbSet<Entities.User> Users { get; set; }

    public virtual DbSet<Entities.Usergroup> Usergroups { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__group__3213E83FEF5F06B6");
        });

        modelBuilder.Entity<Entities.Racetime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__racetime__3213E83FB4CF0EE6");

            entity.Property(e => e.CarClass).IsFixedLength();

            entity.HasOne(d => d.Group).WithMany(p => p.Racetimes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupId");

            entity.HasOne(d => d.Track).WithMany(p => p.Racetimes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrackId");

            entity.HasOne(d => d.User).WithMany(p => p.Racetimes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserId");
        });

        modelBuilder.Entity<Entities.Track>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__track__3213E83F0E27A03B");

            entity.HasOne(d => d.Variant).WithMany(p => p.Tracks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrackVariant");
        });

        modelBuilder.Entity<Trackvariant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__trackvar__3213E83FD11A170F");
        });

        modelBuilder.Entity<Entities.User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user__3213E83F8A9B27DA");
        });

        modelBuilder.Entity<Entities.Usergroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usergrou__3213E83FA303E2F1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
