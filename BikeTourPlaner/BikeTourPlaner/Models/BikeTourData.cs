using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BikeTourPlaner.Models;

public partial class BikeTourData : DbContext
{
    public BikeTourData()
    {
    }

    public BikeTourData(DbContextOptions<BikeTourData> options)
        : base(options)
    {
    }

    public virtual DbSet<Creditential> Creditentials { get; set; }

    public virtual DbSet<TourApply> TourApplies { get; set; }

    public virtual DbSet<TourPlan> TourPlans { get; set; }

    public virtual DbSet<TourResult> TourResults { get; set; }

    public virtual DbSet<Udatum> Udata { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Felhasznalo\\Documents\\BikeTour.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Creditential>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK__tmp_ms_x__C5B196627DE7D238");

            entity.Property(e => e.Uid).HasColumnName("UId");
            entity.Property(e => e.NickName)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Password).HasMaxLength(50);
        });


        modelBuilder.Entity<TourApply>(entity =>
        {
            entity.HasKey(e => e.Tid).HasName("PK__TourAppl__C456D7497BDD299D");

            entity.Property(e => e.Tid)
                .ValueGeneratedNever()
                .HasColumnName("TId");
            entity.Property(e => e.Uid).HasColumnName("UId");
        });

        modelBuilder.Entity<TourPlan>(entity =>
        {
            entity.HasKey(e => e.Tid).HasName("PK__TourPlan__C456D749A836D3FE");

            entity.ToTable("TourPlan");

            entity.Property(e => e.Tid).HasColumnName("TId");
            entity.Property(e => e.TourName)
                .ValueGeneratedNever()
                .HasMaxLength(50);
            entity.Property(e => e.PlannedDistance).HasDefaultValueSql("((1))");
            entity.Property(e => e.TourDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TourResult>(entity =>
        {
            entity.HasKey(e => e.Tid).HasName("PK__TourResu__C456D749A528E5D6");

            entity.ToTable("TourResult");

            entity.Property(e => e.Tid)
                .ValueGeneratedNever()
                .HasColumnName("TId");
            entity.Property(e => e.Accident).HasDefaultValueSql("((0))");
            entity.Property(e => e.Kcalories).HasColumnName("KCalories");
            entity.Property(e => e.Uid).HasColumnName("UId");
        });

        modelBuilder.Entity<Udatum>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK__tmp_ms_x__C5B196627161C5AA");

            entity.ToTable("UData");

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("UId");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
