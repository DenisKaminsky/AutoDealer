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
    public class CountryController: BaseWebApiController
    {
        private readonly ICountryQueryFunctionality _countryQueryFunctionality;
        private readonly ICountryCommandFunctionality _countryCommandFunctionality;

        public CountryController(IMapperFactory mapperFactory, ICountryQueryFunctionality countryQueryFunctionality,
            ICountryCommandFunctionality countryCommandFunctionality) : base(mapperFactory)
        {
            _countryQueryFunctionality = countryQueryFunctionality;
            _countryCommandFunctionality = countryCommandFunctionality;
        }

        /// <summary>
        ///     Gets all countries.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var country = await _countryQueryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<CountryViewModel>(country));
        }

        /// <summary>
        ///     Adds country
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] CountryCreateViewModel country)
        {
            await _countryCommandFunctionality.AddAsync(Mapper.Map<CountryCreateCommand>(country));
            return StatusCode(StatusCodes.Status201Created);
        }


        /// <summary>
        ///     Updates country 
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPut]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] CountryUpdateViewModel country)
        {
            await _countryCommandFunctionality.UpdateAsync(Mapper.Map<CountryUpdateCommand>(country));
            return StatusCode(StatusCodes.Status200OK);
        }


        /// <summary>
        ///     Removes country by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 204.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(UserRoles.Admin))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Remove(int id)
        {
            await _countryCommandFunctionality.RemoveAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
