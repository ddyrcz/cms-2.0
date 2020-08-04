using CMS.Cars.Domain;
using CMS.Cars.Infrastructure;
using CMS.Cars.Message.Commands;
using CMS.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Cars.Application.Command
{
    class CreateCarCommandHandler : ICommandHandler<CreateCarCommand>
    {
        private readonly CarsDbContext _context;

        public CreateCarCommandHandler(CarsDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCarCommand command)
        {
            var car = new Car(Guid.NewGuid(),
                command.Name,
                command.RegistrationNumber,
                command.VinNumber,
                command.TermTechnicalResearch,
                command.OcExpiry,
                command.OcInstallmentDate,
                command.AcExpiry,
                command.LiftUdtExpiry,
                command.TachoLegalizationExpiry);

            _context.Add(car);
            await _context.SaveChangesAsync();
        }
    }
}
