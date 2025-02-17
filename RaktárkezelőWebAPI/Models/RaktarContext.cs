using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RaktárkezelőWebAPI.Models;

public partial class RaktarContext : DbContext
{
    public RaktarContext()
    {
    }

    public RaktarContext(DbContextOptions<RaktarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beszallito> Beszallitos { get; set; }

    public virtual DbSet<Termek> Termeks { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=raktar;user=root;password=;sslmode=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beszallito>(entity =>
        {
            entity.HasKey(e => e.BeszallitoId).HasName("PRIMARY");

            entity.ToTable("beszallito");

            entity.Property(e => e.BeszallitoId)
                .HasColumnType("int(11)")
                .HasColumnName("beszallitoId");
            entity.Property(e => e.Nev)
                .HasColumnType("text")
                .HasColumnName("nev");
        });

        modelBuilder.Entity<Termek>(entity =>
        {
            entity.HasKey(e => e.TermekId).HasName("PRIMARY");

            entity.ToTable("termek");

            entity.Property(e => e.TermekId)
                .HasColumnType("int(11)")
                .HasColumnName("termekId");
            entity.Property(e => e.Ar)
                .HasColumnType("int(11)")
                .HasColumnName("ar");
            entity.Property(e => e.BeszallitoId)
                .HasColumnType("int(11)")
                .HasColumnName("beszallitoId");
            entity.Property(e => e.Nev)
                .HasColumnType("text")
                .HasColumnName("nev");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
