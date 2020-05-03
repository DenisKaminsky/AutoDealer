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
using AutoDealer.Miscellaneous.Exceptions;

namespace AutoDealer.Business.Functionality.QueryFunctionality.Car
{
    public class CarBodyTypeQueryFunctionality : BaseQueryFunctionality, ICarBodyTypeQueryFunctionality
    {
        private readonly ICarBodyTypeFiltersProvider _bodyTypeFiltersProvider;
        private readonly IModelSupportsBodyTypeFiltersProvider _modelBodyTypeFiltersProvider;
        private readonly IModelSupportsBodyTypeRelationsProvider _relationsProvider;

        public CarBodyTypeQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, 
            ICarBodyTypeFiltersProvider bodyTypeFiltersProvider, IModelSupportsBodyTypeFiltersProvider modelBodyTypeFiltersProvider, 
            IModelSupportsBodyTypeRelationsProvider relationsProvider) : base(unitOfWork, mapperFactory, readRepository)
        {
            _bodyTypeFiltersProvider = bodyTypeFiltersProvider;
            _modelBodyTypeFiltersProvider = modelBodyTypeFiltersProvider;
            _relationsProvider = relationsProvider;
        }

        public async Task<IEnumerable<CarBodyTypeModel>> GetAllAsync()
        {
            var carBodyTypes = await ReadRepository.GetAllAsync<CarBodyType>();
            return Mapper.Map<IEnumerable<CarBodyTypeModel>>(carBodyTypes);
        }

        public async Task<CarBodyTypeModel> GetByIdAsync(int id)
        {
            var carModel = await ReadRepository.GetSingleAsync(_bodyTypeFiltersProvider.ById(id));

            if (carModel == null)
                throw new NotFoundException("Car body type was not found!");

            return Mapper.Map<CarBodyTypeModel>(carModel);
        }

        public async Task<IEnumerable<CarBodyTypeWithPriceModel>> GetByModelIdAsync(int id)
        {
            var modelSupportsBodyTypes = await ReadRepository.GetAsync(_modelBodyTypeFiltersProvider.ByModelId(id), _relationsProvider.JoinBodyType);

            return Mapper.Map<IEnumerable<CarBodyTypeWithPriceModel>>(modelSupportsBodyTypes);
        }
    }
}
