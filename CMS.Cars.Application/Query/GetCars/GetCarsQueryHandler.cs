using CMS.Core.Query;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Cars.Application.Query.GetCars
{
    public class GetCarsQueryHandler : IQueryHandler<GetCarsQuery>
    {
        public Task<IQueryResult> Handle(GetCarsQuery query)
        {
            var result = new GetCarsQueryResult();

            result.Cars = new List<GetCarsQueryResult.Car>()
            {
                new GetCarsQueryResult.Car{
                    Id = Guid.NewGuid(),
                    Name = "Audi A6"
                }
            };

            return Task.FromResult(result as IQueryResult);
        }
    }
}
