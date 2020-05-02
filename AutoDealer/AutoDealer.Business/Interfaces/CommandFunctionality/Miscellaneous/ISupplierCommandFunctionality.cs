using System.Threading.Tasks;
using AutoDealer.Business.Models.Commands.Miscellaneous;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.Miscellaneous
{
    public interface ISupplierCommandFunctionality
    {
        Task AddAsync(SupplierCreateCommand supplier);
        Task UpdateAsync(SupplierUpdateCommand supplier);
        Task RemoveAsync(int id);
    }
}
