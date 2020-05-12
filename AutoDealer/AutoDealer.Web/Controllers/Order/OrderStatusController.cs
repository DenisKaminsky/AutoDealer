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
    public class OrderStatusController : BaseWebApiController
    {
        private readonly IOrderStatusQueryFunctionality _queryFunctionality;

        public OrderStatusController(IMapperFactory mapperFactory, IOrderStatusQueryFunctionality queryFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
        }

        /// <summary>
        ///     Gets all order statuses.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var items = await _queryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<OrderStatusViewModel>>(items));
        }

        /// <summary>
        ///     Gets order status by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _queryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<OrderStatusViewModel>(item));
        }
    }
}
