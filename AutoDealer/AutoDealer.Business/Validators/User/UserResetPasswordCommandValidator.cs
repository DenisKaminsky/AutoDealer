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
    public class UserResetPasswordCommandValidator : BaseValidator<UserResetPasswordCommand>
    {
        private readonly IUserFiltersProvider _userFiltersProvider;

        public UserResetPasswordCommandValidator(IGenericReadRepository readRepository, IUserFiltersProvider userFiltersProvider) : base(readRepository)
        {
            _userFiltersProvider = userFiltersProvider;

            RuleFor(x => x.UserId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(UserExists);

            RuleFor(x => x.NewPasswordHash)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(UserConstraints.PasswordHashLength)
                .IsValidMD5HashWithMessage();
        }

        private async Task<bool> UserExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_userFiltersProvider.ById(id)), cancellationToken);
        }
    }
}
