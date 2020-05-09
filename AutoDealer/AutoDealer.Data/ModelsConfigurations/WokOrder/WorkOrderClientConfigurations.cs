using AutoDealer.Data.Models.WorkOrder;
using AutoDealer.Miscellaneous.Constraints.WorkOrder;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.WokOrder
{
    public static class WorkOrderClientConfigurations
    {
        public static void ConfigureWorkOrderClient(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkOrderClient>()
                .Property(x => x.FirstName)
                .HasMaxLength(WorkOrderClientConstraints.FirstNameMaxLength)
                .IsRequired();

            modelBuilder.Entity<WorkOrderClient>()
                .Property(x => x.LastName)
                .HasMaxLength(WorkOrderClientConstraints.LastNameMaxLength)
                .IsRequired();

            modelBuilder.Entity<WorkOrderClient>()
                .Property(x => x.Phone)
                .HasMaxLength(WorkOrderClientConstraints.PhoneMaxLength)
                .IsRequired();
        }
    }
}
