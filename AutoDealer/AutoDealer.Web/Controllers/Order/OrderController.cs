using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Order;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.ViewModels.Response.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.Order
{
    public class OrderController : BaseWebApiController
    {
        private readonly IOrderQueryFunctionality _queryFunctionality;

        public OrderController(IMapperFactory mapperFactory, IOrderQueryFunctionality queryFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
        }

        /// <summary>
        ///     Gets all orders.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.SupplierManager))]
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
        [Authorize(nameof(UserRoles.Manager))]
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
        ///     Creates order.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpPost("Create")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Add()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Changes the order status.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpPost("ChangeStatus")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangeStatus()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Removes order.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpPost("Remove")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Remove()
        {
            throw new NotImplementedException();
        }
    }
}
