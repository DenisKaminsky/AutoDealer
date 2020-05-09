using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.WorkOrder;
using AutoDealer.Data.Models.WorkOrder;
using AutoDealer.Data.QueryFiltersProviders.Base;

namespace AutoDealer.Data.QueryFiltersProviders.WorkOrder
{
    public class WorkFiltersProvider : BaseFiltersProvider<Work>, IWorkFiltersProvider
    {
        public Expression<Func<Work, bool>> ByIds(IEnumerable<int> ids)
        {
            return item => ids.Contains(item.Id);
        }
    }
}
