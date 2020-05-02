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
    public class SupplierCreateCommandValidator : BaseValidator<SupplierCreateCommand>
    {
        private readonly ISupplierFiltersProvider _filtersProvider;

        public SupplierCreateCommandValidator(IGenericReadRepository readRepository, ISupplierFiltersProvider filtersProvider) : base(readRepository)
        {
            _filtersProvider = filtersProvider;

            RuleFor(x => x.CompanyName)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(SupplierConstraints.CompanyNameMaxLength);

            RuleFor(x => x.Ein)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(SupplierConstraints.EinMaxLength)
                .IsValidEinWithMessage()
                .MustNotExistWithMessageAsync(EinDoesNotExist);

            RuleFor(x => x.Phone)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(SupplierConstraints.PhoneMaxLength)
                .IsValidPhoneNumberWithMessage();

            RuleFor(x => x.Email)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(SupplierConstraints.EmailMaxLength)
                .IsValidEmailWithMessage();

            RuleFor(x => x.Address)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(SupplierConstraints.AddressMaxLength);

            RuleFor(x => x.BrandId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(BrandExists);
        }

        private async Task<bool> EinDoesNotExist(string ein, CancellationToken cancellationToken)
        {
            return await Task.Run(() => !ReadRepository.ValidateExists(_filtersProvider.ByEin(ein)), cancellationToken);
        }

        private async Task<bool> BrandExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists<Brand>(x => x.Id == id), cancellationToken);
        }
    }
}
