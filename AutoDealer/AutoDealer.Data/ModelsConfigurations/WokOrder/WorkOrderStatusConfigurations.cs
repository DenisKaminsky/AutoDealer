using AutoDealer.Data.Models.WorkOrder;
using AutoDealer.Miscellaneous.Constraints.WorkOrder;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.WokOrder
{
    public static class WorkOrderStatusConfigurations
    {
        public static void ConfigureWorkOrderStatus(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkOrderStatus>()
                .Property(x => x.Name)
                .HasMaxLength(WorkOrderStatusConstraints.NameMaxLength)
                .IsRequired();
        }
    }
}
