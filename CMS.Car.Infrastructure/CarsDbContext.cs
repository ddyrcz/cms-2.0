using CMS.Cars.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Cars.Infrastructure
{
    class CarsDbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}
