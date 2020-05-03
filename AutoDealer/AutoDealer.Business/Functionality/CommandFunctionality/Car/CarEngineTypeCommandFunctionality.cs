using AutoDealer.Business.Functionality.CommandFunctionality.Base;
using AutoDealer.Business.Interfaces.CommandFunctionality.Car;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Car;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.Car
{
    public class CarEngineTypeCommandFunctionality : BaseGenericCreateDeleteCommandFunctionality<CarEngineTypeCreateCommand, CarEngineType>, 
        ICarEngineTypeCommandFunctionality
    {
        public CarEngineTypeCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, 
            IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
        }
    }
}
