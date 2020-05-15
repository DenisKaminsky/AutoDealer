using System.Threading.Tasks;
using AutoDealer.Business.Control;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Functionality.CommandFunctionality.Base;
using AutoDealer.Business.Interfaces.CommandFunctionality.Car;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Car;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Miscellaneous.Exceptions;
using AutoDealer.Miscellaneous.Interfaces;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.Car
{
    public class CarStockCommandFunctionality : BaseGenericCreateUpdateDeleteCommandFunctionality<CarStockCreateCommand, CarStockUpdateCommand, CarStock>, ICarStockCommandFunctionality
    {
        private readonly IFileManager _fileManager;
        private readonly IGenericReadRepository _readRepository;
        private readonly ICarPhotoFiltersProvider _carPhotoFiltersProvider;

        public CarStockCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory, IFileManager fileManager, IGenericReadRepository readRepository, ICarPhotoFiltersProvider carPhotoFiltersProvider) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
            _fileManager = fileManager;
            _readRepository = readRepository;
            _carPhotoFiltersProvider = carPhotoFiltersProvider;
        }

        public async Task<int> AddPhotoAsync(CarPhotoCreateCommand createCommand)
        {
            await ValidatorFactory.GetValidator<CarPhotoCreateCommand>().ValidateAndThrowAsync(createCommand);

            try
            {
                await UnitOfWork.BeginTransactionAsync();
                var fileName = await _fileManager.SaveAsync(createCommand.Photo, FileDestinations.CarPhoto);
                var item = createCommand.ToCarPhoto(fileName);
                await WriteRepository.AddAsync(item);
                await UnitOfWork.CommitAsync();

                return item.Id;
            }
            catch 
            {
                _fileManager.RollBack();
                await UnitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task RemovePhotoAsync(int id)
        {
            var item = await _readRepository.GetSingleAsync(_carPhotoFiltersProvider.ById(id));

            if (item == null)
                throw new NotFoundException("File was not found!");

            await WriteRepository.RemoveByIdAsync<CarPhoto>(id);
            await _fileManager.DeleteAsync(item.FileName, FileDestinations.CarPhoto);
            await UnitOfWork.CommitAsync();
        }
    }
}
