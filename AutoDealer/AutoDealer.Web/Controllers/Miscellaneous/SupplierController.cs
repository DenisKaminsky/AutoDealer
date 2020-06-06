using System.Collections.Generic;
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
    public class SupplierController : BaseWebApiController
    {
        private readonly ISupplierQueryFunctionality _supplierQueryFunctionality;
        private readonly ISupplierCommandFunctionality _supplierCommandFunctionality;

        public SupplierController(IMapperFactory mapperFactory, ISupplierQueryFunctionality supplierQueryFunctionality, ISupplierCommandFunctionality supplierCommandFunctionality) : base(mapperFactory)
        {
            _supplierQueryFunctionality = supplierQueryFunctionality;
            _supplierCommandFunctionality = supplierCommandFunctionality;
        }

        /// <summary>
        ///     Gets all suppliers.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.SupplierManager) + "," + nameof(UserRoles.Director))]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.SupplierManager) + "," + nameof(UserRoles.Director))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var supplier = await _supplierQueryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<SupplierViewModel>(supplier));
        }

        /// <summary>
        ///     Gets supplier photo by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and file.</returns>
        [HttpGet("Photo/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPhotoById(int id)
        {
            var item = await _supplierQueryFunctionality.GetPhotoByIdAsync(id);
            return File(item.Content, "application/jpeg", $"{item.FileName}");
        }

        /// <summary>
        ///     Gets supplier by brand id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("ByBrand/{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.SupplierManager) + "," + nameof(UserRoles.Director))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByBrandId(int id)
        {
            var supplier = await _supplierQueryFunctionality.GetByBrandIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<SupplierViewModel>(supplier));
        }

        /// <summary>
        ///     Adds supplier
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost("Create")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.SupplierManager))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] SupplierCreateViewModel supplier)
        {
            var id = await _supplierCommandFunctionality.AddAsync(Mapper.Map<SupplierCreateCommand>(supplier));
            return ResponseWithData(StatusCodes.Status201Created, id);
        }

        /// <summary>
        ///     Adds supplier photo
        /// </summary>
        /// <returns>Status code 201 and photo id.</returns>
        [HttpPost("Photo/Add")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddPhoto(SupplierPhotoCreateViewModel item)
        {
            var itemId = await _supplierCommandFunctionality.AddPhotoAsync(Mapper.Map<SupplierPhotoCreateCommand>(item));
            return ResponseWithData(StatusCodes.Status201Created, itemId);
        }

        /// <summary>
        ///     Updates supplier 
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPut("Update")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.SupplierManager))]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.SupplierManager))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Remove(int id)
        {
            await _supplierCommandFunctionality.RemoveAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        /// <summary>
        ///     Removes supplier photo
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 204.</returns>
        [HttpDelete("Photo/Delete/{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemovePhoto(int id)
        {
            await _supplierCommandFunctionality.RemovePhotoAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
