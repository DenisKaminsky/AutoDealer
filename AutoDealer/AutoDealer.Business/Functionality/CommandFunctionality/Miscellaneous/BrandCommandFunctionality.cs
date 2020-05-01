using System.Threading.Tasks;
using AutoDealer.Business.Functionality.Base;
using AutoDealer.Business.Interfaces.CommandFunctionality;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.Miscellaneous;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Miscellaneous.Exceptions;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.Miscellaneous
{
    public class BrandCommandFunctionality : BaseCommandFunctionality, IBrandCommandFunctionality
    {
        public BrandCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, 
            IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
        }

        public async Task AddAsync(BrandCreateCommand brand)
        {
            await ValidatorFactory.GetValidator<BrandCreateCommand>().ValidateAndThrowAsync(brand);

            await WriteRepository.AddAsync(Mapper.Map<Brand>(brand));
            await UnitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(BrandUpdateCommand brand)
        {
            await ValidatorFactory.GetValidator<BrandUpdateCommand>().ValidateAndThrowAsync(brand);

            await WriteRepository.UpdateAsync(Mapper.Map<Brand>(brand));
            await UnitOfWork.CommitAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var isRemoved = await WriteRepository.RemoveByIdAsync<Brand>(id);

            if (!isRemoved)
                throw new NotFoundException("Brand was not found!");

            await UnitOfWork.CommitAsync();
        }
    }
}
