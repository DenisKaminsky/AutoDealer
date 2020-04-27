using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AutoDealer.Web.Attributes
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public LogFilterAttribute(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(LogFilterAttribute));
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var ipAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();
            var controllerName = context.Controller.GetType().Name;
            var actionName = context.ActionDescriptor.DisplayName;
            var actionArguments = context.ActionArguments
                                      .Select(i => $"{i.Key}: {i.Value}")
                                      .DefaultIfEmpty(null)
                                      .Aggregate((result, current) => $"{result}|{current}") ?? string.Empty;

            _logger.LogInformation("{0} - Executing {1} from {2} with: {3}", ipAddress, controllerName, actionName, actionArguments);
        }
    }

}
