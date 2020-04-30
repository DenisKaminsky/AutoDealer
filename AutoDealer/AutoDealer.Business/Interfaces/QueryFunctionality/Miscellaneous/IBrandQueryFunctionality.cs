using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Models.Responses.Miscellaneous;

namespace AutoDealer.Business.Interfaces.QueryFunctionality.Miscellaneous
{
    public interface IBrandQueryFunctionality
    {
        Task<IEnumerable<BrandModel>> GetAllAsync();
        Task<IEnumerable<BrandModel>> GetByCountryIdAsync(int countryId);
        Task<BrandModel> GetByIdAsync(int id);
    }
}
