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
    public class CarEngineTypeController : BaseWebApiController
    {
        private readonly ICarEngineTypeQueryFunctionality _queryFunctionality;
        private readonly ICarEngineTypeCommandFunctionality _commandFunctionality;

        public CarEngineTypeController(IMapperFactory mapperFactory, ICarEngineTypeQueryFunctionality queryFunctionality, ICarEngineTypeCommandFunctionality commandFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
            _commandFunctionality = commandFunctionality;
        }

        /// <summary>
        ///     Gets all car engine types.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var engineTypes = await _queryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<CarEngineTypeViewModel>>(engineTypes));
        }

        /// <summary>
        ///     Gets car engine type by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var carEngineType = await _queryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<CarEngineTypeViewModel>(carEngineType));
        }
        
        /// <summary>
        ///     Adds car engine type
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CarEngineTypeCreateViewModel engineType)
        {
            await _commandFunctionality.AddAsync(Mapper.Map<CarEngineTypeCreateCommand>(engineType));
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Removes car engine type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 204.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _commandFunctionality.RemoveAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}