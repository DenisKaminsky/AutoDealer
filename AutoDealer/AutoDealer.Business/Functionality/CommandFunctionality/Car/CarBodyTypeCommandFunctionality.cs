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
using AutoDealer.Miscellaneous.Exceptions;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.Car
{
    public class CarBodyTypeCommandFunctionality 
        : BaseGenericCreateDeleteCommandFunctionality<CarBodyTypeCreateCommand, CarBodyType>, ICarBodyTypeCommandFunctionality
    {
        private readonly IGenericReadRepository _readRepository;
        private readonly IModelSupportsBodyTypeFiltersProvider _filtersProvider;

        public CarBodyTypeCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, 
            IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory, IGenericReadRepository readRepository, IModelSupportsBodyTypeFiltersProvider filtersProvider) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
            _readRepository = readRepository;
            _filtersProvider = filtersProvider;
        }

        public override async Task RemoveAsync(int id)
        {
            var isRemoved = await WriteRepository.RemoveByIdAsync<CarBodyType>(id);

            if (!isRemoved)
                throw new NotFoundException("Item was not found!");

            await UnitOfWork.CommitAsync();
        }

        public async Task AssignAsync(CarBodyTypeAssignCommand assignCommand)
        {
            await ValidatorFactory.GetValidator<CarBodyTypeAssignCommand>().ValidateAndThrowAsync(assignCommand);

            await WriteRepository.AddAsync(Mapper.Map<ModelSupportsBodyType>(assignCommand));
            await UnitOfWork.CommitAsync();
        }

        public async Task UnassignAsync(CarBodyTypeUnassignCommand unassignCommand)
        {
            var itemsToRemove = await _readRepository.GetAsync(_filtersProvider.ByModelIdAndBodyTypeId(unassignCommand.ModelId, unassignCommand.BodyTypeId));

            await WriteRepository.RemoveRangeAsync(itemsToRemove);
            await UnitOfWork.CommitAsync();
        }
    }
}
