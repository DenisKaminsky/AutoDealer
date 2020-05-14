using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Functionality.CommandFunctionality.Base;
using AutoDealer.Business.Interfaces.CommandFunctionality.Miscellaneous;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.Miscellaneous;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Miscellaneous.Exceptions;
using AutoDealer.Miscellaneous.Interfaces;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.Miscellaneous
{
    public class SupplierCommandFunctionality : BaseGenericCreateUpdateDeleteCommandFunctionality<SupplierCreateCommand, SupplierUpdateCommand, Supplier>, ISupplierCommandFunctionality
    {
        private readonly IBrandFiltersProvider _brandFiltersProvider;
        private readonly IGenericReadRepository _readRepository;
        private readonly ISupplierPhotoFiltersProvider _supplierPhotoFiltersProvider;
        private readonly IFileManager _fileManager;

        public SupplierCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository, 
            IValidatorFactory validatorFactory, IGenericReadRepository readRepository, IBrandFiltersProvider brandFiltersProvider, ISupplierPhotoFiltersProvider supplierPhotoFiltersProvider, IFileManager fileManager) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
            _readRepository = readRepository;
            _brandFiltersProvider = brandFiltersProvider;
            _supplierPhotoFiltersProvider = supplierPhotoFiltersProvider;
            _fileManager = fileManager;
        }

        public override async Task<int> AddAsync(SupplierCreateCommand supplier)
        {
            await ValidatorFactory.GetValidator<SupplierCreateCommand>().ValidateAndThrowAsync(supplier);

            var brand = await _readRepository.GetSingleAsync(_brandFiltersProvider.ById(supplier.BrandId));
            brand.Supplier = Mapper.Map<Supplier>(supplier);

            await WriteRepository.UpdateAsync(brand);
            await UnitOfWork.CommitAsync();

            return brand.Supplier.Id;
        }

        public async Task<int> AddPhotoAsync(SupplierPhotoCreateCommand createCommand)
        {
            await ValidatorFactory.GetValidator<SupplierPhotoCreateCommand>().ValidateAndThrowAsync(createCommand);

            try
            {
                await UnitOfWork.BeginTransactionAsync();
                var fileName = await _fileManager.SaveAsync(createCommand.Photo, FileDestinations.SupplierPhoto);
                var item = createCommand.ToSupplierPhoto(fileName);
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
            var item = await _readRepository.GetSingleAsync(_supplierPhotoFiltersProvider.ById(id));

            if (item == null)
                throw new NotFoundException("File was not found!");

            await WriteRepository.RemoveByIdAsync<SupplierPhoto>(id);
            await _fileManager.DeleteAsync(item.FileName, FileDestinations.SupplierPhoto);
            await UnitOfWork.CommitAsync();
        }
    }
}
