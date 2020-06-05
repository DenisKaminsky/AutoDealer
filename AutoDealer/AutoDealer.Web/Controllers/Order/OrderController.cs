using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.Order;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Order;
using AutoDealer.Business.Models.Commands.Order;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.Extensions;
using AutoDealer.Web.ViewModels.Request.Order;
using AutoDealer.Web.ViewModels.Response.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.Order
{
    public class OrderController : BaseWebApiController
    {
        private readonly IOrderQueryFunctionality _queryFunctionality;
        private readonly IOrderCommandFunctionality _commandFunctionality;

        public OrderController(IMapperFactory mapperFactory, IOrderQueryFunctionality queryFunctionality, IOrderCommandFunctionality commandFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
            _commandFunctionality = commandFunctionality;
        }

        /// <summary>
        ///     Gets all orders.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var items = await _queryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<OrderViewModel>>(items));
        }
        
        /// <summary>
        ///     Gets orders, assigned to current user (for Manager).
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("ByManager/Current")]
        [Authorize(Roles = nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByManager()
        {
            var items = await _queryFunctionality.GetByManagerAsync(Convert.ToInt32(User.Claims.First(c => c.Type == "Id").Value));
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<OrderViewModel>>(items));
        }

        /// <summary>
        ///     Gets orders, assigned to user (for Admin).
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("ByManager/{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByManager(int id)
        {
            var items = await _queryFunctionality.GetByManagerAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<OrderViewModel>>(items));
        }

        /// <summary>
        ///     Gets orders by client
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("ByClient/{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByClient(int id)
        {
            var items = await _queryFunctionality.GetByClientAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<OrderViewModel>>(items));
        }

        /// <summary>
        ///     Gets order by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _queryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<OrderViewModel>(item));
        }

        /// <summary>
        ///     Creates order (for Admin).
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost("Create/Admin")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(OrderCreateAdminViewModel request)
        {
            var id = await _commandFunctionality.AddAsync(Mapper.Map<OrderCreateCommand>(request));
            return ResponseWithData(StatusCodes.Status201Created, id);
        }

        /// <summary>
        ///     Creates order (for Manager).
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost("Create")]
        [Authorize(Roles = nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(OrderCreateViewModel request)
        {
            var command = Mapper.Map<OrderCreateCommand>(request);
            command.ManagerId = Convert.ToInt32(User.Claims.First(c => c.Type == "Id").Value);

            var id = await _commandFunctionality.AddAsync(command);
            return ResponseWithData(StatusCodes.Status201Created, id);
        }

        /// <summary>
        ///     Creates order.
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost("Create/WithOrder/Admin")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddWithOrder(OrderCreateAdminViewModel request)
        {
            var id = await _commandFunctionality.AddWithOrderAsync(Mapper.Map<OrderCreateCommand>(request));
            return ResponseWithData(StatusCodes.Status201Created, id);
        }

        /// <summary>
        ///     Creates order.
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost("Create/WithOrder")]
        [Authorize(Roles = nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddWithOrder(OrderCreateViewModel request)
        {
            var command = Mapper.Map<OrderCreateCommand>(request);
            command.ManagerId = Convert.ToInt32(User.Claims.First(c => c.Type == "Id").Value);

            var id = await _commandFunctionality.AddWithOrderAsync(command);
            return ResponseWithData(StatusCodes.Status201Created, id);
        }

        /// <summary>
        ///     Promotes the order (change status).
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200.</returns>
        [HttpPost("Promote")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Promote(int id)
        {
            var managerId = await _queryFunctionality.GetAssignedManagerByOrderId(id);
            if (managerId.HasValue && !CheckPermissionsExtensions.UserHasPermissions(managerId.Value, User, UserRoles.Admin))
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }



            throw new NotImplementedException();
        }

        /// <summary>
        ///     Removes order.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 204.</returns>
        [HttpPost("Remove")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Remove(int id)
        {
            await _commandFunctionality.RemoveAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
