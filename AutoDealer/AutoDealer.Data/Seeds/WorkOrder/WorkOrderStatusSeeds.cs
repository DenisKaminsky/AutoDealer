using System;
using System.Linq;
using AutoDealer.Data.Models.WorkOrder;
using AutoDealer.Miscellaneous.Enums;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.WorkOrder
{
    public static class WorkOrderStatusSeeds
    {
        public static void SeedWorkOrderStatuses(this ModelBuilder modelBuilder)
        {
            var roles = Enum.GetValues(typeof(WorkOrderStatuses)).Cast<WorkOrderStatuses>()
                .Select(x => new WorkOrderStatus { Id = (int)x, Name = x.ToString() }).ToArray();

            modelBuilder.Entity<WorkOrderStatus>().HasData(roles);

            modelBuilder.HasSequence<int>("WorkOrderStatuses_Seq", schema: "public")
                .StartsAt(roles.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<WorkOrderStatus>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"WorkOrderStatuses_Seq\"')");
        }
    }
}
