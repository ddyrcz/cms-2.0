using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Cars;
using CMS.Cars.Message.Commands;
using CMS.Cars.Message.Query;
using CMS.Core;
using CMS.Core.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public CarsController(ICommandBus commandBus,
            IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [HttpPost]
        public async Task Create(CreateCarCommand request)
        {
            await _commandBus.Send(request);
        }

        [HttpGet]
        public async Task<GetCarsQueryResult> GetAll()
        {
            var getCarsQuery = new GetCarsQuery();
            
            var result = await _queryBus.SendQuery(getCarsQuery);

            return result as GetCarsQueryResult;
        }

        [HttpGet("{id}")]
        public async Task<GetCarDetailsQueryResult> GetDetails(Guid id)
        {
            var query = new GetCarDetailsQuery(id);

            var result = await _queryBus.SendQuery(query);

            return result as GetCarDetailsQueryResult;
        }

        [HttpPut]
        public async Task Update(UpdateCarCommand request)
        {
            await _commandBus.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            var command = new RemoveCarCommand(id);

            await _commandBus.Send(command);
        }
    }
}