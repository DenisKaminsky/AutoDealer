using Microsoft.AspNetCore.Builder;

namespace AutoDealer.Web.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void UseSwaggerMiddleware(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/V1/swagger.json", "AutoDealer V1"));
        }
    }
}
