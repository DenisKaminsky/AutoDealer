using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.Car;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Car;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.ViewModels.Request.Car;
using AutoDealer.Web.ViewModels.Response.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.Car
{
    public class CarStockController : BaseWebApiController
    {
        private readonly ICarStockQueryFunctionality _queryFunctionality;
        private readonly ICarStockCommandFunctionality _commandFunctionality;

        public CarStockController(IMapperFactory mapperFactory, ICarStockQueryFunctionality queryFunctionality, ICarStockCommandFunctionality commandFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
            _commandFunctionality = commandFunctionality;
        }

        /// <summary>
        ///     Gets all cars in stock.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var items = await _queryFunctionality.GetAllInStockAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<CarStockViewModel>>(items));
        }

        /// <summary>
        ///     Gets car by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _queryFunctionality.GetInStockByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<CarStockViewModel>(item));
        }

        /// <summary>
        ///     Gets car photo by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and file.</returns>
        [HttpGet("Photo/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPhotoById(int id)
        {
            var item = await _queryFunctionality.GetPhotoByIdAsync(id);
            return File(item.Content, "application/jpeg", $"{item.FileName}");
        }

        /// <summary>
        ///     Gets main car photo by model, color, body type.
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="colorId"></param>
        /// <param name="bodyTypeId"></param>
        /// <returns>Status code 200 and file.</returns>
        [HttpGet("Photo/Main/{modelId}_{colorId}_{bodyTypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPhotoByModelColorBodyType(int modelId, int colorId, int bodyTypeId)
        {
            var item = await _queryFunctionality.GetFirstPhotoByModelColorBodyTypeAsync(modelId, colorId, bodyTypeId);
            return File(item.Content, "application/jpeg", $"{item.FileName}");
        }

        /// <summary>
        ///     Registers car in stock. If car exists, it will return the id of existing car
        /// </summary>
        /// <returns>Status code 201 and car id.</returns>
        [HttpPost("Create")]
        [Authorize(Roles = nameof(UserRoles.Admin) + "," + nameof(UserRoles.Manager))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] CarStockCreateViewModel item)
        {
            var carId = await _commandFunctionality.AddAsync(Mapper.Map<CarStockCreateCommand>(item));
            return ResponseWithData(StatusCodes.Status201Created, carId);
        }

        /// <summary>
        ///     Adds car photo
        /// </summary>
        /// <returns>Status code 201 and photo id.</returns>
        [HttpPost("Photo/Add")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddPhoto(CarPhotoCreateViewModel item)
        {
            var itemId = await _commandFunctionality.AddPhotoAsync(Mapper.Map<CarPhotoCreateCommand>(item));
            return ResponseWithData(StatusCodes.Status201Created, itemId);
        }

        /// <summary>
        ///     Updates car in stock
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPut("Update")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] CarStockUpdateViewModel item)
        {
            await _commandFunctionality.UpdateAsync(Mapper.Map<CarStockUpdateCommand>(item));
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Removes car from stock
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 204.</returns>
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Remove(int id)
        {
            await _commandFunctionality.RemoveAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        /// <summary>
        ///     Removes car photo
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 204.</returns>
        [HttpDelete("Photo/Delete/{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemovePhoto(int id)
        {
            await _commandFunctionality.RemovePhotoAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
