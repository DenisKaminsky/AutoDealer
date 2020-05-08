using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.User;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.User;
using AutoDealer.Data.Interfaces.Repositories;

namespace AutoDealer.Business.Validators.User
{
    public class UserUpdateActiveStatusCommandValidator : BaseValidator<UserUpdateActiveStatusCommand>
    {
        private readonly IUserFiltersProvider _userFiltersProvider;

        public UserUpdateActiveStatusCommandValidator(IGenericReadRepository readRepository, IUserFiltersProvider userFiltersProvider) : base(readRepository)
        {
            _userFiltersProvider = userFiltersProvider;

            RuleFor(x => x.UserId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(UserExists);
        }

        private async Task<bool> UserExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_userFiltersProvider.ById(id)), cancellationToken);
        }
    }
}
