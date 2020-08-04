using CMS.Cars.Infrastructure;
using CMS.Cars.Message.Query;
using CMS.Core.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Cars.Application.Query
{
    class GetCarDetailsQueryHandler : IQueryHandler<GetCarDetailsQuery>
    {
        private readonly CarsDbContext _dbContext;

        public GetCarDetailsQueryHandler(CarsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryResult> Handle(GetCarDetailsQuery query)
        {
            var car = await _dbContext.Cars.SingleAsync(c => c.Id == query.CarId);

            return new GetCarDetailsQueryResult(new GetCarDetailsQueryResult.CarDto(
                car.Id,
                car.Name,
                car.RegistrationNumber,
                car.VinNumber,
                car.TermTechnicalResearch,
                car.OcExpiry,
                car.OcInstallmentDate,
                car.AcExpiry,
                car.LiftUdtExpiry,
                car.TachoLegalizationExpiry));
        }
    }
}
