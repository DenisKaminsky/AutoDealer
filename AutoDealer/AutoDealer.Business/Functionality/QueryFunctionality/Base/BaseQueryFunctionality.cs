using AutoDealer.Business.Functionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Data.Interfaces.Repositories;

namespace AutoDealer.Business.Functionality.QueryFunctionality.Base
{
    public abstract class BaseQueryFunctionality : BaseFunctionality
    {
        protected IGenericReadRepository ReadRepository { get; }

        protected BaseQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository) : base(unitOfWork, mapperFactory)
        {
            ReadRepository = readRepository;
        }
    }
}
