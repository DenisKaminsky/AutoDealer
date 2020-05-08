﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.Car;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Car;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.ViewModels.Request.Car;
using AutoDealer.Web.ViewModels.Response.Car;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.Car
{
    public class GearboxController : BaseWebApiController
    {
        private readonly IGearboxCommandFunctionality _commandFunctionality;
        private readonly IGearboxQueryFunctionality _queryFunctionality;

        public GearboxController(IMapperFactory mapperFactory, IGearboxCommandFunctionality commandFunctionality, IGearboxQueryFunctionality queryFunctionality) : base(mapperFactory)
        {
            _commandFunctionality = commandFunctionality;
            _queryFunctionality = queryFunctionality;
        }

        /// <summary>
        ///     Gets all gearboxes.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var gearboxes = await _queryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<GearboxViewModel>>(gearboxes));
        }

        /// <summary>
        ///     Gets gearbox by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var gearbox = await _queryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<GearboxViewModel>(gearbox));
        }

        /// <summary>
        ///     Adds gearbox
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] GearboxCreateViewModel gearbox)
        {
            await _commandFunctionality.AddAsync(Mapper.Map<GearboxCreateCommand>(gearbox));
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Removes gearbox by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 204.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Remove(int id)
        {
            await _commandFunctionality.RemoveAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
