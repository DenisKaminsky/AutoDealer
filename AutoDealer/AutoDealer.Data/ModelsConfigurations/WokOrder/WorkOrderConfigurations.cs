using AutoDealer.Data.Models.WorkOrder;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.WokOrder
{
    public static class WorkOrderConfigurations
    {
        public static void ConfigureWorkOrder(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkOrder>()
                .HasCheckConstraint("CK_WorkOrders_TotalPrice", $"\"{nameof(WorkOrder.TotalPrice)}\" >= 0");
        }
    }
}
