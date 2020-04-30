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
    public class CountriesController: BaseWebApiController
    {
        private readonly ICountryQueryFunctionality _countryQueryFunctionality;

        public CountriesController(IMapperFactory mapperFactory, ICountryQueryFunctionality countryQueryFunctionality) : base(mapperFactory)
        {
            _countryQueryFunctionality = countryQueryFunctionality;
        }

        /// <summary>
        ///     Gets all countries.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _countryQueryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<CountryViewModel>>(countries));
        }

        /// <summary>
        ///     Gets country by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var country = await _countryQueryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<CountryViewModel>(country));
        }
    }
}
