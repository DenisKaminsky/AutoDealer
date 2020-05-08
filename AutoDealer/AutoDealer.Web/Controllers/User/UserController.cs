using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.User;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.User;
using AutoDealer.Business.Models.Commands.User;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.ViewModels.Request.User;
using AutoDealer.Web.ViewModels.Response.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.User
{
    public class UserController : BaseWebApiController
    {
        private readonly IUserQueryFunctionality _queryFunctionality;
        private readonly IUserCommandFunctionality _commandFunctionality;

        public UserController(IMapperFactory mapperFactory, IUserQueryFunctionality queryFunctionality, IUserCommandFunctionality commandFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
            _commandFunctionality = commandFunctionality;
        }

        /// <summary>
        ///     Gets all users.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _queryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<UserViewModel>>(items));
        }

        /// <summary>
        ///     Gets all active users (for director).
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("Active")]
        public async Task<IActionResult> GetAllActive()
        {
            var items = await _queryFunctionality.GetAllActiveAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<UserViewModel>>(items));
        }

        /// <summary>
        ///     Gets user by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _queryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<UserViewModel>(item));
        }

        /// <summary>
        ///     Gets active user by id (for director).
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("Active/{id}")]
        public async Task<IActionResult> GetActiveById(int id)
        {
            var item = await _queryFunctionality.GetActiveByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<UserViewModel>(item));
        }

        /// <summary>
        ///     Adds user (admin only)
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserCreateViewModel item)
        {
            await _commandFunctionality.AddAsync(Mapper.Map<UserCreateCommand>(item));
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Updates user (admin only) 
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserUpdateViewModel item)
        {
            await _commandFunctionality.UpdateAsync(Mapper.Map<UserUpdateCommand>(item));
            return StatusCode(StatusCodes.Status200OK);
        }

        /// <summary>
        ///     Activates or deactivates user (admin only)
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPut("ActiveStatus")]
        public async Task<IActionResult> UpdateActiveStatus([FromBody] UserUpdateActiveStatusViewModel item)
        {
            await _commandFunctionality.UpdateActiveStatusAsync(Mapper.Map<UserUpdateActiveStatusCommand>(item));
            return StatusCode(StatusCodes.Status200OK);
        }

        /// <summary>
        ///     Resets user password (admin only)
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPut("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] UserResetPasswordViewModel item)
        {
            await _commandFunctionality.ResetPasswordAsync(Mapper.Map<UserResetPasswordCommand>(item));
            return StatusCode(StatusCodes.Status200OK);
        }

        /// <summary>
        ///     Removes user by id
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
