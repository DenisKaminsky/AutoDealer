using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.User;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.User;
using AutoDealer.Business.Models.Commands.User;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.ViewModels.Request.User;
using AutoDealer.Web.ViewModels.Response.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.User
{
    public class ClientController : BaseWebApiController
    {
        private readonly IClientQueryFunctionality _queryFunctionality;
        private readonly IClientCommandFunctionality _commandFunctionality;

        public ClientController(IMapperFactory mapperFactory, IClientQueryFunctionality queryFunctionality, IClientCommandFunctionality commandFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
            _commandFunctionality = commandFunctionality;
        }

        /// <summary>
        ///     Gets all clients.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var items = await _queryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<ClientViewModel>>(items));
        }

        /// <summary>
        ///     Gets client by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _queryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<ClientViewModel>(item));
        }

        /// <summary>
        ///     Gets client by model passportId.
        /// </summary>
        /// <param name="passportId"></param>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("ByPassportId/{passportId}")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByPassportId(string passportId)
        {
            var item = await _queryFunctionality.GetByPassportIdAsync(passportId);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<ClientViewModel>(item));
        }
        
        /// <summary>
        ///     Adds client
        /// </summary>
        /// <returns>Status code 201 and client Id.</returns>
        [HttpPost]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] ClientCreateViewModel item)
        {
            await _commandFunctionality.AddAsync(Mapper.Map<ClientCreateCommand>(item));
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Updates client
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPut]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Update([FromBody] ClientUpdateViewModel item)
        {
            await _commandFunctionality.UpdateAsync(Mapper.Map<ClientUpdateCommand>(item));
            return StatusCode(StatusCodes.Status201Created);
        }


        /// <summary>
        ///     Removes client by id
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
