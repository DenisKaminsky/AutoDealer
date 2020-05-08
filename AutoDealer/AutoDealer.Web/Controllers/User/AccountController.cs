using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.User;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.User;
using AutoDealer.Business.Models.Commands.User;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.Interfaces;
using AutoDealer.Web.ViewModels.Request.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.User
{
    public class AccountController : BaseWebApiController
    {
        private readonly IAccountCommandFunctionality _accountCommandFunctionality;
        private readonly IAccountQueryFunctionality _accountQueryFunctionality;
        private readonly ICookieAuthenticationManager _authenticationManager;

        public AccountController(IMapperFactory mapperFactory, IAccountCommandFunctionality accountCommandFunctionality, IAccountQueryFunctionality accountQueryFunctionality, ICookieAuthenticationManager authenticationManager) : base(mapperFactory)
        {
            _accountCommandFunctionality = accountCommandFunctionality;
            _accountQueryFunctionality = accountQueryFunctionality;
            _authenticationManager = authenticationManager;
        }

        /// <summary>
        ///     Log in users in system
        /// </summary>
        /// <returns>Status code 201</returns>
        [HttpPost("SignIn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SignIn([FromBody] LogInVewModel logInViewModel)
        {
            var registeredUser = await _accountQueryFunctionality.GetSignInInfoAsync(Mapper.Map<LogInInfo>(logInViewModel));
            if (registeredUser == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            await _authenticationManager.SignInAsync(HttpContext, registeredUser);
            return StatusCode(StatusCodes.Status200OK);
        }

        /// <summary>
        ///     Log out users from system
        /// </summary>
        /// <returns>Status code 201</returns>
        [Authorize]
        [HttpPost("SignOut")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SignOut()
        {
            await _authenticationManager.SignOutAsync(HttpContext);
            return StatusCode(StatusCodes.Status200OK);
        }

        /// <summary>
        ///     Adds user (admin only)
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] UserCreateViewModel item)
        {
            await _accountCommandFunctionality.AddAsync(Mapper.Map<UserCreateCommand>(item));
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Updates user (admin only) 
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UserUpdateViewModel item)
        {
            await _accountCommandFunctionality.UpdateAsync(Mapper.Map<UserUpdateCommand>(item));
            return StatusCode(StatusCodes.Status200OK);
        }

        /// <summary>
        ///     Activates or deactivates user (admin only)
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPut("ActiveStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateActiveStatus([FromBody] UserUpdateActiveStatusViewModel item)
        {
            await _accountCommandFunctionality.UpdateActiveStatusAsync(Mapper.Map<UserUpdateActiveStatusCommand>(item));
            return StatusCode(StatusCodes.Status200OK);
        }

        /// <summary>
        ///     Resets user password (admin only)
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPut("ResetPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ResetPassword([FromBody] UserResetPasswordViewModel item)
        {
            await _accountCommandFunctionality.ResetPasswordAsync(Mapper.Map<UserResetPasswordCommand>(item));
            return StatusCode(StatusCodes.Status200OK);
        }

        /// <summary>
        ///     Removes user by id (admin only)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 204.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Remove(int id)
        {
            await _accountCommandFunctionality.RemoveAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
