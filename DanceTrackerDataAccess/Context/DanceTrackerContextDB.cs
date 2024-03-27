using DanceTrackerDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceTrackerDataAccess.Context
{
    public class DanceTrackerContextDB : DbContext
    {
        public DanceTrackerContextDB(DbContextOptions options) : base(options)
        {
        }

        protected DanceTrackerContextDB()
        {
        }

        public DbSet<HomeTable> HomeTable {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HomeTable>(
                entity =>
                {
                    entity.HasKey(e => e.EventId);
                    entity.Property(e => e.EventId);
                    entity.Property(e => e.DateOfEvent);
                    entity.Property(e => e.EventName);
                    entity.Property(e => e.EventLocation);
                    entity.Property(e => e.Competitions);
                    entity.Property(e => e.LessonsAndWorkshops);
                }
                
                );
        }
    }
}
