using AutoDealer.Data.Models.WorkOrder;
using AutoDealer.Miscellaneous.Constraints.WorkOrder;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.WokOrder
{
    public static class WorkConfigurations
    {
        public static void ConfigureWork(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Work>()
                .Property(x => x.Name)
                .HasMaxLength(WorkConstraints.NameMaxLength)
                .IsRequired();

            modelBuilder.Entity<Work>()
                .HasCheckConstraint("CK_Works_Price", $"\"{nameof(Work.Price)}\" >= 0");
        }
    }
}
