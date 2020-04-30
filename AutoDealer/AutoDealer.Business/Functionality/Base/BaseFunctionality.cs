using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoMapper;

namespace AutoDealer.Business.Functionality.Base
{
    public abstract class BaseFunctionality
    {
        protected IUnitOfWork UnitOfWork { get; }
        protected IMapper Mapper { get; }

        protected BaseFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapperFactory.GetMapper(nameof(BusinessServices));
        }
    }
}
