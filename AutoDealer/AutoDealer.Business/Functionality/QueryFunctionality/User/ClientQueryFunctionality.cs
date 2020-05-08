using System.Threading.Tasks;
using AutoDealer.Business.Functionality.QueryFunctionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.User;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Responses.User;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.User;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.User;
using AutoDealer.Miscellaneous.Exceptions;

namespace AutoDealer.Business.Functionality.QueryFunctionality.User
{
    public class ClientQueryFunctionality : BaseGenericQueryFunctionality<ClientModel, Client>, IClientQueryFunctionality
    {
        private readonly IClientFiltersProvider _clientFiltersProvider;

        public ClientQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, IBaseFiltersProvider<Client> filtersProvider, IClientFiltersProvider clientFiltersProvider) : base(unitOfWork, mapperFactory, readRepository, filtersProvider)
        {
            _clientFiltersProvider = clientFiltersProvider;
        }

        public async Task<ClientModel> GetByPassportIdAsync(string passportId)
        {
            var item = await ReadRepository.GetSingleAsync(_clientFiltersProvider.ByPassportId(passportId));

            if (item == null)
                throw new NotFoundException("Item was not found!");

            return Mapper.Map<ClientModel>(item);
        }
    }
}
