using CMS.Core.Query;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace CMS.Cars.Application.Query.GetCars
{
    public class GetCarsQuery : IQuery
    {
        
    }

    public class GetCarsQueryResult : IQueryResult
    {
        public List<Car> Cars { get; set; }

        public class Car
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}
