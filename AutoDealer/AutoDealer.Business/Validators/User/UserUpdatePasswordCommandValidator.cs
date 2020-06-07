using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.User;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.User;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Constraints.User;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace AutoDealer.Business.Validators.User
{
    public class UserUpdatePasswordCommandValidator : BaseValidator<UserUpdatePasswordCommand>
    {
        private readonly IUserFiltersProvider _userFiltersProvider;

        public UserUpdatePasswordCommandValidator(IGenericReadRepository readRepository, IUserFiltersProvider userFiltersProvider) : base(readRepository)
        {
            _userFiltersProvider = userFiltersProvider;

            RuleFor(x => x.UserId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(UserExists)
                .DependentRules(() =>
                {
                    When(x => !string.IsNullOrWhiteSpace(x.OldPasswordHash), () =>
                    {
                        RuleFor(x => x.OldPasswordHash)
                            .MustAsync(OldPasswordIsValid)
                            .WithMessage("Old password is invalid");
                    });
                });

            RuleFor(x => x.OldPasswordHash)
                .NotEmptyWithMessage();

            RuleFor(x => x.NewPasswordHash)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(UserConstraints.PasswordHashLength)
                .IsValidMD5HashWithMessage();
        }

        private async Task<bool> UserExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_userFiltersProvider.ActiveById(id)), cancellationToken);
        }

        private async Task<bool> OldPasswordIsValid(UserUpdatePasswordCommand model, string password, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_userFiltersProvider.ActiveByIdAndPassword(model.UserId, model.OldPasswordHash)), cancellationToken);
        }
    }
}
