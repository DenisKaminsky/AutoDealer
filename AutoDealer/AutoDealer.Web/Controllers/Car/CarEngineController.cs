using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.Car;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Car;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.ViewModels.Request.Car;
using AutoDealer.Web.ViewModels.Response.Car;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.Car
{
    public class CarEngineController : BaseWebApiController
    {
        private readonly ICarEngineQueryFunctionality _queryFunctionality;
        private readonly ICarEngineCommandFunctionality _commandFunctionality;

        public CarEngineController(IMapperFactory mapperFactory, ICarEngineQueryFunctionality queryFunctionality, ICarEngineCommandFunctionality commandFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
            _commandFunctionality = commandFunctionality;
        }

        /// <summary>
        ///     Gets all engines.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var engines = await _queryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<CarEngineViewModel>>(engines));
        }

        /// <summary>
        ///     Gets engine by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var engine = await _queryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<CarEngineViewModel>(engine));
        }

        /// <summary>
        ///     Adds engine
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CarEngineCreateViewModel engine)
        {
            await _commandFunctionality.AddAsync(Mapper.Map<CarEngineCreateCommand>(engine));
            return StatusCode(StatusCodes.Status201Created);
        }


        /// <summary>
        ///     Updates engine 
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CarEngineUpdateViewModel engine)
        {
            await _commandFunctionality.UpdateAsync(Mapper.Map<CarEngineUpdateCommand>(engine));
            return StatusCode(StatusCodes.Status200OK);
        }


        /// <summary>
        ///     Removes engine by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 204.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _commandFunctionality.RemoveAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
