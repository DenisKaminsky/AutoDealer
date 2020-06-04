﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.Order;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Order;
using AutoDealer.Business.Models.Commands.Order;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.ViewModels.Request.Order;
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
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.SupplierManager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _queryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<DeliveryRequestViewModel>(item));
        }

        /// <summary>
        ///     Creates delivery request (for Admin).
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpPost("Create/Admin")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add(DeliveryRequestCreateAdminViewModel item)
        {
            await _commandFunctionality.AddAsync(Mapper.Map<DeliveryRequestCreateCommand>(item));
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Creates delivery request (for Manager).
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpPost("Create")]
        [Authorize(Roles = nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add(DeliveryRequestCreateViewModel item)
        {
            var command = Mapper.Map<DeliveryRequestCreateCommand>(item);
            command.ManagerId = Convert.ToInt32(User.Claims.First(c => c.Type == "Id").Value);

            await _commandFunctionality.AddAsync(command);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Assigns delivery request to supplier manager.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpPost("Assign")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Add()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Changes the delivery request status.
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
        ///     Removes delivery request by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpPost("Remove")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Remove(int id)
        {
            await _commandFunctionality.RemoveAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
