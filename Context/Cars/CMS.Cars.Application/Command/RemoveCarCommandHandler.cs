using CMS.Cars.Infrastructure;
using CMS.Cars.Message.Commands;
using CMS.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Cars.Application.Command
{
    class RemoveCarCommandHandler : ICommandHandler<RemoveCarCommand>
    {
        private readonly CarsDbContext _dbContext;

        public RemoveCarCommandHandler(CarsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(RemoveCarCommand command)
        {
            var car = await _dbContext.Cars.FindAsync(command.CarId);

            _dbContext.Remove(car);

            _dbContext.SaveChanges();
        }
    }
}
