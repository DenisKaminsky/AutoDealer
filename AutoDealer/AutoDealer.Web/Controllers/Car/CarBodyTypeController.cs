using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.Car;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Car;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.ViewModels.Request.Car;
using AutoDealer.Web.ViewModels.Response.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.Car
{
    public class CarBodyTypeController : BaseWebApiController
    {
        private readonly ICarBodyTypeQueryFunctionality _queryFunctionality;
        private readonly ICarBodyTypeCommandFunctionality _commandFunctionality;

        public CarBodyTypeController(IMapperFactory mapperFactory, ICarBodyTypeQueryFunctionality queryFunctionality, ICarBodyTypeCommandFunctionality commandFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
            _commandFunctionality = commandFunctionality;
        }

        /// <summary>
        ///     Gets all car body types.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var bodyTypes = await _queryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<CarBodyTypeViewModel>>(bodyTypes));
        }

        /// <summary>
        ///     Gets car body type by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var bodyType = await _queryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<CarBodyTypeViewModel>(bodyType));
        }

        /// <summary>
        ///     Gets car body type by model id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("ByModel/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByBrandId(int id)
        {
            var bodyTypes = await _queryFunctionality.GetByModelIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<CarBodyTypeWithPriceViewModel>>(bodyTypes));
        }

        /// <summary>
        ///     Adds car body type
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost("Create")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] CarBodyTypeCreateViewModel bodyType)
        {
            var id = await _commandFunctionality.AddAsync(Mapper.Map<CarBodyTypeCreateCommand>(bodyType));
            return ResponseWithData(StatusCodes.Status201Created, id);
        }
        
        /// <summary>
        ///     Removes car body type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 204.</returns>
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Remove(int id)
        {
            await _commandFunctionality.RemoveAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        /// <summary>
        ///     Assigns car body type to model
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPost("Assign")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Assign([FromBody] CarBodyTypeAssignViewModel assignViewModel)
        {
            await _commandFunctionality.AssignAsync(Mapper.Map<CarBodyTypeAssignCommand>(assignViewModel));
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Unassigns car body type from model
        /// </summary>
        /// <returns>Status code 204.</returns>
        [HttpDelete("Unassign")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Unassign([FromBody] CarBodyTypeUnassignViewModel unassignViewModel)
        {
            await _commandFunctionality.UnassignAsync(Mapper.Map<CarBodyTypeUnassignCommand>(unassignViewModel));
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
