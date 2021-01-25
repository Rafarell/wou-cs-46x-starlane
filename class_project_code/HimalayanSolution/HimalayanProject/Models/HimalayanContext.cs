﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HimalayanProject.Models
{
    public partial class HimalayanContext : DbContext
    {
        public HimalayanContext()
        {
        }

        public HimalayanContext(DbContextOptions<HimalayanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Expedition> Expeditions { get; set; }
        public virtual DbSet<Peak> Peaks { get; set; }
        public virtual DbSet<TrekkingAgency> TrekkingAgencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=HimalayanDBConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Expedition>(entity =>
            {
                entity.HasOne(d => d.Peak)
                    .WithMany(p => p.Expeditions)
                    .HasForeignKey(d => d.PeakId)
                    .HasConstraintName("Expedition_FK_Peak");

                entity.HasOne(d => d.TrekkingAgency)
                    .WithMany(p => p.Expeditions)
                    .HasForeignKey(d => d.TrekkingAgencyId)
                    .HasConstraintName("Expedition_FK_TrekkingAgency");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
