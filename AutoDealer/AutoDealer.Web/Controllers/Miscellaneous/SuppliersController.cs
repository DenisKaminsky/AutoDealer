using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Miscellaneous;
using AutoDealer.Business.Models.Commands.Miscellaneous;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.ViewModels.Request.Miscellaneous;
using AutoDealer.Web.ViewModels.Response.Miscellaneous;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.Miscellaneous
{
    public class SuppliersController : BaseWebApiController
    {
        private readonly ISupplierQueryFunctionality _supplierQueryFunctionality;
        private readonly ISupplierCommandFunctionality _supplierCommandFunctionality;

        public SuppliersController(IMapperFactory mapperFactory, ISupplierQueryFunctionality supplierQueryFunctionality, ISupplierCommandFunctionality supplierCommandFunctionality) : base(mapperFactory)
        {
            _supplierQueryFunctionality = supplierQueryFunctionality;
            _supplierCommandFunctionality = supplierCommandFunctionality;
        }

        /// <summary>
        ///     Gets all suppliers.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = await _supplierQueryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<SupplierViewModel>>(suppliers));
        }

        /// <summary>
        ///     Gets supplier by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var supplier = await _supplierQueryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<SupplierViewModel>(supplier));
        }

        /// <summary>
        ///     Gets supplier by brand id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("ByBrand/{id}")]
        public async Task<IActionResult> GetByBrandId(int id)
        {
            var supplier = await _supplierQueryFunctionality.GetByBrandIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<SupplierViewModel>(supplier));
        }

        /// <summary>
        ///     Adds supplier
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SupplierCreateViewModel supplier)
        {
            await _supplierCommandFunctionality.AddAsync(Mapper.Map<SupplierCreateCommand>(supplier));
            return StatusCode(StatusCodes.Status201Created);
        }


        /// <summary>
        ///     Updates supplier 
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SupplierUpdateViewModel supplier)
        {
            await _supplierCommandFunctionality.UpdateAsync(Mapper.Map<SupplierUpdateCommand>(supplier));
            return StatusCode(StatusCodes.Status200OK);
        }


        /// <summary>
        ///     Removes supplier by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 204.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _supplierCommandFunctionality.RemoveAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
