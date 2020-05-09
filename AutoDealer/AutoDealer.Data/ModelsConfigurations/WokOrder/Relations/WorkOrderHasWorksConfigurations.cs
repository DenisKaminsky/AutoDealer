using AutoDealer.Data.Models.WorkOrder.Relations;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.WokOrder.Relations
{
    public static class WorkOrderHasWorksConfigurations
    {
        public static void ConfigureWorkOrderHasWorks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkOrderHasWorks>()
                .HasOne(x => x.Order)
                .WithMany(x => x.Works)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<WorkOrderHasWorks>()
                .HasOne(x => x.Work)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.WorkId);
        }
    }
}
