using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Order;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.ViewModels.Response.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.Order
{
    public class DeliveryRequestStatusController : BaseWebApiController
    {
        private readonly IDeliveryRequestStatusQueryFunctionality _queryFunctionality;

        public DeliveryRequestStatusController(IMapperFactory mapperFactory, IDeliveryRequestStatusQueryFunctionality queryFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
        }

        /// <summary>
        ///     Gets all delivery request statuses.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var items = await _queryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<DeliveryRequestStatusViewModel>>(items));
        }

        /// <summary>
        ///     Gets delivery request status by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _queryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<DeliveryRequestStatusViewModel>(item));
        }
    }
}
