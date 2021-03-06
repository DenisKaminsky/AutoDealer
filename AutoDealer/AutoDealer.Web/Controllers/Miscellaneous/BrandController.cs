﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.Miscellaneous;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Miscellaneous;
using AutoDealer.Business.Models.Commands.Miscellaneous;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.ViewModels.Request.Miscellaneous;
using AutoDealer.Web.ViewModels.Response.Miscellaneous;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.Miscellaneous
{
    public class BrandController : BaseWebApiController
    {
        private readonly IBrandQueryFunctionality _brandQueryFunctionality;
        private readonly IBrandCommandFunctionality _brandCommandFunctionality;

        public BrandController(IMapperFactory mapperFactory, IBrandQueryFunctionality brandQueryFunctionality, 
            IBrandCommandFunctionality brandCommandFunctionality) : base(mapperFactory)
        {
            _brandQueryFunctionality = brandQueryFunctionality;
            _brandCommandFunctionality = brandCommandFunctionality;
        }

        /// <summary>
        ///     Gets all brands.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _brandQueryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<BrandViewModel>>(brands));
        }

        /// <summary>
        ///     Gets brands, that has supplier.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("WithSupplier")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWithSupplier()
        {
            var brands = await _brandQueryFunctionality.GetWithSupplierAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<BrandViewModel>>(brands));
        }

        /// <summary>
        ///     Gets brand by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var brand = await _brandQueryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<BrandViewModel>(brand));
        }

        /// <summary>
        ///     Gets brands by country id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("ByCountry/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByCountryId(int id)
        {
            var brands = await _brandQueryFunctionality.GetByCountryIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<BrandViewModel>>(brands));
        }

        /// <summary>
        ///     Adds brand
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost("Create")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] BrandCreateViewModel brand)
        {
            var id = await _brandCommandFunctionality.AddAsync(Mapper.Map<BrandCreateCommand>(brand));
            return ResponseWithData(StatusCodes.Status201Created, id);
        }
        
        /// <summary>
        ///     Updates brand 
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPut("Update")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] BrandUpdateViewModel brand)
        {
            await _brandCommandFunctionality.UpdateAsync(Mapper.Map<BrandUpdateCommand>(brand));
            return StatusCode(StatusCodes.Status200OK);
        }
        
        /// <summary>
        ///     Removes brand by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 204.</returns>
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Remove(int id)
        {
            await _brandCommandFunctionality.RemoveAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
