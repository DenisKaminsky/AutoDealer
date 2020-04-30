using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Miscellaneous;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.ViewModels.Response.Miscellaneous;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.Miscellaneous
{
    public class BrandsController : BaseWebApiController
    {
        private readonly IBrandQueryFunctionality _brandQueryFunctionality;

        public BrandsController(IMapperFactory mapperFactory, IBrandQueryFunctionality brandQueryFunctionality) : base(mapperFactory)
        {
            _brandQueryFunctionality = brandQueryFunctionality;
        }

        /// <summary>
        ///     Gets all brands.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _brandQueryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<BrandViewModel>>(brands));
        }

        /// <summary>
        ///     Gets brand by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
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
        public async Task<IActionResult> GetByCountryId(int id)
        {
            var brands = await _brandQueryFunctionality.GetByCountryIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<BrandViewModel>>(brands));
        }
    }
}
