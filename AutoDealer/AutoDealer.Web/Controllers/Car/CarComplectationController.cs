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
    public class CarComplectationController : BaseWebApiController
    {
        private readonly ICarComplectationQueryFunctionality _queryFunctionality;
        private readonly ICarComplectationCommandFunctionality _commandFunctionality;

        public CarComplectationController(IMapperFactory mapperFactory, ICarComplectationQueryFunctionality queryFunctionality, ICarComplectationCommandFunctionality commandFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
            _commandFunctionality = commandFunctionality;
        }

        /// <summary>
        ///     Gets all cars complectations names.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _queryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<CarComplectationViewModel>>(items));
        }

        /// <summary>
        ///     Gets car complectation by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _queryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<CarComplectationViewModel>(item));
        }

        /// <summary>
        ///     Gets car complectations by model id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("ByModel/{id}")]
        public async Task<IActionResult> GetByBrandId(int id)
        {
            var items = await _queryFunctionality.GetByModelIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<CarComplectationViewModel>>(items));
        }

        /// <summary>
        ///     Gets car complectation options by complectation id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("ByComplectation/{id}")]
        public async Task<IActionResult> GetOptionsByComplectationId(int id)
        {
            var items = await _queryFunctionality.GetOptionsByComplectationIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<CarComplectationOptionViewModel>>(items));
        }

        /// <summary>
        ///     Adds car complectation
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CarComplectationCreateViewModel item)
        {
            await _commandFunctionality.AddAsync(Mapper.Map<CarComplectationCreateCommand>(item));
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Adds options to complectation
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost("Options")]
        public async Task<IActionResult> AddOptions([FromBody] CarComplectationOptionsAssignViewModel assignViewModel)
        {
            await _commandFunctionality.AddOptionsAsync(Mapper.Map<CarComplectationOptionsAssignCommand>(assignViewModel));
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Removes car complectation by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 204.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _commandFunctionality.RemoveAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        /// <summary>
        ///     Removes complectation by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 204.</returns>
        [HttpDelete("Options/{id}")]
        public async Task<IActionResult> RemoveComplectation(int id)
        {
            await _commandFunctionality.RemoveOptionAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
