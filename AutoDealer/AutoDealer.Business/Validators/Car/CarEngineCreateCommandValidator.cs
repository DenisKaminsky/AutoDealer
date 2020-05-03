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
    public class CarEngineCreateCommandValidator : BaseValidator<CarEngineCreateCommand>
    {
        private readonly ICarEngineTypeFiltersProvider _filtersProvider;

        public CarEngineCreateCommandValidator(IGenericReadRepository readRepository, ICarEngineTypeFiltersProvider filtersProvider) : base(readRepository)
        {
            _filtersProvider = filtersProvider;

            RuleFor(x => x.Name)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(CarEngineConstraints.NameMaxLength);

            RuleFor(x => x.Volume)
                .IsPositiveOrZeroWithMessage();

            RuleFor(x => x.Power)
                .IsPositiveOrZeroWithMessage();
            
            RuleFor(x => x.TypeId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(EngineTypeExists);
        }

        private async Task<bool> EngineTypeExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_filtersProvider.ById(id)), cancellationToken);
        }
    }
}
