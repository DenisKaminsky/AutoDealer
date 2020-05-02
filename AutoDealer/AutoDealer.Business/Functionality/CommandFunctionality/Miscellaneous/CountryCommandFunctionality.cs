using AutoDealer.Business.Functionality.CommandFunctionality.Base;
using AutoDealer.Business.Interfaces.CommandFunctionality.Miscellaneous;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.Miscellaneous;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Miscellaneous;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.Miscellaneous
{
    public class CountryCommandFunctionality : BaseGenericCreateUpdateDeleteCommandFunctionality<CountryCreateCommand, CountryUpdateCommand, Country>, ICountryCommandFunctionality
    {
        public CountryCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, 
            IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
        }
    }
}
