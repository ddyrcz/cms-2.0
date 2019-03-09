using CMS.Cars.Domain;
using CMS.Cars.Infrastructure;
using CMS.Cars.Message.Query;
using CMS.Core.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Cars.Application.Query
{
    public class GetCarsQueryHandler : IQueryHandler<GetCarsQuery>
    {
        private readonly CarsDbContext _dbContext;
        private readonly Configuration _configuration;

        public GetCarsQueryHandler(CarsDbContext dbContext,
            Configuration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<IQueryResult> Handle(GetCarsQuery query)
        {
            var cars = await _dbContext.Cars
                .ToListAsync();

            var result = new GetCarsQueryResult();

            foreach (var car in cars)
            {
                bool expirationApproaching = car.IsExpirationApproaching(_configuration.ApproachingExpirationDaysBefore);

                result.Cars.Add(new GetCarsQueryResult.Car(car.Id,
                    car.Name,
                    car.RegistrationNumber,
                    expirationApproaching));
            }

            return result;
        }
    }
}
