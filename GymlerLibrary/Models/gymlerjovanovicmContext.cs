// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GymlerLibrary.Models
{
    public partial class gymlerjovanovicmContext : DbContext
    {
        public gymlerjovanovicmContext()
        {
        }

        public gymlerjovanovicmContext(DbContextOptions<gymlerjovanovicmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FuehrtDurch> FuehrtDurch { get; set; }
        public virtual DbSet<NutzerIn> NutzerIn { get; set; }
        public virtual DbSet<Trainingsplan> Trainingsplan { get; set; }
        public virtual DbSet<Uebung> Uebung { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=gymlerjovanovicm;User Id=postgres;Password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuehrtDurch>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.UebungsId })
                    .HasName("fuehrt_durch_pkey");

                entity.ToTable("fuehrt_durch");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UebungsId).HasColumnName("uebungs_id");

                entity.Property(e => e.Gewichtkg).HasColumnName("gewichtkg");

                entity.Property(e => e.Saetze).HasColumnName("saetze");

                entity.Property(e => e.Wiederholunge).HasColumnName("wiederholunge");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.FuehrtDurch)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fuehrt_durch_id_fkey");

                entity.HasOne(d => d.Uebungs)
                    .WithMany(p => p.FuehrtDurch)
                    .HasForeignKey(d => d.UebungsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fuehrt_durch_uebungs_id_fkey");
            });

            modelBuilder.Entity<NutzerIn>(entity =>
            {
                entity.ToTable("nutzer_in");

                entity.HasIndex(e => e.Nutzername, "nutzer_in_nutzername_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nachname)
                    .HasMaxLength(20)
                    .HasColumnName("nachname");

                entity.Property(e => e.Nutzername)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("nutzername");

                entity.Property(e => e.Vorname)
                    .HasMaxLength(20)
                    .HasColumnName("vorname");
            });

            modelBuilder.Entity<Trainingsplan>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("trainingsplan_pkey");

                entity.ToTable("trainingsplan");

                entity.Property(e => e.PlanId).HasColumnName("plan_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Notiz)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("notiz");

                entity.Property(e => e.Titel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("titel");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Trainingsplan)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trainingsplan_id_fkey");

                entity.HasMany(d => d.Uebungs)
                    .WithMany(p => p.Plan)
                    .UsingEntity<Dictionary<string, object>>(
                        "Beinhaltet",
                        l => l.HasOne<Uebung>().WithMany().HasForeignKey("UebungsId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("beinhaltet_uebungs_id_fkey"),
                        r => r.HasOne<Trainingsplan>().WithMany().HasForeignKey("PlanId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("beinhaltet_plan_id_fkey"),
                        j =>
                        {
                            j.HasKey("PlanId", "UebungsId").HasName("beinhaltet_pkey");

                            j.ToTable("beinhaltet");

                            j.IndexerProperty<int>("PlanId").HasColumnName("plan_id");

                            j.IndexerProperty<int>("UebungsId").HasColumnName("uebungs_id");
                        });
            });

            modelBuilder.Entity<Uebung>(entity =>
            {
                entity.HasKey(e => e.UebungsId)
                    .HasName("uebung_pkey");

                entity.ToTable("uebung");

                entity.Property(e => e.UebungsId).HasColumnName("uebungs_id");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("bezeichnung");

                entity.Property(e => e.Durchfuehrungsbeschreibung)
                    .IsRequired()
                    .HasMaxLength(350)
                    .HasColumnName("durchfuehrungsbeschreibung");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}