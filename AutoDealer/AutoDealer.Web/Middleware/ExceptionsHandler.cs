using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoDealer.Miscellaneous.Exceptions;
using AutoDealer.Web.ViewModels.Base;
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
            int statusCode;
            var executionErrors = new List<Error>();
            switch (exception)
            {
                case ValidationException validationException:
                    statusCode = StatusCodes.Status400BadRequest;
                    executionErrors.AddRange(validationException.Errors.Select(x => new Error {ErrorCode = x.PropertyName, ErrorMessage = x.ErrorMessage}));
                    break;
                case NotFoundException notFoundException:
                    statusCode = StatusCodes.Status404NotFound;
                    executionErrors.Add(new Error { ErrorCode = "NOT_FOUND", ErrorMessage = notFoundException.Message });
                    break;
                default:
                    statusCode = DefaultStatusCode;
                    executionErrors.Add(new Error { ErrorCode = "INTERNAL_SERVER_ERROR", ErrorMessage = DefaultMessage });
                    break;
            }

            context.Response.ContentType = DefaultContentType;
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new StatusResponseWithErrors
            {
                IsSuccess = false, 
                Errors = executionErrors
            }));
        }
    }

}
