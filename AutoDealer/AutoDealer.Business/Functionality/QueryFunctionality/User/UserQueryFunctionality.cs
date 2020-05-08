using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Functionality.QueryFunctionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.User;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Responses.User;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.User;
using AutoDealer.Data.Interfaces.RelationsProviders.User;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Exceptions;

namespace AutoDealer.Business.Functionality.QueryFunctionality.User
{
    public class UserQueryFunctionality : BaseQueryFunctionality, IUserQueryFunctionality
    {
        private readonly IUserFiltersProvider _filtersProvider;
        private readonly IUserRelationsProvider _relationsProvider;

        public UserQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, IUserFiltersProvider filtersProvider, IUserRelationsProvider relationsProvider) : base(unitOfWork, mapperFactory, readRepository)
        {
            _filtersProvider = filtersProvider;
            _relationsProvider = relationsProvider;
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var users = await ReadRepository.GetAllAsync<Data.Models.User.User>(_relationsProvider.JoinRole);
            return Mapper.Map<IEnumerable<UserModel>>(users);
        }

        public async Task<IEnumerable<UserModel>> GetAllActiveAsync()
        {
            var users = await ReadRepository.GetAsync(_filtersProvider.Active(), _relationsProvider.JoinRole);
            return Mapper.Map<IEnumerable<UserModel>>(users);
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            var user = await ReadRepository.GetSingleAsync(_filtersProvider.ById(id), _relationsProvider.JoinRole);

            if (user == null)
                throw new NotFoundException("Item was not found!");

            return Mapper.Map<UserModel>(user);
        }

        public async Task<UserModel> GetActiveByIdAsync(int id)
        {
            var user = await ReadRepository.GetSingleAsync(_filtersProvider.ActiveById(id), _relationsProvider.JoinRole);

            if (user == null)
                throw new NotFoundException("Item was not found!");

            return Mapper.Map<UserModel>(user);
        }
    }
}
