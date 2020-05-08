using System.Threading.Tasks;
using AutoDealer.Business.Models.Commands.User;
using AutoDealer.Business.Models.Responses.User;

namespace AutoDealer.Business.Interfaces.QueryFunctionality.User
{
    public interface IAccountQueryFunctionality
    {
        Task<UserSignInModel> GetSignInInfoAsync(LogInInfo logInCommand);
    }
}
