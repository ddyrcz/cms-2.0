using CMS.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Cars.Application.Command
{
    public class CreateCarCommand : ICommand
    {
        public string Description { get; set; }
        public string RegistrationNumber { get; set; }
        public string VinNumber { get; set; }
        public DateTime TermTechnicalResearch { get; set; }
        public DateTime OcExpiry { get; set; }
        public DateTime? AcExpiry { get; set; }
        public DateTime? LiftUdtExpiry { get; set; }
        public DateTime? TachoLegalizationExpiry { get; set; }
    }
}
