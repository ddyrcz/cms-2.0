using CMS.Core.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Cars.Message.Query
{
    public class GetCarDetailsQuery : IQuery
    {
        public GetCarDetailsQuery(Guid carId)
        {
            CarId = carId;
        }

        public Guid CarId { get; }
    }

    public class GetCarDetailsQueryResult : IQueryResult
    {
        public GetCarDetailsQueryResult(CarDto car)
        {
            Car = car;
        }

        public CarDto Car { get; }

        public class CarDto
        {
            public CarDto(Guid id,
               string name,
               string registrationNumber,
               string vinNumber,
               DateTime? termTechnicalResearch,
               DateTime? ocExpiry,
               DateTime? ocInstallmentDate,
               DateTime? acExpiry,
               DateTime? liftUdtExpiry,
               DateTime? tachoLegalizationExpiry)
            {
                Id = id;
                Name = name;
                RegistrationNumber = registrationNumber;
                VinNumber = vinNumber;
                TermTechnicalResearch = termTechnicalResearch;
                OcExpiry = ocExpiry;
                OcInstallmentDate = ocInstallmentDate;
                AcExpiry = acExpiry;
                LiftUdtExpiry = liftUdtExpiry;
                TachoLegalizationExpiry = tachoLegalizationExpiry;
            }

            public Guid Id { get; }
            public string Name { get; }
            public string RegistrationNumber { get; }
            public string VinNumber { get; }
            public DateTime? TermTechnicalResearch { get; }
            public DateTime? OcExpiry { get; }
            public DateTime? OcInstallmentDate { get; }
            public DateTime? AcExpiry { get; }
            public DateTime? LiftUdtExpiry { get; }
            public DateTime? TachoLegalizationExpiry { get; }
        }
    }
}
