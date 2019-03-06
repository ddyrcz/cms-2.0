using CMS.Cars.Infrastructure;
using CMS.Core.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Cars.Application.Query.GetCars
{
    public class GetCarsQueryHandler : IQueryHandler<GetCarsQuery>
    {
        private readonly CarsDbContext _dbContext;

        public GetCarsQueryHandler(CarsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryResult> Handle(GetCarsQuery query)
        {
            var carsProjection = await _dbContext.Cars
                .Select(car => new { car.Id, car.Name })
                .ToListAsync();

            foreach (var car in carsProjection)
            {

            }

            return new GetCarsQueryResult
            {
                Cars = cars
            };
        }
    }
}
