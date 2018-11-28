using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Cars;
using CMS.Cars.Application.Command;
using CMS.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICommandBus _bus;

        public CarsController(ICommandBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task Create()
        {
            var command = new CreateCarCommand();

            await _bus.Send(command);
        }
    }
}