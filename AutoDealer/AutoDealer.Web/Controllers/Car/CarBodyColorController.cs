using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.Miscellaneous;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Miscellaneous;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Business.Models.Commands.Miscellaneous;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.ViewModels.Request.Car;
using AutoDealer.Web.ViewModels.Request.Miscellaneous;
using AutoDealer.Web.ViewModels.Response.Miscellaneous;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.Car
{
    public class CarBodyColorController : BaseWebApiController
    {
        private readonly IColorCodeQueryFunctionality _queryFunctionality;
        private readonly IColorCodeCommandFunctionality _commandFunctionality;

        public CarBodyColorController(IMapperFactory mapperFactory, IColorCodeQueryFunctionality queryFunctionality, 
            IColorCodeCommandFunctionality commandFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
            _commandFunctionality = commandFunctionality;
        }

        /// <summary>
        ///     Gets all colors.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var colors = await _queryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<ColorCodeViewModel>>(colors));
        }

        /// <summary>
        ///     Gets color by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var color = await _queryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<ColorCodeViewModel>(color));
        }

        /// <summary>
        ///     Gets colors by model id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("ByModel/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByModelId(int id)
        {
            var colors = await _queryFunctionality.GetByModelIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<ColorCodeViewModel>>(colors));
        }

        /// <summary>
        ///     Adds color
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost("Create")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] ColorCodeCreateViewModel color)
        {
            var id = await _commandFunctionality.AddAsync(Mapper.Map<ColorCodeCreateCommand>(color));
            return ResponseWithData(StatusCodes.Status201Created, id);
        }
        
        /// <summary>
        ///     Removes color by id
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
        ///     Assigns car color to model
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPost("Assign")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Assign([FromBody] CarColorAssignmentViewModel assignViewModel)
        {
            await _commandFunctionality.AssignAsync(Mapper.Map<CarColorAssignmentCommand>(assignViewModel));
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Unassigns car color from model
        /// </summary>
        /// <returns>Status code 204.</returns>
        [HttpDelete("Unassign")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Unassign([FromBody] CarColorAssignmentViewModel unassignViewModel)
        {
            await _commandFunctionality.UnassignAsync(Mapper.Map<CarColorAssignmentCommand>(unassignViewModel));
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
