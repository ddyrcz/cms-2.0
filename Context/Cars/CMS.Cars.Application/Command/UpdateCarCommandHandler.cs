using CMS.Cars.Infrastructure;
using CMS.Cars.Message.Commands;
using CMS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Cars.Application.Command
{
    class UpdateCarCommandHandler : ICommandHandler<UpdateCarCommand>
    {
        private readonly CarsDbContext _dbContext;

        public UpdateCarCommandHandler(CarsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var car = _dbContext.Cars.Single(c => c.Id == command.CarId);

            car.UpdateIdentificationData(command.Name,
                command.RegistrationNumber);
            
            car.UpdateDates(command.TermTechnicalResearch,
                command.OcExpiry,
                command.OcInstallmentDate,
                command.AcExpiry,
                command.LiftUdtExpiry,
                command.TachoLegalizationExpiry);

            await _dbContext.SaveChangesAsync();
        }
    }
}
