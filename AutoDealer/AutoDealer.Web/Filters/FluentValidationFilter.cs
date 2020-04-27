using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AutoDealer.Web.Filters
{
    public class FluentValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var validationErrors = context.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .SelectMany(x => x.Value.Errors, (property, error) => new ValidationFailure(property.Key, error.ErrorMessage))
                    .ToArray();

                throw new ValidationException("Validation errors occured", validationErrors);
            }

            await next();
        }
    }
}
