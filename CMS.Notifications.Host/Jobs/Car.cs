using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Notifications.Host.Jobs
{
    class Car
    {
        public Guid Id { get;  set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public string VinNumber { get; set; }
        public DateTime? TermTechnicalResearch { get; set; }
        public DateTime? OcExpiry { get; set; }
        public DateTime? AcExpiry { get; set; }
        public DateTime? LiftUdtExpiry { get; set; }
        public DateTime? TachoLegalizationExpiry { get; set; }

        public bool IsExpirationApproaching(int approachingExpirationDaysBefore)
        {
            return
                (TermTechnicalResearch?.Date - DateTime.Now.Date)?.Days <= approachingExpirationDaysBefore ||
                (OcExpiry?.Date - DateTime.Now.Date)?.Days <= approachingExpirationDaysBefore ||
                (AcExpiry?.Date - DateTime.Now.Date)?.Days <= approachingExpirationDaysBefore ||
                (LiftUdtExpiry?.Date - DateTime.Now.Date)?.Days <= approachingExpirationDaysBefore ||
                (TachoLegalizationExpiry?.Date - DateTime.Now.Date)?.Days <= approachingExpirationDaysBefore;
        }
    }
}
