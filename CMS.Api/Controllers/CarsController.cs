using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Cars;
using CMS.Cars.Application.Command;
using CMS.Cars.Application.Query.GetCarDetails;
using CMS.Cars.Application.Query.GetCars;
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
        public async Task<GetCarsQueryResult> GetCars()
        {
            var getCarsQuery = new GetCarsQuery();
            
            var result = await _queryBus.SendQuery(getCarsQuery);

            return result as GetCarsQueryResult;
        }

        [HttpGet("{id}")]
        public async Task<GetCarDetailsQueryResult> GetCarDetails(Guid id)
        {
            var query = new GetCarDetailsQuery(id);

            var result = await _queryBus.SendQuery(query);

            return result as GetCarDetailsQueryResult;
        }

    }
}