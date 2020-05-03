using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoDealer.Business.Interfaces.QueryFunctionality.Base
{
    public interface IGenericQueryFunctionality<TResponse>
    {
        Task<IEnumerable<TResponse>> GetAllAsync();

        Task<TResponse> GetByIdAsync(int id);
    }
}
