using System.Threading.Tasks;
using AutoDealer.Business.Functionality.CommandFunctionality.Base;
using AutoDealer.Business.Interfaces.CommandFunctionality.User;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.User;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.User;
using AutoDealer.Data.Interfaces.Repositories;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.User
{
    public class AccountCommandFunctionality : BaseGenericCreateDeleteCommandFunctionality<UserCreateCommand, Data.Models.User.User>, IAccountCommandFunctionality
    {
        private readonly IGenericReadRepository _readRepository;
        private readonly IUserFiltersProvider _userFiltersProvider;

        public AccountCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory, IGenericReadRepository readRepository, IUserFiltersProvider userFiltersProvider) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
            _readRepository = readRepository;
            _userFiltersProvider = userFiltersProvider;
        }

        public async Task UpdateAsync(UserUpdateCommand command)
        {
            await ValidatorFactory.GetValidator<UserUpdateCommand>().ValidateAndThrowAsync(command);

            var user = await _readRepository.GetSingleAsync(_userFiltersProvider.ById(command.Id));
            user.FirstName = command.FirstName;
            user.LastName = command.LastName;
            user.Phone = command.Phone;
            user.Birthday = command.Birthday;
            user.Salary = command.Salary;

            await WriteRepository.UpdateAsync(user);
            await UnitOfWork.CommitAsync();
        }

        public async Task UpdateActiveStatusAsync(UserUpdateActiveStatusCommand command)
        {
            await ValidatorFactory.GetValidator<UserUpdateActiveStatusCommand>().ValidateAndThrowAsync(command);

            var user = await _readRepository.GetSingleAsync(_userFiltersProvider.ById(command.UserId));
            user.IsActive = command.IsActive;

            await WriteRepository.UpdateAsync(user);
            await UnitOfWork.CommitAsync();
        }

        public async Task UpdatePasswordAsync(UserUpdatePasswordCommand command)
        {
            await ValidatorFactory.GetValidator<UserUpdatePasswordCommand>().ValidateAndThrowAsync(command);

            var user = await _readRepository.GetSingleAsync(_userFiltersProvider.ById(command.UserId));
            user.PasswordHash = command.NewPasswordHash;

            await WriteRepository.UpdateAsync(user);
            await UnitOfWork.CommitAsync();
        }

        public async Task ResetPasswordAsync(UserResetPasswordCommand command)
        {
            await ValidatorFactory.GetValidator<UserResetPasswordCommand>().ValidateAndThrowAsync(command);

            var user = await _readRepository.GetSingleAsync(_userFiltersProvider.ById(command.UserId));
            user.PasswordHash = command.NewPasswordHash;

            await WriteRepository.UpdateAsync(user);
            await UnitOfWork.CommitAsync();
        }
    }
}
