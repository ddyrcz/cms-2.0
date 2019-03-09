using CMS.Cars.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Cars.Infrastructure
{
    public class CarsDbContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public CarsDbContext(DbContextOptions<CarsDbContext> options)
            :base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(x => x.OcExpiry).HasColumnType("date");
            modelBuilder.Entity<Car>()
                .Property(x => x.AcExpiry).HasColumnType("date");
            modelBuilder.Entity<Car>()
                .Property(x => x.LiftUdtExpiry).HasColumnType("date");
            modelBuilder.Entity<Car>()
                .Property(x => x.TachoLegalizationExpiry).HasColumnType("date");
            modelBuilder.Entity<Car>()
                .Property(x => x.TermTechnicalResearch).HasColumnType("date");

            modelBuilder.Entity<Car>().HasData(SeedData.Cars);
        }

    }
}
