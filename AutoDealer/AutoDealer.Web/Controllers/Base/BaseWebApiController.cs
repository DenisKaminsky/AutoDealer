using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Web.Attributes;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    public abstract class BaseWebApiController
    {
        protected readonly IMapper Mapper;

        protected BaseWebApiController(IMapperFactory mapperFactory)
        {
            Mapper = mapperFactory.GetMapper(nameof(WebServices));
        }
    }
}
