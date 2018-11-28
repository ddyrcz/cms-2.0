using CMS.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Cars.Application.Command
{
    public class CreateCarCommand : ICommand
    {
        public string Description { get; set; } = "Ford Fusion";
    }
}
