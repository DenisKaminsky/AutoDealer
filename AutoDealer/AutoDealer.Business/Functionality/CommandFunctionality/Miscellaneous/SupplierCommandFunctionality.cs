using System.Threading.Tasks;
using AutoDealer.Business.Functionality.CommandFunctionality.Base;
using AutoDealer.Business.Interfaces.CommandFunctionality.Miscellaneous;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.Miscellaneous;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Miscellaneous;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.Miscellaneous
{
    public class SupplierCommandFunctionality : BaseGenericCreateUpdateDeleteCommandFunctionality<SupplierCreateCommand, SupplierUpdateCommand, Supplier>, ISupplierCommandFunctionality
    {
        private readonly IBrandFiltersProvider _brandFiltersProvider;
        private readonly IGenericReadRepository _genericReadRepository;

        public SupplierCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository, 
            IValidatorFactory validatorFactory, IGenericReadRepository genericReadRepository, IBrandFiltersProvider brandFiltersProvider) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
            _genericReadRepository = genericReadRepository;
            _brandFiltersProvider = brandFiltersProvider;
        }

        public override async Task<int> AddAsync(SupplierCreateCommand supplier)
        {
            await ValidatorFactory.GetValidator<SupplierCreateCommand>().ValidateAndThrowAsync(supplier);

            var brand = await _genericReadRepository.GetSingleAsync(_brandFiltersProvider.ById(supplier.BrandId));
            brand.Supplier = Mapper.Map<Supplier>(supplier);

            await WriteRepository.UpdateAsync(brand);
            await UnitOfWork.CommitAsync();

            return brand.Supplier.Id;
        }
    }
}
