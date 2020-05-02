using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.Base
{
    public interface IBaseGenericCreateDeleteCommandFunctionality<in TCreateCommand>
        where TCreateCommand : ICreateCommand
    {
        Task AddAsync(TCreateCommand createCommand);

        Task RemoveAsync(int id);
    }
}
