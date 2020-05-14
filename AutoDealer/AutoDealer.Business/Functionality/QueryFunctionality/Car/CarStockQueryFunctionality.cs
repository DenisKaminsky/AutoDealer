using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Functionality.QueryFunctionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.Car;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Responses.Car;
using AutoDealer.Business.Models.Responses.File;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.RelationsProviders.Car;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Car;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Miscellaneous.Exceptions;
using AutoDealer.Miscellaneous.Interfaces;

namespace AutoDealer.Business.Functionality.QueryFunctionality.Car
{
    public class CarStockQueryFunctionality : BaseQueryFunctionality, ICarStockQueryFunctionality
    {
        private readonly ICarStockRelationsProvider _carRelationsProvider;
        private readonly ICarStockFiltersProvider _carFiltersProvider;
        private readonly ICarPhotoFiltersProvider _carPhotoFiltersProvider;
        private readonly IFileManager _fileManager;

        public CarStockQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, ICarStockRelationsProvider carRelationsProvider, 
            ICarStockFiltersProvider carFiltersProvider, ICarPhotoFiltersProvider carPhotoFiltersProvider, IFileManager fileManager) : base(unitOfWork, mapperFactory, readRepository)
        {
            _carRelationsProvider = carRelationsProvider;
            _carFiltersProvider = carFiltersProvider;
            _carPhotoFiltersProvider = carPhotoFiltersProvider;
            _fileManager = fileManager;
        }

        public async Task<IEnumerable<CarStockModel>> GetAllAsync()
        {
            var items = await ReadRepository.GetAllAsync<CarStock>(_carRelationsProvider.JoinAll);
            return Mapper.Map<IEnumerable<CarStockModel>>(items);
        }

        public async Task<IEnumerable<CarStockModel>> GetAllInStockAsync()
        {
            var items = await ReadRepository.GetAsync(_carFiltersProvider.InStock(), _carRelationsProvider.JoinAll);
            return Mapper.Map<IEnumerable<CarStockModel>>(items);
        }

        public async Task<CarStockModel> GetByIdAsync(int id)
        {
            var item = await ReadRepository.GetSingleAsync(_carFiltersProvider.ById(id), _carRelationsProvider.JoinAll);

            if (item == null)
                throw new NotFoundException("Item was not found!");

            return Mapper.Map<CarStockModel>(item);
        }

        public async Task<CarStockModel> GetInStockByIdAsync(int id)
        {
            var item = await ReadRepository.GetSingleAsync(_carFiltersProvider.InStockById(id), _carRelationsProvider.JoinAll);

            if (item == null)
                throw new NotFoundException("Item was not found!");

            return Mapper.Map<CarStockModel>(item);
        }

        public async Task<FileModel> GetPhotoByIdAsync(int id)
        {
            var item = await ReadRepository.GetSingleAsync(_carPhotoFiltersProvider.ById(id));

            if (item == null)
                throw new NotFoundException("File was not found!");

            var content = await _fileManager.LoadAsync(item.FileName, FileDestinations.CarPhoto);                      
            return item.ToFileModel(content);
        }
    }
}
