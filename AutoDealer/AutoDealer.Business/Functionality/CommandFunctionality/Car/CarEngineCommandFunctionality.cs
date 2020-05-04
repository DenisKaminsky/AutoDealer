using System.Threading.Tasks;
using AutoDealer.Business.Functionality.CommandFunctionality.Base;
using AutoDealer.Business.Interfaces.CommandFunctionality.Car;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.Models.Car.Relations;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.Car
{
    public class CarEngineCommandFunctionality 
        : BaseGenericCreateUpdateDeleteCommandFunctionality<CarEngineCreateCommand, CarEngineUpdateCommand, CarEngine>, ICarEngineCommandFunctionality
    {
        private readonly IGenericReadRepository _readRepository;
        private readonly IEngineSupportsGearboxFiltersProvider _engineGearboxFiltersProvider;

        public CarEngineCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository, 
            IValidatorFactory validatorFactory, IGenericReadRepository readRepository, IEngineSupportsGearboxFiltersProvider engineGearboxFiltersProvider) 
            : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
            _readRepository = readRepository;
            _engineGearboxFiltersProvider = engineGearboxFiltersProvider;
        }

        public async Task AssignAsync(CarEngineGearboxAssignCommand assignCommand)
        {
            await ValidatorFactory.GetValidator<CarEngineGearboxAssignCommand>().ValidateAndThrowAsync(assignCommand);

            await WriteRepository.AddAsync(Mapper.Map<EngineSupportsGearbox>(assignCommand));
            await UnitOfWork.CommitAsync();
        }

        public async Task UnassignAsync(CarEngineGearboxUnassignCommand unassignCommand)
        {
            var itemsToRemove = await _readRepository.GetAsync(
                _engineGearboxFiltersProvider.ByModelEngineGearbox(unassignCommand.ModelId, unassignCommand.EngineId, unassignCommand.GearboxId));

            await WriteRepository.RemoveRangeAsync(itemsToRemove);
            await UnitOfWork.CommitAsync();
        }
    }
}
