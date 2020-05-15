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
    public class DeliveryRequestController : BaseWebApiController
    {
        private readonly IDeliveryRequestQueryFunctionality _queryFunctionality;

        public DeliveryRequestController(IMapperFactory mapperFactory, IDeliveryRequestQueryFunctionality queryFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
        }

        /// <summary>
        ///     Gets all delivery requests.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.SupplierManager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var items = await _queryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<DeliveryRequestViewModel>>(items));
        }

        /// <summary>
        ///     Gets delivery requests, assigned to current user (for SupplierManager).
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("BySupplierManager/Current")]
        [Authorize(nameof(UserRoles.SupplierManager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBySupplierManager()
        {
            var items = await _queryFunctionality.GetBySupplierManagerAsync(Convert.ToInt32(User.Claims.First(c => c.Type == "Id").Value));
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<DeliveryRequestViewModel>>(items));
        }

        /// <summary>
        ///     Gets delivery requests, assigned to user (for Admin).
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("BySupplierManager/{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBySupplierManager(int id)
        {
            var items = await _queryFunctionality.GetBySupplierManagerAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<DeliveryRequestViewModel>>(items));
        }

        /// <summary>
        ///     Gets delivery requests, created by current user (for Manager).
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("ByManager/Current")]
        [Authorize(nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByManager()
        {
            var items = await _queryFunctionality.GetByManagerAsync(Convert.ToInt32(User.Claims.First(c => c.Type == "Id").Value));
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<DeliveryRequestViewModel>>(items));
        }

        /// <summary>
        ///     Gets delivery requests, created by user (for Admin).
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("ByManager/{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByManager(int id)
        {
            var items = await _queryFunctionality.GetByManagerAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<DeliveryRequestViewModel>>(items));
        }

        /// <summary>
        ///     Gets delivery request by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.SupplierManager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _queryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<DeliveryRequestViewModel>(item));
        }
    }
}
