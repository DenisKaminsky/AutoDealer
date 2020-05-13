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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var engines = await _queryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<CarEngineViewModel>>(engines));
        }

        /// <summary>
        ///     Gets all supported engine-gearbox pairs.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("WithGearbox")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEngineGearboxPairs()
        {
            var pairs = await _queryFunctionality.GetAllEngineGearboxPairsAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<CarEngineGearboxViewModel>>(pairs));
        }

        /// <summary>
        ///     Gets engine by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var engine = await _queryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<CarEngineViewModel>(engine));
        }

        /// <summary>
        ///     Gets supported engine-gearbox pairs by model id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("ByModel/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEngineGearboxPairsByModelId(int id)
        {
            var pairs = await _queryFunctionality.GetEngineGearboxPairsByModelIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<CarModelEngineGearboxViewModel>>(pairs));
        }

        /// <summary>
        ///     Adds engine
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost("Create")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] CarEngineCreateViewModel engine)
        {
            await _commandFunctionality.AddAsync(Mapper.Map<CarEngineCreateCommand>(engine));
            return StatusCode(StatusCodes.Status201Created);
        }


        /// <summary>
        ///     Updates engine 
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPut("Update")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Remove(int id)
        {
            await _commandFunctionality.RemoveAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        /// <summary>
        ///     Assigns engine-gearbox pair to model
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPost("Assign")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Assign([FromBody] CarEngineGearboxAssignViewModel assignViewModel)
        {
            await _commandFunctionality.AssignAsync(Mapper.Map<CarEngineGearboxAssignCommand>(assignViewModel));
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Unassigns engine-gearbox pair from model
        /// </summary>
        /// <returns>Status code 204.</returns>
        [HttpDelete("Unassign")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Unassign([FromBody] CarEngineGearboxUnassignViewModel unassignViewModel)
        {
            await _commandFunctionality.UnassignAsync(Mapper.Map<CarEngineGearboxUnassignCommand>(unassignViewModel));
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
