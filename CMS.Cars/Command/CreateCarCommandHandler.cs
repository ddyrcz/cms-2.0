using CMS.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Cars.Application.Command
{
    class CreateCarCommandHandler : ICommandHandler<CreateCarCommand>
    {
        public Task Handle(CreateCarCommand command)
        {
            return Task.CompletedTask;
        }
    }
}
