using CMS.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Cars.Message.Commands
{
    public class CreateCarCommand : ICommand
    {
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
