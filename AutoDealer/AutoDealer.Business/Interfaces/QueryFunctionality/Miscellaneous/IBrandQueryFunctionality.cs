using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.QueryFunctionality.Base;
using AutoDealer.Business.Models.Responses.Miscellaneous;

namespace AutoDealer.Business.Interfaces.QueryFunctionality.Miscellaneous
{
    public interface IBrandQueryFunctionality : IGenericQueryFunctionality<BrandModel>
    {
        Task<IEnumerable<BrandModel>> GetWithSupplierAsync();
        Task<IEnumerable<BrandModel>> GetByCountryIdAsync(int countryId);
    }
}
