using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace AutoDealer.Web.Extensions
{
    public static class FluentValidationExtensions
    {
        public static void AddFluentValidation(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(x =>
            {
                x.RegisterValidatorsFromAssemblyContaining<Startup>();
                x.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });
        }
    }
}
