using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Web.Attributes;
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
            //write custom object
            return base.StatusCode(statusCode, response);
        }
    }
}
