using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirstAPI.Models;

public partial class DiscografiaContext : DbContext
{
    public DiscografiaContext()
    {
    }

    public DiscografiaContext(DbContextOptions<DiscografiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Artista> Artistas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectioString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.AlbumId).HasName("PK__album__97B4BE173F990062");

            entity.ToTable("album");

            entity.Property(e => e.AlbumId).HasColumnName("AlbumID");
            entity.Property(e => e.ArtistaId).HasColumnName("ArtistaID");
            entity.Property(e => e.Lanzamiento).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Artista).WithMany(p => p.Albums)
                .HasForeignKey(d => d.ArtistaId)
                .HasConstraintName("FK__album__ArtistaID__398D8EEE");
        });

        modelBuilder.Entity<Artista>(entity =>
        {
            entity.HasKey(e => e.ArtistaId).HasName("PK__artista__1DC48275BA0E0327");

            entity.ToTable("artista");

            entity.Property(e => e.ArtistaId).HasColumnName("ArtistaID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
