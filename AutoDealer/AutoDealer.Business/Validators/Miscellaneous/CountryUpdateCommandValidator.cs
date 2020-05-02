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
    public class CountryUpdateCommandValidator : BaseValidator<CountryUpdateCommand>
    {
        private readonly ICountryFiltersProvider _filtersProvider;

        public CountryUpdateCommandValidator(IGenericReadRepository readRepository, ICountryFiltersProvider filtersProvider) : base(readRepository)
        {
            _filtersProvider = filtersProvider;

            RuleFor(x => x.Id)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(CountryExists);

            RuleFor(x => x.Name)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(CountryConstraints.NameMaxLength)
                .MustNotExistWithMessageAsync(NameDoesNotExist);
        }

        private async Task<bool> CountryExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_filtersProvider.ById(id)), cancellationToken);
        }

        private async Task<bool> NameDoesNotExist(CountryUpdateCommand command, CancellationToken cancellationToken)
        {
            return await Task.Run(() => !ReadRepository.ValidateExists(_filtersProvider.OthersWithName(command.Id, command.Name)), cancellationToken);
        }
    }
}
