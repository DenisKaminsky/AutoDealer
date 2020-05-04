using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.Base;
using AutoDealer.Business.Models.Commands.Car;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.Car
{
    public interface ICarEngineCommandFunctionality 
        : IBaseGenericCreateUpdateDeleteCommandFunctionality<CarEngineCreateCommand, CarEngineUpdateCommand>
    {
        Task AssignAsync(CarEngineGearboxAssignCommand assignCommand);
        Task UnassignAsync(CarEngineGearboxUnassignCommand unassignCommand);
    }
}
