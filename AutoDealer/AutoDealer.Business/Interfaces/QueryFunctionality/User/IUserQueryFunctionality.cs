using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.QueryFunctionality.Base;
using AutoDealer.Business.Models.Responses.User;

namespace AutoDealer.Business.Interfaces.QueryFunctionality.User
{
    public interface IUserQueryFunctionality : IGenericQueryFunctionality<UserModel>
    {
        Task<IEnumerable<UserModel>> GetAllActiveAsync();
        Task<UserModel> GetActiveByIdAsync(int id);
    }
}
