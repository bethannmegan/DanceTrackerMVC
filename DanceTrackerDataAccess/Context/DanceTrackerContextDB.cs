using DanceTrackerDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceTrackerDataAccess.Context
{
    public partial class DanceTrackerContextDB : DbContext
    {
        public DanceTrackerContextDB(DbContextOptions options) : base(options)
        {
        }

        public DanceTrackerContextDB()
        {
        }

        public virtual DbSet<Events> Events {get; set;}
        public virtual DbSet<Comps> Comps { get; set; }

        public virtual DbSet<LessonsWorkshops> LessonsWorkshops { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Events>(
                entity =>
                {
                    entity.HasKey(e => e.EventId);
                    entity.Property(e => e.EventId).HasColumnName("EventId");
                    entity.Property(e => e.EventDate)
                    .IsRequired()
                    .HasMaxLength(50);
                    entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(255);
                    entity.Property(e => e.EventLocation)
                    .IsRequired()
                    .HasMaxLength(255);
                    entity.Property(e => e.Competitions)
                    .IsRequired().HasMaxLength(255);
                    entity.Property(e => e.LessonsAndWorkshops)
                    .IsRequired()
                    .HasMaxLength(255);
                }
                );

            modelBuilder.Entity<Comps>(
                entity =>
                {
                    entity.HasKey(e => e.EventId);
                    entity.Property(e => e.EventId).HasColumnName("EventId");
                    entity.Property(e => e.EventDate)
                    .IsRequired()
                    .HasMaxLength(50);
                    entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(255);
                    entity.Property(e => e.Competitions)
                    .IsRequired()
                    .HasMaxLength(255);
                    entity.Property(e => e.Division)
                    .IsRequired().HasMaxLength(50);
                    entity.Property(e => e.DancePartners)
                    .IsRequired()
                    .HasMaxLength(255);
                    entity.Property(e => e.Results)
                    .IsRequired()
                    .HasMaxLength(50);
                    entity.Property(e => e.Videos)
                    .IsRequired();
                }
                );
            modelBuilder.Entity<LessonsWorkshops>(
                entity =>
                {
                    entity.HasKey(e => e.EventId);
                    entity.Property(e => e.EventId).HasColumnName("EventId");
                    entity.Property(e => e.EventDate)
                    .IsRequired()
                    .HasMaxLength(50);
                    entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength (255);
                    entity.Property(e => e.PrivateLessons)
                    .IsRequired()
                    .HasMaxLength(255);
                    entity.Property(e => e.Workshops)
                    .IsRequired()
                    .HasMaxLength(255);
                    entity.Property(e => e.Videos)
                    .IsRequired();
                }
                );
            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
