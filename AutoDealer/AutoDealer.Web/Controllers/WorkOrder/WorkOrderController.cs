﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.WorkOrder;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.WorkOrder;
using AutoDealer.Business.Models.Commands.WorkOrder;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.Extensions;
using AutoDealer.Web.ViewModels.Request.WorkOrder;
using AutoDealer.Web.ViewModels.Response.WorkOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.WorkOrder
{
    public class WorkOrderController : BaseWebApiController
    {
        private readonly IWorkOrderQueryFunctionality _queryFunctionality;
        private readonly IWorkOrderCommandFunctionality _commandFunctionality;

        public WorkOrderController(IMapperFactory mapperFactory, IWorkOrderQueryFunctionality queryFunctionality, IWorkOrderCommandFunctionality commandFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
            _commandFunctionality = commandFunctionality;
        }

        /// <summary>
        ///     Gets all work orders.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.ServiceMan))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var items = await _queryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<WorkOrderViewModel>>(items));
        }

        /// <summary>
        ///     Gets work orders, created by current authorized user.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("ByCurrentUser")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.ServiceMan))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByCurrentUser()
        {
            var items = await _queryFunctionality.GetByWorkerIdAsync(Convert.ToInt32(User.Claims.First(c => c.Type == "Id").Value));
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<WorkOrderViewModel>>(items));
        }

        /// <summary>
        ///     Gets work orders by user id (admin only).
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("ByUser/{id}")]
        [Authorize(nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByUserId(int id)
        {
            var items = await _queryFunctionality.GetByWorkerIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<WorkOrderViewModel>>(items));
        }

        /// <summary>
        ///     Gets work order by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.ServiceMan))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _queryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<WorkOrderViewModel>(item));
        }

        /// <summary>
        ///     Adds work order (admin only)
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost("Admin")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] WorkOrderCreateAdminViewModel item)
        {
            await _commandFunctionality.AddAsync(Mapper.Map<WorkOrderCreateCommand>(item));
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Adds work order by current authorized user.
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.ServiceMan))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] WorkOrderCreateViewModel item)
        {
            var command = Mapper.Map<WorkOrderCreateCommand>(item);
            command.WorkerId = Convert.ToInt32(User.Claims.First(c => c.Type == "Id").Value);

            await _commandFunctionality.AddAsync(command);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Completes work order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>Status code 200.</returns>
        [HttpPut("Complete")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.ServiceMan))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Complete(int orderId)
        {
            var order = await _queryFunctionality.GetByIdAsync(orderId);
            if (!CheckPermissionsExtensions.CanCompleteWorkOrder(order.Worker.Id, User, UserRoles.Admin))
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }

            await _commandFunctionality.CompleteAsync(orderId);
            return StatusCode(StatusCodes.Status200OK);
        }

        /// <summary>
        ///     Removes work order by id
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