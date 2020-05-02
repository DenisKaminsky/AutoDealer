using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.Base
{
    public interface IBaseGenericCreateUpdateDeleteCommandFunctionality<in TCreateCommand, in TUpdateCommand> : IBaseGenericCreateDeleteCommandFunctionality<TCreateCommand>
        where TCreateCommand : ICreateCommand
        where TUpdateCommand : IUpdateCommand
    {
        Task UpdateAsync(TUpdateCommand updateCommand);
    }
}
