using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.Base;
using AutoDealer.Business.Models.Commands.Miscellaneous;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.Miscellaneous
{
    public interface ISupplierCommandFunctionality 
        : IBaseGenericCreateUpdateDeleteCommandFunctionality<SupplierCreateCommand, SupplierUpdateCommand>
    {
        Task<int> AddPhotoAsync(SupplierPhotoCreateCommand createCommand);

        Task RemovePhotoAsync(int id);
    }
}
