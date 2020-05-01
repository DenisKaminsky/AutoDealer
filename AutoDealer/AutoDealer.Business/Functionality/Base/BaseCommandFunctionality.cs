using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Data.Interfaces.Repositories;
using FluentValidation;

namespace AutoDealer.Business.Functionality.Base
{
    public abstract class BaseCommandFunctionality : BaseFunctionality
    {
        protected IGenericWriteRepository WriteRepository { get; }
        protected IValidatorFactory ValidatorFactory { get; }

        protected BaseCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, 
            IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory) : base(unitOfWork, mapperFactory)
        {
            WriteRepository = writeRepository;
            ValidatorFactory = validatorFactory;
        }
    }
}
