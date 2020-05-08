using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.User;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.User;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Constraints.User;

namespace AutoDealer.Business.Validators.User
{
    public class ClientCreateCommandValidator : BaseValidator<ClientCreateCommand>
    {
        private readonly IClientFiltersProvider _clientFiltersProvider;

        public ClientCreateCommandValidator(IGenericReadRepository readRepository, IClientFiltersProvider clientFiltersProvider) : base(readRepository)
        {
            _clientFiltersProvider = clientFiltersProvider;

            RuleFor(x => x.FirstName)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(ClientConstraints.FirstNameMaxLength);

            RuleFor(x => x.LastName)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(ClientConstraints.LastNameMaxLength);

            When(x => x.Email != null, () =>
            {
                RuleFor(x => x.Email)
                    .MaxLengthWithMessage(ClientConstraints.EmailMaxLength)
                    .IsValidEmailWithMessage();
            });

            RuleFor(x => x.PassportId)
                .NotEmptyWithMessage()
                .MinLengthWithMessage(ClientConstraints.PassportIdMinLength)
                .MaxLengthWithMessage(ClientConstraints.PassportIdMaxLength)
                .MustNotExistWithMessageAsync(PassportIdDoesNotExist);

            RuleFor(x => x.Phone)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(ClientConstraints.PhoneMaxLength)
                .IsValidPhoneNumberWithMessage();

            RuleFor(x => x.Address)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(ClientConstraints.AddressMaxLength);
        }

        private async Task<bool> PassportIdDoesNotExist(string passportId, CancellationToken cancellationToken)
        {
            return await Task.Run(() => !ReadRepository.ValidateExists(_clientFiltersProvider.ByPassportId(passportId)), cancellationToken);
        }
    }
}
