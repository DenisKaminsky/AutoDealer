using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Constraints.Car;

namespace AutoDealer.Business.Validators.Car
{
    public class CarEngineUpdateCommandValidator : BaseValidator<CarEngineUpdateCommand>
    {
        private readonly ICarEngineTypeFiltersProvider _engineTypeFiltersProvider;
        private readonly ICarEngineFiltersProvider _engineFiltersProvider;

        public CarEngineUpdateCommandValidator(IGenericReadRepository readRepository, ICarEngineTypeFiltersProvider engineTypeFiltersProvider, ICarEngineFiltersProvider engineFiltersProvider) : base(readRepository)
        {
            _engineTypeFiltersProvider = engineTypeFiltersProvider;
            _engineFiltersProvider = engineFiltersProvider;

            RuleFor(x => x.Id)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(EngineExists);

            RuleFor(x => x.Name)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(CarEngineConstraints.NameMaxLength);

            RuleFor(x => x.Volume)
                .IsPositiveOrZeroWithMessage();

            RuleFor(x => x.Power)
                .IsPositiveOrZeroWithMessage();

            RuleFor(x => x.Price)
                .IsPositiveOrZeroWithMessage();

            RuleFor(x => x.TypeId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(EngineTypeExists);
        }

        private async Task<bool> EngineTypeExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_engineTypeFiltersProvider.ById(id)), cancellationToken);
        }

        private async Task<bool> EngineExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_engineFiltersProvider.ById(id)), cancellationToken);
        }
    }
}
