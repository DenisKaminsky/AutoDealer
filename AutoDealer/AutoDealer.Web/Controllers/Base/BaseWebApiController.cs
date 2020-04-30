using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Web.Attributes;
using AutoDealer.Web.ViewModels.Base;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.Base
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    public abstract class BaseWebApiController : ControllerBase
    {
        protected readonly IMapper Mapper;

        protected BaseWebApiController(IMapperFactory mapperFactory)
        {
            Mapper = mapperFactory.GetMapper(nameof(WebServices));
        }

        protected ObjectResult ResponseWithData(int statusCode, object response)
        {
            return base.StatusCode(statusCode, new StatusResponseWithData { IsSuccess = true, Data = response });
        }
    }
}
