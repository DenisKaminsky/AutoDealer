using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoDealer.Business.Functionality.QueryFunctionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Miscellaneous;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Responses.Miscellaneous;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Interfaces.RelationsProviders.Car;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Miscellaneous;

namespace AutoDealer.Business.Functionality.QueryFunctionality.Miscellaneous
{
    public class ColorCodeQueryFunctionality : BaseGenericQueryFunctionality<ColorCodeModel, ColorCode>, IColorCodeQueryFunctionality
    {
        private readonly IModelSupportsColorFiltersProvider _modelColorFiltersProvider;
        private readonly IModelSupportsColorRelationsProvider _modelColorRelationsProvider;

        public ColorCodeQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, 
            IColorCodeFiltersProvider colorCodeFiltersProvider, IModelSupportsColorFiltersProvider modelColorFiltersProvider,
            IModelSupportsColorRelationsProvider modelColorRelationsProvider) : base(unitOfWork, mapperFactory, readRepository, colorCodeFiltersProvider)
        {
            _modelColorFiltersProvider = modelColorFiltersProvider;
            _modelColorRelationsProvider = modelColorRelationsProvider;
        }
        
        public async Task<IEnumerable<ColorCodeModel>> GetByModelIdAsync(int id)
        {
            var modelSupportsColor = await ReadRepository.GetAsync(_modelColorFiltersProvider.ByModelId(id), _modelColorRelationsProvider.JoinColor);

            return Mapper.Map<IEnumerable<ColorCodeModel>>(modelSupportsColor.Select(x => x.Color));
        }
    }
}
