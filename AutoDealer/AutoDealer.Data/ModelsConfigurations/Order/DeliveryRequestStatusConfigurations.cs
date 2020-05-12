using AutoDealer.Data.Models.Order;
using AutoDealer.Miscellaneous.Constraints.Order;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Order
{
    public static class DeliveryRequestStatusConfigurations
    {
        public static void ConfigureDeliveryRequestStatus(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryRequestStatus>()
                .Property(x => x.Name)
                .HasMaxLength(DeliveryRequestStatusConstraints.NameMaxLength)
                .IsRequired();
        }
    }
}
