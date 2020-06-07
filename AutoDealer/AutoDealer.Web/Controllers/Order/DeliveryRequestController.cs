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
using AutoDealer.Web.ViewModels.Response.Miscellaneous;
using AutoDealer.Web.ViewModels.Response.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.Order
{
    public class DeliveryRequestController : BaseWebApiController
    {
        private readonly IDeliveryRequestQueryFunctionality _queryFunctionality;
        private readonly IDeliveryRequestCommandFunctionality _commandFunctionality;

        public DeliveryRequestController(IMapperFactory mapperFactory, IDeliveryRequestQueryFunctionality queryFunctionality, IDeliveryRequestCommandFunctionality commandFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
            _commandFunctionality = commandFunctionality;
        }

        /// <summary>
        ///     Gets all delivery requests (for admin).
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var items = await _queryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<DeliveryRequestViewModel>>(items));
        }

        /// <summary>
        ///     Gets delivery request statistics.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("Statistics")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Director))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStatistics()
        {
            var items = await _queryFunctionality.GetStatisticsForLastDays(30);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<StatisticsDateCountViewModel>>(items));
        }

        /// <summary>
        ///     Gets all opened delivery requests.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("Opened")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.SupplierManager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllOpened()
        {
            var items = await _queryFunctionality.GetByStatusIdAsync((int)DeliveryRequestStatuses.Opened);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<DeliveryRequestViewModel>>(items));
        }

        /// <summary>
        ///     Gets delivery requests, assigned to current user (for SupplierManager).
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("BySupplierManager/Current")]
        [Authorize(Roles = nameof(UserRoles.SupplierManager))]
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
        [Authorize(Roles = nameof(UserRoles.Manager))]
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
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.SupplierManager) + "," + nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _queryFunctionality.GetByIdAsync(id);
            if ((item.SupplierManager == null || !CheckPermissionsExtensions.UserHasPermissions(item.SupplierManager.Id, User, UserRoles.Admin)) 
                && !CheckPermissionsExtensions.UserHasPermissions(item.Manager.Id, User, UserRoles.Admin))
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<DeliveryRequestViewModel>(item));
        }

        /// <summary>
        ///     Creates delivery request (for Admin).
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost("Create/Admin")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] DeliveryRequestCreateAdminViewModel request)
        {
            var id = await _commandFunctionality.AddAsync(Mapper.Map<DeliveryRequestCreateCommand>(request));
            return ResponseWithData(StatusCodes.Status201Created, id);
        }

        /// <summary>
        ///     Creates delivery request (for Manager).
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost("Create")]
        [Authorize(Roles = nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] DeliveryRequestCreateViewModel request)
        {
            var command = Mapper.Map<DeliveryRequestCreateCommand>(request);
            command.ManagerId = Convert.ToInt32(User.Claims.First(c => c.Type == "Id").Value);

            var id = await _commandFunctionality.AddAsync(command);
            return ResponseWithData(StatusCodes.Status201Created, id);
        }

        /// <summary>
        ///     Assigns delivery request to supplier manager (for Admin).
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPost("Assign/Admin")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Assign([FromBody] DeliveryRequestAssignAdminViewModel request)
        {
            await _commandFunctionality.AssignAsync(Mapper.Map<DeliveryRequestAssignCommand>(request));
            return StatusCode(StatusCodes.Status200OK);
        }

        /// <summary>
        ///     Assigns delivery request to supplier manager (for SupplierManager).
        /// </summary>
        /// <param name="deliveryRequestId"></param>
        /// <returns>Status code 200.</returns>
        [HttpPost("Assign")]
        [Authorize(Roles = nameof(UserRoles.SupplierManager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Assign(int deliveryRequestId)
        {
            var userId = Convert.ToInt32(User.Claims.First(c => c.Type == "Id").Value);
            await _commandFunctionality.AssignAsync(new DeliveryRequestAssignCommand
            {
                DeliveryRequestId = deliveryRequestId,
                SupplierManagerId = userId
            });

            return StatusCode(StatusCodes.Status200OK);
        }

        /// <summary>
        ///     Promote the delivery request (change status).
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpPost("Promote")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.SupplierManager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Promote(int id)
        {
            var supplierManagerId = await _queryFunctionality.GetAssignedSupplierManagerByDeliveryRequestId(id);
            if (supplierManagerId.HasValue && !CheckPermissionsExtensions.UserHasPermissions(supplierManagerId.Value, User, UserRoles.Admin))
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            await _commandFunctionality.Promote(new DeliveryRequestPromoteCommand {DeliveryRequestId = id});
            return StatusCode(StatusCodes.Status200OK);
        }

        /// <summary>
        ///     Removes delivery request by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 204</returns>
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
