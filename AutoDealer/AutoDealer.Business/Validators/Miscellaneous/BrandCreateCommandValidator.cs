using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Miscellaneous;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Miscellaneous.Constraints.Miscellaneous;

namespace AutoDealer.Business.Validators.Miscellaneous
{
    public class BrandCreateCommandValidator : BaseValidator<BrandCreateCommand>
    {
        private readonly IBrandFiltersProvider _filtersProvider;

        public BrandCreateCommandValidator(IGenericReadRepository readRepository, IBrandFiltersProvider filtersProvider) : base(readRepository)
        {
            _filtersProvider = filtersProvider;

            RuleFor(x => x.Name)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(BrandConstraints.NameMaxLength)
                .MustNotExistWithMessageAsync(NameDoesNotExist);

            RuleFor(x => x.CountryId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(CountryExists);
        }

        private async Task<bool> NameDoesNotExist(string name, CancellationToken cancellationToken)
        {
            return await Task.Run(() => !ReadRepository.ValidateExists(_filtersProvider.ByName(name)), cancellationToken);
        }

        private async Task<bool> CountryExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists<Country>(x => x.Id == id), cancellationToken);
        }
    }
}
