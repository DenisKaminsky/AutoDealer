using AutoDealer.Business.Interfaces.CommandFunctionality.Base;
using AutoDealer.Business.Models.Commands.Car;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.Car
{
    public interface ICarStockCommandFunctionality : IBaseGenericCreateUpdateDeleteCommandFunctionality<CarStockCreateCommand, CarStockUpdateCommand>
    {
    }
}
