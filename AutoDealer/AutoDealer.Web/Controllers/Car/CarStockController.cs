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
    public class CarStockController : BaseWebApiController
    {
        private readonly ICarStockQueryFunctionality _queryFunctionality;
        private readonly ICarStockCommandFunctionality _commandFunctionality;

        public CarStockController(IMapperFactory mapperFactory, ICarStockQueryFunctionality queryFunctionality, ICarStockCommandFunctionality commandFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
            _commandFunctionality = commandFunctionality;
        }

        /// <summary>
        ///     Gets all cars in stock.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var items = await _queryFunctionality.GetAllInStockAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<CarStockViewModel>>(items));
        }

        /// <summary>
        ///     Gets car by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _queryFunctionality.GetInStockByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<CarStockViewModel>(item));
        }

        /// <summary>
        ///     Adds car to stock (not equals to order)
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CarStockCreateViewModel item)
        {
            await _commandFunctionality.AddAsync(Mapper.Map<CarStockCreateCommand>(item));
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Updates car in stock
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CarStockUpdateViewModel item)
        {
            await _commandFunctionality.UpdateAsync(Mapper.Map<CarStockUpdateCommand>(item));
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Removes car from stock
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
