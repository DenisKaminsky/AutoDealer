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
    public class CarModelController : BaseWebApiController
    {
        private readonly ICarModelQueryFunctionality _carModelQueryFunctionality;
        private readonly ICarModelCommandFunctionality _carModelCommandFunctionality;

        public CarModelController(IMapperFactory mapperFactory, ICarModelQueryFunctionality carModelQueryFunctionality, 
            ICarModelCommandFunctionality carModelCommandFunctionality) : base(mapperFactory)
        {
            _carModelQueryFunctionality = carModelQueryFunctionality;
            _carModelCommandFunctionality = carModelCommandFunctionality;
        }

        /// <summary>
        ///     Gets all car models.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var carModels = await _carModelQueryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<CarModelViewModel>>(carModels));
        }

        /// <summary>
        ///     Gets car model by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var carModel = await _carModelQueryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<CarModelViewModel>(carModel));
        }

        /// <summary>
        ///     Gets car model by brand id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("ByBrand/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByBrandId(int id)
        {
            var carModels = await _carModelQueryFunctionality.GetByBrandIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<CarModelViewModel>>(carModels));
        }

        /// <summary>
        ///     Adds car model
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost("Create")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] CarModelCreateViewModel carModel)
        {
            await _carModelCommandFunctionality.AddAsync(Mapper.Map<CarModelCreateCommand>(carModel));
            return StatusCode(StatusCodes.Status201Created);
        }
        
        /// <summary>
        ///     Updates car model 
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPut("Update")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] CarModelUpdateViewModel carModel)
        {
            await _carModelCommandFunctionality.UpdateAsync(Mapper.Map<CarModelUpdateCommand>(carModel));
            return StatusCode(StatusCodes.Status200OK);
        }


        /// <summary>
        ///     Removes car model by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 204.</returns>
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Remove(int id)
        {
            await _carModelCommandFunctionality.RemoveAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
