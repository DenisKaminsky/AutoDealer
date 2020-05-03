using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Functionality.QueryFunctionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Miscellaneous;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Responses.Miscellaneous;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Miscellaneous.Exceptions;

namespace AutoDealer.Business.Functionality.QueryFunctionality.Miscellaneous
{
    public class ColoCodeQueryFunctionality : BaseQueryFunctionality, IColorCodeQueryFunctionality
    {
        private readonly IColorCodeFiltersProvider _filtersProvider;

        public ColoCodeQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, IColorCodeFiltersProvider filtersProvider) : base(unitOfWork, mapperFactory, readRepository)
        {
            _filtersProvider = filtersProvider;
        }

        public async Task<IEnumerable<ColorCodeModel>> GetAllAsync()
        {
            var colorCodes = await ReadRepository.GetAllAsync<ColorCode>();
            return Mapper.Map<IEnumerable<ColorCodeModel>>(colorCodes);
        }

        public async Task<ColorCodeModel> GetByIdAsync(int id)
        {
            var colorCode = await ReadRepository.GetSingleAsync(_filtersProvider.ById(id));

            if (colorCode == null)
                throw new NotFoundException("Color code was not found!");

            return Mapper.Map<ColorCodeModel>(colorCode);
        }
    }
}
