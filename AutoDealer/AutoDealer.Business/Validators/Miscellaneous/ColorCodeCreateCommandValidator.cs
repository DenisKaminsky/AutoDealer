using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Miscellaneous;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Constraints.Car;

namespace AutoDealer.Business.Validators.Miscellaneous
{
    public class ColorCodeCreateCommandValidator : BaseValidator<ColorCodeCreateCommand>
    {
        private readonly IColorCodeFiltersProvider _filtersProvider;

        public ColorCodeCreateCommandValidator(IGenericReadRepository readRepository, IColorCodeFiltersProvider filtersProvider) : base(readRepository)
        {
            _filtersProvider = filtersProvider;

            RuleFor(x => x.Name)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(ColorCodeConstraints.NameMaxLength)
                .MustNotExistWithMessageAsync(NameDoesNotExist);

            RuleFor(x => x.HexValue)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(ColorCodeConstraints.HexValueLength)
                .IsValidHexColorCodeWithMessage();
        }

        private async Task<bool> NameDoesNotExist(string name, CancellationToken cancellationToken)
        {
            return await Task.Run(() => !ReadRepository.ValidateExists(_filtersProvider.ByName(name)), cancellationToken);
        }
    }
}
