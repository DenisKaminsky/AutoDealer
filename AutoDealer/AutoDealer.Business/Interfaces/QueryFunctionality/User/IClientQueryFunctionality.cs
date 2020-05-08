using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.QueryFunctionality.Base;
using AutoDealer.Business.Models.Responses.User;

namespace AutoDealer.Business.Interfaces.QueryFunctionality.User
{
    public interface IClientQueryFunctionality : IGenericQueryFunctionality<ClientModel>
    {
        Task<ClientModel> GetByPassportIdAsync(string passportId);
    }
}
