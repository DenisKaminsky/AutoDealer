using System;
using System.Linq;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.User;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.User;
using AutoDealer.Business.Models.Commands.User;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.Interfaces;
using AutoDealer.Web.ViewModels.Request.User;
using AutoDealer.Web.ViewModels.Response.User;
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
        private readonly IUserQueryFunctionality _userQueryFunctionality;

        public AccountController(IMapperFactory mapperFactory, IAccountCommandFunctionality accountCommandFunctionality, 
            IAccountQueryFunctionality accountQueryFunctionality, ICookieAuthenticationManager authenticationManager, IUserQueryFunctionality userQueryFunctionality) : base(mapperFactory)
        {
            _accountCommandFunctionality = accountCommandFunctionality;
            _accountQueryFunctionality = accountQueryFunctionality;
            _authenticationManager = authenticationManager;
            _userQueryFunctionality = userQueryFunctionality;
        }

        /// <summary>
        ///     Get currently authorized user info
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("UserInfo/Current")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Current()
        {
            var userId = Convert.ToInt32(User.Claims.First(c => c.Type == "Id").Value);
            var user = await _userQueryFunctionality.GetActiveByIdAsync(userId);

            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<UserSignInViewModel>(user));
        }

        /// <summary>
        ///     Log in users in system
        /// </summary>
        /// <returns>Status code 201</returns>
        [HttpPost("SignIn")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SignIn([FromBody] LogInVewModel logInViewModel)
        {
            var registeredUser = await _accountQueryFunctionality.GetSignInInfoAsync(Mapper.Map<LogInInfo>(logInViewModel));
            if (registeredUser == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            await _authenticationManager.SignInAsync(HttpContext, registeredUser);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<UserSignInViewModel>(registeredUser));
        }          

        /// <summary>
        ///     Log out users from system
        /// </summary>
        /// <returns>Status code 201</returns>
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
        [Authorize(Roles = nameof(UserRoles.Admin))]
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
        [Authorize(Roles = nameof(UserRoles.Admin))]
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
        [Authorize(Roles = nameof(UserRoles.Admin))]
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
        [Authorize(Roles = nameof(UserRoles.Admin))]
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
        [HttpDelete("Delete{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Remove(int id)
        {
            await _accountCommandFunctionality.RemoveAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
