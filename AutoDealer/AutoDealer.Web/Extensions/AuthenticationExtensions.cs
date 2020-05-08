using System.Threading.Tasks;
using AutoDealer.Web.Interfaces;
using AutoDealer.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AutoDealer.Web.Extensions
{
    public static class AuthenticationExtensions
    {
        public static void AddCookieAuthentication(this IServiceCollection collection)
        {
            collection.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.Events = new CookieAuthenticationEvents()
                    {
                        OnRedirectToAccessDenied = redirectContext =>
                        {
                            redirectContext.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                            return Task.CompletedTask;
                        },
                        OnRedirectToLogin = redirectContext =>
                        {
                            redirectContext.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            return Task.CompletedTask;
                        }
                    };
                });
            collection.AddScoped<ICookieAuthenticationManager, CookieAuthenticationManager>();
        }
    }
}
