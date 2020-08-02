using CMS.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Cars.Message.Commands
{
    public class UpdateCarCommand : ICommand
    {
        public Guid CarId { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime? TermTechnicalResearch { get; set; }
        public DateTime? OcExpiry { get; set; }
        public DateTime? OcInstallmentDate { get; set; }
        public DateTime? AcExpiry { get; set; }
        public DateTime? LiftUdtExpiry { get; set; }
        public DateTime? TachoLegalizationExpiry { get; set; }
    }
}
