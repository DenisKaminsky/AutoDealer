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
    public class CountryCommandFunctionality : BaseCommandFunctionality, ICountryCommandFunctionality
    {
        private readonly IGenericReadRepository _genericReadRepository;

        public CountryCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository, 
            IGenericReadRepository genericReadRepository, IValidatorFactory validatorFactory) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
            _genericReadRepository = genericReadRepository;
        }

        public async Task AddAsync(CountryCreateCommand country)
        {
            await ValidatorFactory.GetValidator<CountryCreateCommand>().ValidateAndThrowAsync(country);

            await WriteRepository.AddAsync(Mapper.Map<Country>(country));
            await UnitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(CountryUpdateCommand country)
        {
            await ValidatorFactory.GetValidator<CountryUpdateCommand>().ValidateAndThrowAsync(country);

            await WriteRepository.UpdateAsync(Mapper.Map<Country>(country));
            await UnitOfWork.CommitAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var country = _genericReadRepository.ValidateIdExists<Country>(id);

            if (!country)
                throw new NotFoundException("Country was not found!");

            await WriteRepository.RemoveByIdAsync<Country>(id);
            await UnitOfWork.CommitAsync();
        }
    }
}
