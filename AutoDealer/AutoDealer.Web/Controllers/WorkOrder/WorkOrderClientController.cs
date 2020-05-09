using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.WorkOrder;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.WorkOrder;
using AutoDealer.Business.Models.Commands.WorkOrder;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.ViewModels.Request.WorkOrder;
using AutoDealer.Web.ViewModels.Response.WorkOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.WorkOrder
{
    public class WorkOrderClientController : BaseWebApiController
    {
        private readonly IWorkOrderClientQueryFunctionality _queryFunctionality;
        private readonly IWorkOrderClientCommandFunctionality _commandFunctionality;

        public WorkOrderClientController(IMapperFactory mapperFactory, IWorkOrderClientQueryFunctionality queryFunctionality, IWorkOrderClientCommandFunctionality commandFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
            _commandFunctionality = commandFunctionality;
        }

        /// <summary>
        ///     Gets all service clients.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.ServiceMan) + "," + nameof(UserRoles.Director))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var items = await _queryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<WorkOrderClientViewModel>>(items));
        }

        /// <summary>
        ///     Gets service client by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.ServiceMan) + "," + nameof(UserRoles.Director))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _queryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<WorkOrderClientViewModel>(item));
        }
        
        /// <summary>
        ///     Adds service client
        /// </summary>
        /// <returns>Status code 201 and client Id.</returns>
        [HttpPost]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.ServiceMan))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] WorkOrderClientCreateViewModel item)
        {
            var clientId = await _commandFunctionality.AddAsync(Mapper.Map<WorkOrderClientCreateCommand>(item));
            return ResponseWithData(StatusCodes.Status201Created, clientId);
        }

        /// <summary>
        ///     Updates service client
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPut]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.ServiceMan))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Update([FromBody] WorkOrderClientUpdateViewModel item)
        {
            await _commandFunctionality.UpdateAsync(Mapper.Map<WorkOrderClientUpdateCommand>(item));
            return StatusCode(StatusCodes.Status201Created);
        }


        /// <summary>
        ///     Removes service client by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 204.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Remove(int id)
        {
            await _commandFunctionality.RemoveAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
