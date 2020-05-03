using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Exceptions;

namespace AutoDealer.Business.Functionality.QueryFunctionality.Base
{
    public abstract class BaseGenericQueryFunctionality<TResponse, TDataModel> : BaseQueryFunctionality
        where TResponse : BaseModel
        where TDataModel : Data.Models.Base.BaseModel
    {
        private readonly IBaseFiltersProvider<TDataModel> _filtersProvider;

        protected BaseGenericQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory,
            IGenericReadRepository readRepository, IBaseFiltersProvider<TDataModel> filtersProvider) : base(unitOfWork, mapperFactory, readRepository)
        {
            _filtersProvider = filtersProvider;
        }

        public virtual async Task<IEnumerable<TResponse>> GetAllAsync()
        {
            var items = await ReadRepository.GetAllAsync<TDataModel>();
            return Mapper.Map<IEnumerable<TResponse>>(items);
        }

        public virtual async Task<TResponse> GetByIdAsync(int id)
        {
            var item = await ReadRepository.GetSingleAsync(_filtersProvider.ById(id));

            if (item == null)
                throw new NotFoundException("Item was not found!");

            return Mapper.Map<TResponse>(item);
        }
    }
}
