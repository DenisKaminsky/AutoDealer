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
    public class UserUpdateCommandValidator : BaseValidator<UserUpdateCommand>
    {
        private readonly IUserFiltersProvider _userFiltersProvider;

        public UserUpdateCommandValidator(IGenericReadRepository readRepository, IUserFiltersProvider userFiltersProvider) : base(readRepository)
        {
            _userFiltersProvider = userFiltersProvider;

            RuleFor(x => x.Id)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(UserExists);

            RuleFor(x => x.FirstName)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(UserConstraints.FirstNameMaxLength);

            RuleFor(x => x.LastName)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(UserConstraints.LastNameMaxLength);

            RuleFor(x => x.Phone)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(UserConstraints.PhoneMaxLength)
                .IsValidPhoneNumberWithMessage();

            RuleFor(x => x.Salary)
                .IsPositiveOrZeroWithMessage();
        }

        private async Task<bool> UserExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_userFiltersProvider.ById(id)), cancellationToken);
        }
    }
}
