using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Data.Interfaces.Repositories;

namespace AutoDealer.Business.Functionality.Base
{
    public abstract class BaseCommandFunctionality : BaseFunctionality
    {
        protected IGenericWriteRepository WriteRepository { get; }

        protected BaseCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository) : base(unitOfWork, mapperFactory)
        {
            WriteRepository = writeRepository;
        }
    }
}
