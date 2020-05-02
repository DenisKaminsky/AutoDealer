using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Models.Responses.Miscellaneous;

namespace AutoDealer.Business.Interfaces.QueryFunctionality.Miscellaneous
{
    public interface ISupplierQueryFunctionality
    {
        Task<IEnumerable<SupplierModel>> GetAllAsync();

        Task<SupplierModel> GetByIdAsync(int id);

        Task<SupplierModel> GetByBrandIdAsync(int id);
    }
}
