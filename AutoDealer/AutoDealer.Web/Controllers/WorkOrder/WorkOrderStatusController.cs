using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.WorkOrder;
using AutoDealer.Web.Controllers.Base;
using AutoDealer.Web.ViewModels.Response.WorkOrder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.WorkOrder
{
    public class WorkOrderStatusController: BaseWebApiController
    {
        private readonly IWorkOrderStatusQueryFunctionality _queryFunctionality;

        public WorkOrderStatusController(IMapperFactory mapperFactory, IWorkOrderStatusQueryFunctionality queryFunctionality) : base(mapperFactory)
        {
            _queryFunctionality = queryFunctionality;
        }

        /// <summary>
        ///     Gets all work order statuses.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var items = await _queryFunctionality.GetAllAsync();
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<IEnumerable<WorkOrderStatusViewModel>>(items));
        }

        /// <summary>
        ///     Gets work order status by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _queryFunctionality.GetByIdAsync(id);
            return ResponseWithData(StatusCodes.Status200OK, Mapper.Map<WorkOrderStatusViewModel>(item));
        }
    }
}
