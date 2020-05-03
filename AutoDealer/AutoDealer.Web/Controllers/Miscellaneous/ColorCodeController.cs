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
    public class ColorCodeController : BaseWebApiController
    {
        private readonly IColorCodeQueryFunctionality _queryFunctionality;

        public ColorCodeController(IMapperFactory mapperFactory, IColorCodeQueryFunctionality queryFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
        }

        /// <summary>
        ///     Gets all color codes.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var colorCodes = await _queryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<ColorCodeViewModel>>(colorCodes));
        }

        /// <summary>
        ///     Gets color code by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var colorCode = await _queryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<ColorCodeViewModel>(colorCode));
        }
    }
}
