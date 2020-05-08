using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.User;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.ViewModels.Response.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.User
{
    public class UserController : BaseWebApiController
    {
        private readonly IUserQueryFunctionality _queryFunctionality;

        public UserController(IMapperFactory mapperFactory, IUserQueryFunctionality queryFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
        }

        /// <summary>
        ///     Gets all users.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Director))]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Director))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetActiveById(int id)
        {
            var item = await _queryFunctionality.GetActiveByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<UserViewModel>(item));
        }
    }
}
