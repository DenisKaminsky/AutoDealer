using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Constraints.Car;

namespace AutoDealer.Business.Validators.Car
{
    public class CarModelCreateCommandValidator : BaseValidator<CarModelCreateCommand>
    {
        private readonly IBrandFiltersProvider _brandFiltersProvider;

        public CarModelCreateCommandValidator(IGenericReadRepository readRepository, IBrandFiltersProvider brandFiltersProvider) : base(readRepository)
        {
            _brandFiltersProvider = brandFiltersProvider;

            RuleFor(x => x.Name)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(CarModelConstraints.NameMaxLength);

            RuleFor(x => x.Price)
                .IsPositiveWithMessage();

            RuleFor(x => x.BrandId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(BrandExists);
        }

        private async Task<bool> BrandExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_brandFiltersProvider.ById(id)), cancellationToken);
        }
    }
}
