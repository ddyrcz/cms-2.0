using CMS.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Cars.Message.Commands
{
    public class RemoveCarCommand : ICommand
    {
        public RemoveCarCommand(Guid carId)
        {
            CarId = carId;
        }

        public Guid CarId { get; }
    }
}
