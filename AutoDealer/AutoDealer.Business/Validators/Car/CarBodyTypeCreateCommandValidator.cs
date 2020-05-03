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
    public class CarBodyTypeCreateCommandValidator : BaseValidator<CarBodyTypeCreateCommand>
    {
        private readonly ICarBodyTypeFiltersProvider _filtersProvider;

        public CarBodyTypeCreateCommandValidator(IGenericReadRepository readRepository, ICarBodyTypeFiltersProvider filtersProvider) : base(readRepository)
        {
            _filtersProvider = filtersProvider;

            RuleFor(x => x.Name)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(CarBodyTypeConstraints.NameMaxLength)
                .MustNotExistWithMessageAsync(NameDoesNotExist);
        }

        private async Task<bool> NameDoesNotExist(string name, CancellationToken cancellationToken)
        {
            return await Task.Run(() => !ReadRepository.ValidateExists(_filtersProvider.ByName(name)), cancellationToken);
        }
    }
}
