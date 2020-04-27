using System;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AutoDealer.Web.Middleware
{
    public class ExceptionsHandler : IMiddleware
    {
        private const string DefaultContentType = "application/json";
        private const string DefaultMessage = "Internal Server Error";
        private const int DefaultStatusCode = StatusCodes.Status500InternalServerError;

        private readonly ILogger _logger;

        public ExceptionsHandler(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(ExceptionsHandler));
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception: {0} | Message: {1} | StackTrace: {2}", ex.GetType().Name, ex.Message, ex.StackTrace);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = DefaultContentType;
            switch (exception)
            {
                case ValidationException validationException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    return context.Response.WriteAsync(JsonConvert.SerializeObject(validationException.Message));
                default:
                    context.Response.StatusCode = DefaultStatusCode;
                    return context.Response.WriteAsync(DefaultMessage);
            }
        }
    }

}
