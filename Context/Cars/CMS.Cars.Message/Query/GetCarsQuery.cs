using CMS.Core.Query;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace CMS.Cars.Message.Query
{
    public class GetCarsQuery : IQuery
    {
        
    }

    public class GetCarsQueryResult : IQueryResult
    {
        public GetCarsQueryResult()
        {
            Cars = new List<Car>();
        }

        public List<Car> Cars { get; set; }

        public class Car
        {
            public Car(Guid id,
                string name,
                string registrationNumber,
                bool isReviewRequired)
            {
                Id = id;
                Name = name;
                RegistrationNumber = registrationNumber;
                IsReviewRequired = isReviewRequired;
            }

            public Guid Id { get; }
            public string Name { get;}
            public string RegistrationNumber { get; }
            public bool IsReviewRequired { get;  }
        }
    }
}
