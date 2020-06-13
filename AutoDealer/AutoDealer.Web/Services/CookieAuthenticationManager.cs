using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoDealer.Business.Models.Responses.User;
using AutoDealer.Web.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace AutoDealer.Web.Services
{
    public class CookieAuthenticationManager : ICookieAuthenticationManager
    {
        public Task SignInAsync(HttpContext httpContext, UserSignInModel user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.Name),
                new Claim("Id", user.Id.ToString()),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, 
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(2),
            };

            return httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);
        }

        public Task SignOutAsync(HttpContext httpContext)
        {
            return httpContext.SignOutAsync();
        }
    }
}
