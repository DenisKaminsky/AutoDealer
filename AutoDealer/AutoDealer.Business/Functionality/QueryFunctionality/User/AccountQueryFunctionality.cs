using System;
using System.Threading.Tasks;
using AutoDealer.Business.Functionality.QueryFunctionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.User;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.User;
using AutoDealer.Business.Models.Responses.User;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.User;
using AutoDealer.Data.Interfaces.RelationsProviders.User;
using AutoDealer.Data.Interfaces.Repositories;

namespace AutoDealer.Business.Functionality.QueryFunctionality.User
{
    public class AccountQueryFunctionality : BaseQueryFunctionality, IAccountQueryFunctionality
    {
        private readonly IUserFiltersProvider _userFiltersProvider;
        private readonly IUserRelationsProvider _userRelationsProvider;

        public AccountQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, IUserFiltersProvider userFiltersProvider, IUserRelationsProvider userRelationsProvider) : base(unitOfWork, mapperFactory, readRepository)
        {
            _userFiltersProvider = userFiltersProvider;
            _userRelationsProvider = userRelationsProvider;
        }

        public async Task<UserSignInModel> GetSignInInfoAsync(LogInInfo logInCommand)
        {
            var user = await ReadRepository.GetSingleAsync(_userFiltersProvider.ActiveByEmail(logInCommand.Email), _userRelationsProvider.JoinRole);

            return user != null && user.PasswordHash.Equals(logInCommand.PasswordHash, StringComparison.OrdinalIgnoreCase)
                ? Mapper.Map<UserSignInModel>(user)
                : null;
        }
    }
}
