using System.Threading.Tasks;
using AutoDealer.Business.Functionality.CommandFunctionality.Base;
using AutoDealer.Business.Interfaces.CommandFunctionality.Miscellaneous;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Business.Models.Commands.Miscellaneous;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Car.Relations;
using AutoDealer.Data.Models.Miscellaneous;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.Miscellaneous
{
    public class ColorCodeCommandFunctionality : BaseGenericCreateDeleteCommandFunctionality<ColorCodeCreateCommand, ColorCode>, IColorCodeCommandFunctionality
    {
        private readonly IGenericReadRepository _readRepository;
        private readonly IModelSupportsColorFiltersProvider _modelColorFiltersProvider;

        public ColorCodeCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory, IGenericReadRepository readRepository, IModelSupportsColorFiltersProvider modelColorFiltersProvider) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
            _readRepository = readRepository;
            _modelColorFiltersProvider = modelColorFiltersProvider;
        }

        public async Task AssignAsync(CarColorAssignmentCommand assignCommand)
        {
            await ValidatorFactory.GetValidator<CarColorAssignmentCommand>().ValidateAndThrowAsync(assignCommand);

            await WriteRepository.AddAsync(Mapper.Map<ModelSupportsColor>(assignCommand));
            await UnitOfWork.CommitAsync();
        }

        public async Task UnassignAsync(CarColorAssignmentCommand unassignCommand)
        {
            var itemsToRemove = await _readRepository.GetAsync(_modelColorFiltersProvider.ByModelIdAndColorId(unassignCommand.ModelId, unassignCommand.ColorId));

            await WriteRepository.RemoveRangeAsync(itemsToRemove);
            await UnitOfWork.CommitAsync();
        }
    }
}
