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
    public class UserCreateCommandValidator : BaseValidator<UserCreateCommand>
    {
        private readonly IUserRoleFiltersProvider _roleFiltersProvider;
        private readonly IUserFiltersProvider _userFiltersProvider;

        public UserCreateCommandValidator(IGenericReadRepository readRepository, IUserRoleFiltersProvider roleFiltersProvider, IUserFiltersProvider userFiltersProvider) : base(readRepository)
        {
            _roleFiltersProvider = roleFiltersProvider;
            _userFiltersProvider = userFiltersProvider;

            RuleFor(x => x.FirstName)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(UserConstraints.FirstNameMaxLength);

            RuleFor(x => x.LastName)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(UserConstraints.LastNameMaxLength);

            RuleFor(x => x.Email)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(UserConstraints.EmailMaxLength)
                .IsValidEmailWithMessage()
                .MustNotExistWithMessageAsync(EmailDoesNotExists);

            RuleFor(x => x.PasswordHash)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(UserConstraints.PasswordHashLength);

            RuleFor(x => x.Phone)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(UserConstraints.PhoneMaxLength)
                .IsValidPhoneNumberWithMessage();

            RuleFor(x => x.Salary)
                .IsPositiveOrZeroWithMessage();

            RuleFor(x => x.RoleId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(RoleExists);
        }
        private async Task<bool> EmailDoesNotExists(string email, CancellationToken cancellationToken)
        {
            return await Task.Run(() => !ReadRepository.ValidateExists(_userFiltersProvider.ByEmail(email)), cancellationToken);
        }

        private async Task<bool> RoleExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_roleFiltersProvider.ById(id)), cancellationToken);
        }
    }
}
