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
    public class ClientUpdateCommandValidator : BaseValidator<ClientUpdateCommand>
    {
        private readonly IClientFiltersProvider _clientFiltersProvider;

        public ClientUpdateCommandValidator(IGenericReadRepository readRepository, IClientFiltersProvider clientFiltersProvider) : base(readRepository)
        {
            _clientFiltersProvider = clientFiltersProvider;

            RuleFor(x => x.Id)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(ClientExists);

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

        private async Task<bool> ClientExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_clientFiltersProvider.ById(id)), cancellationToken);
        }

        private async Task<bool> PassportIdDoesNotExist(ClientUpdateCommand client, CancellationToken cancellationToken)
        {
            return await Task.Run(() => !ReadRepository.ValidateExists(_clientFiltersProvider.OthersWithPassportId(client.Id, client.PassportId)), cancellationToken);
        }
    }
}
