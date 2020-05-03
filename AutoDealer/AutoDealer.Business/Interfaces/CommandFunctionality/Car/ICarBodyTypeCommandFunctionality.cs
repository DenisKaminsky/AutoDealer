using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.Base;
using AutoDealer.Business.Models.Commands.Car;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.Car
{
    public interface ICarBodyTypeCommandFunctionality : IBaseGenericCreateDeleteCommandFunctionality<CarBodyTypeCreateCommand>
    {
        Task AssignAsync(CarBodyTypeAssignCommand assignCommand);

        Task UnassignAsync(CarBodyTypeUnassignCommand unassignCommand);
    }
}
