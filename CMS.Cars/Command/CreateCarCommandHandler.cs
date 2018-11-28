using CMS.Cars.Domain;
using CMS.Cars.Infrastructure;
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
                command.Description,
                "123",
                "456",
                DateTime.Now,
                DateTime.Now,
                null,
                null,
                null);

            _context.Add(car);
            await _context.SaveChangesAsync();
        }
    }
}
