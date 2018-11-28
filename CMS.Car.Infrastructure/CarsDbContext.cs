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
    }
}
