using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Functionality.QueryFunctionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Car;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Responses.Car;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.RelationsProviders.Car;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Car;

namespace AutoDealer.Business.Functionality.QueryFunctionality.Car
{
    public class CarBodyTypeQueryFunctionality : BaseGenericQueryFunctionality<CarBodyTypeModel, CarBodyType>, ICarBodyTypeQueryFunctionality
    {
        private readonly IModelSupportsBodyTypeFiltersProvider _modelBodyTypeFiltersProvider;
        private readonly IModelSupportsBodyTypeRelationsProvider _relationsProvider;

        public CarBodyTypeQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, 
            ICarBodyTypeFiltersProvider bodyTypeFiltersProvider, IModelSupportsBodyTypeFiltersProvider modelBodyTypeFiltersProvider, 
            IModelSupportsBodyTypeRelationsProvider relationsProvider) : base(unitOfWork, mapperFactory, readRepository, bodyTypeFiltersProvider)
        {
            _modelBodyTypeFiltersProvider = modelBodyTypeFiltersProvider;
            _relationsProvider = relationsProvider;
        }
        
        public async Task<IEnumerable<CarBodyTypeWithPriceModel>> GetByModelIdAsync(int id)
        {
            var modelSupportsBodyTypes = await ReadRepository.GetAsync(_modelBodyTypeFiltersProvider.ByModelId(id), _relationsProvider.JoinBodyType);

            return Mapper.Map<IEnumerable<CarBodyTypeWithPriceModel>>(modelSupportsBodyTypes);
        }
    }
}
