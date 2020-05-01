using System.Threading.Tasks;
using AutoDealer.Business.Models.Commands.Miscellaneous;

namespace AutoDealer.Business.Interfaces.CommandFunctionality
{
    public interface IBrandCommandFunctionality
    {
        Task AddAsync(BrandCreateCommand brand);

        Task UpdateAsync(BrandUpdateCommand brand);

        Task RemoveAsync(int id);
    }
}
