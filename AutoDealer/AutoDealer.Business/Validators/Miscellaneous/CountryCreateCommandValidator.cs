using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Miscellaneous;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Constraints.Miscellaneous;

namespace AutoDealer.Business.Validators.Miscellaneous
{
    public class CountryCreateCommandValidator : BaseValidator<CountryCreateCommand>
    {
        private readonly ICountryFiltersProvider _filtersProvider;

        public CountryCreateCommandValidator(IGenericReadRepository readRepository, ICountryFiltersProvider filtersProvider) : base(readRepository)
        {
            _filtersProvider = filtersProvider;

            RuleFor(x => x.Name)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(CountryConstraints.NameMaxLength)
                .MustNotExistWithMessageAsync(NameDoesNotExist);
        }

        private async Task<bool> NameDoesNotExist(string name, CancellationToken cancellationToken)
        {
            return await Task.Run(() => !ReadRepository.ValidateExists(_filtersProvider.ByName(name)),cancellationToken);
        }
    }
}
