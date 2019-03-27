using System;

namespace CMS.Cars.Domain
{
    public class Car
    {
        public Car(Guid id, 
            string name, 
            string registrationNumber, 
            string vinNumber,
            DateTime termTechnicalResearch, 
            DateTime ocExpiry,
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
            AcExpiry = acExpiry;
            LiftUdtExpiry = liftUdtExpiry;
            TachoLegalizationExpiry = tachoLegalizationExpiry;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string RegistrationNumber { get; private set; }
        public string VinNumber { get; private set; }
        public DateTime TermTechnicalResearch { get; private set; }
        public DateTime OcExpiry { get; private set; }
        public DateTime? AcExpiry { get; private set; }
        public DateTime? LiftUdtExpiry { get; private set; }
        public DateTime? TachoLegalizationExpiry { get; private set; }

        public void UpdateIdentificationData(string name,
            string registrationNumber)
        {
            Name = name;
            RegistrationNumber = registrationNumber;
        }        

        public void UpdateDates(DateTime termTechnicalResearch,
            DateTime ocExpiry,
            DateTime? acExpiry,
            DateTime? liftUdtExpiry,
            DateTime? tachoLegalizationExpiry)
        {
            TermTechnicalResearch = termTechnicalResearch;
            OcExpiry = ocExpiry;
            AcExpiry = acExpiry;
            LiftUdtExpiry = liftUdtExpiry;
            TachoLegalizationExpiry = tachoLegalizationExpiry;
        }
    }
}
