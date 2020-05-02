using System.Threading.Tasks;
using AutoDealer.Business.Models.Commands.Miscellaneous;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.Miscellaneous
{
    public interface ICountryCommandFunctionality
    {
        Task AddAsync(CountryCreateCommand country);

        Task UpdateAsync(CountryUpdateCommand country);

        Task RemoveAsync(int id);
    }
}
