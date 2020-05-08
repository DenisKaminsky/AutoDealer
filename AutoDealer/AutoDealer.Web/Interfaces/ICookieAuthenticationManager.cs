using System.Threading.Tasks;
using AutoDealer.Business.Models.Responses.User;
using Microsoft.AspNetCore.Http;

namespace AutoDealer.Web.Interfaces
{
    public interface ICookieAuthenticationManager
    {
        Task SignInAsync(HttpContext httpContext, UserSignInModel user);
        Task SignOutAsync(HttpContext httpContext);
    }
}
