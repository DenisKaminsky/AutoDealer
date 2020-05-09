using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Base;
using AutoDealer.Data.Models.WorkOrder;

namespace AutoDealer.Data.Interfaces.QueryFiltersProviders.WorkOrder
{
    public interface IWorkFiltersProvider: IBaseFiltersProvider<Work>
    {
        Expression<Func<Work, bool>> ByIds(IEnumerable<int> ids);
    }
}
