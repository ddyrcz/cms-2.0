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
    }
}
