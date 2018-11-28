using System;

namespace CMS.Cars.Domain
{
    public class Car
    {
        public Car(Guid id, 
            string description, 
            string registrationNumber, 
            string vinNumber,
            DateTime termTechnicalResearch, 
            DateTime ocExpiry,
            DateTime? acExpiry, 
            DateTime? liftUdtExpiry, 
            DateTime? tachoLegalizationExpiry)
        {
            Id = id;
            Description = description;
            RegistrationNumber = registrationNumber;
            VinNumber = vinNumber;
            TermTechnicalResearch = termTechnicalResearch;
            OcExpiry = ocExpiry;
            AcExpiry = acExpiry;
            LiftUdtExpiry = liftUdtExpiry;
            TachoLegalizationExpiry = tachoLegalizationExpiry;
        }

        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public string RegistrationNumber { get; private set; }
        public string VinNumber { get; private set; }
        public DateTime TermTechnicalResearch { get; private set; }
        public DateTime OcExpiry { get; private set; }
        public DateTime? AcExpiry { get; private set; }
        public DateTime? LiftUdtExpiry { get; private set; }
        public DateTime? TachoLegalizationExpiry { get; private set; }
    }
}
