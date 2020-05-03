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
using AutoDealer.Miscellaneous.Exceptions;

namespace AutoDealer.Business.Functionality.QueryFunctionality.Miscellaneous
{
    public class ColorCodeQueryFunctionality : BaseQueryFunctionality, IColorCodeQueryFunctionality
    {
        private readonly IColorCodeFiltersProvider _colorCodeFiltersProvider;
        private readonly IModelSupportsColorFiltersProvider _modelColorFiltersProvider;
        private readonly IModelSupportsColorRelationsProvider _modelColorRelationsProvider;

        public ColorCodeQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, IColorCodeFiltersProvider colorCodeFiltersProvider, IModelSupportsColorFiltersProvider modelColorFiltersProvider, IModelSupportsColorRelationsProvider modelColorRelationsProvider) : base(unitOfWork, mapperFactory, readRepository)
        {
            _colorCodeFiltersProvider = colorCodeFiltersProvider;
            _modelColorFiltersProvider = modelColorFiltersProvider;
            _modelColorRelationsProvider = modelColorRelationsProvider;
        }

        public async Task<IEnumerable<ColorCodeModel>> GetAllAsync()
        {
            var colorCodes = await ReadRepository.GetAllAsync<ColorCode>();
            return Mapper.Map<IEnumerable<ColorCodeModel>>(colorCodes);
        }

        public async Task<ColorCodeModel> GetByIdAsync(int id)
        {
            var colorCode = await ReadRepository.GetSingleAsync(_colorCodeFiltersProvider.ById(id));

            if (colorCode == null)
                throw new NotFoundException("Color code was not found!");

            return Mapper.Map<ColorCodeModel>(colorCode);
        }

        public async Task<IEnumerable<ColorCodeModel>> GetByModelIdAsync(int id)
        {
            var modelSupportsColor = await ReadRepository.GetAsync(_modelColorFiltersProvider.ByModelId(id), _modelColorRelationsProvider.JoinColor);

            return Mapper.Map<IEnumerable<ColorCodeModel>>(modelSupportsColor.Select(x => x.Color));
        }
    }
}
