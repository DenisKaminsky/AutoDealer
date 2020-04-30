using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Models.Responses.Miscellaneous;

namespace AutoDealer.Business.Interfaces.QueryFunctionality.Miscellaneous
{
    public interface ICountryQueryFunctionality
    {
        Task<IEnumerable<CountryModel>> GetAllAsync();
        Task<CountryModel> GetByIdAsync(int id);
    }
}
