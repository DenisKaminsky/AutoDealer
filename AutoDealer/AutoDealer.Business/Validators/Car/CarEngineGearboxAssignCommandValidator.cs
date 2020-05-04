using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace AutoDealer.Business.Validators.Car
{
    public class CarEngineGearboxAssignCommandValidator : BaseValidator<CarEngineGearboxAssignCommand>
    {
        private readonly ICarEngineFiltersProvider _engineFiltersProvider;
        private readonly IGearboxFiltersProvider _gearboxFiltersProvider;
        private readonly ICarModelFiltersProvider _modelFiltersProvider;
        private readonly IEngineSupportsGearboxFiltersProvider _engineSupportsGearboxFiltersProvider;

        public CarEngineGearboxAssignCommandValidator(IGenericReadRepository readRepository, ICarEngineFiltersProvider engineFiltersProvider, 
            IGearboxFiltersProvider gearboxFiltersProvider, ICarModelFiltersProvider modelFiltersProvider, 
            IEngineSupportsGearboxFiltersProvider engineSupportsGearboxFiltersProvider) : base(readRepository)
        {
            _engineFiltersProvider = engineFiltersProvider;
            _gearboxFiltersProvider = gearboxFiltersProvider;
            _modelFiltersProvider = modelFiltersProvider;
            _engineSupportsGearboxFiltersProvider = engineSupportsGearboxFiltersProvider;

            RuleFor(x => x.ModelId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(ModelExists);

            RuleFor(x => x.EngineId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(EngineExists);

            RuleFor(x => x.GearboxId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(GearboxExists);

            RuleFor(x => x.Price)
                .IsPositiveOrZeroWithMessage();
        }

        protected override bool PreValidate(ValidationContext<CarEngineGearboxAssignCommand> context, ValidationResult result)
        {
            var isExists = ReadRepository.ValidateExists(_engineSupportsGearboxFiltersProvider
                .ByModelEngineGearbox(context.InstanceToValidate.ModelId, context.InstanceToValidate.EngineId, context.InstanceToValidate.GearboxId));

            if (isExists)
            {
                result.Errors.Add(new ValidationFailure("", "Item is already assigned!"));
                return false;
            }
            return true;
        }

        private async Task<bool> ModelExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_modelFiltersProvider.ById(id)), cancellationToken);
        }

        private async Task<bool> EngineExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_engineFiltersProvider.ById(id)), cancellationToken);
        }

        private async Task<bool> GearboxExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_gearboxFiltersProvider.ById(id)), cancellationToken);
        }
    }
}
