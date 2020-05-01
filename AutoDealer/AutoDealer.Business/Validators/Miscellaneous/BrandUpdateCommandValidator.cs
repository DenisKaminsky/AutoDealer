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
    public class BrandUpdateCommandValidator : BaseValidator<BrandUpdateCommand>
    {
        private readonly IBrandFiltersProvider _filtersProvider;

        public BrandUpdateCommandValidator(IGenericReadRepository readRepository, IBrandFiltersProvider filtersProvider) : base(readRepository)
        {
            _filtersProvider = filtersProvider;
            
            RuleFor(x => x.Name)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(BrandConstraints.NameMaxLength)
                .MustNotExistWithMessageAsync(NameDoesNotExist);
            
            RuleFor(x => x.CountryId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(IsValidId);
        }

        private async Task<bool> NameDoesNotExist(BrandUpdateCommand command, CancellationToken cancellationToken)
        {
            var brand = await ReadRepository.GetSingleAsync(_filtersProvider.OthersWithName(command.Id, command.Name));
            return brand == null;
        }

        private async Task<bool> IsValidId(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateIdExists<Country>(id), cancellationToken);
        }
    }
}
