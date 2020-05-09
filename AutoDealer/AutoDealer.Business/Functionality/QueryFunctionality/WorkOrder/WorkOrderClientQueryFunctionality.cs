using AutoDealer.Business.Functionality.QueryFunctionality.Base;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.QueryFunctionality.WorkOrder;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Responses.WorkOrder;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.WorkOrder;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.WorkOrder;

namespace AutoDealer.Business.Functionality.QueryFunctionality.WorkOrder
{
    public class WorkOrderClientQueryFunctionality : BaseGenericQueryFunctionality<WorkOrderClientModel, WorkOrderClient>, IWorkOrderClientQueryFunctionality
    {
        public WorkOrderClientQueryFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericReadRepository readRepository, IWorkOrderClientFiltersProvider filtersProvider) : base(unitOfWork, mapperFactory, readRepository, filtersProvider)
        {
        }
    }
}
