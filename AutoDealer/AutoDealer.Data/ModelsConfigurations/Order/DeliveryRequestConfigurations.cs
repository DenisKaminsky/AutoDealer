using AutoDealer.Data.Models.Order;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Order
{
    public static class DeliveryRequestConfigurations
    {
        public static void ConfigureDeliveryRequest(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryRequest>()
                .HasCheckConstraint("CK_DeliveryRequest_Amount", $"\"{nameof(DeliveryRequest.Amount)}\" >= 0");

            modelBuilder.Entity<DeliveryRequest>()
                .HasOne(x => x.Manager)
                .WithMany(x => x.CreatedDeliveryRequests)
                .HasForeignKey(x => x.ManagerId);

            modelBuilder.Entity<DeliveryRequest>()
                .HasOne(x => x.SupplierManager)
                .WithMany(x => x.AssignedDeliveryRequests)
                .HasForeignKey(x => x.SupplierManagerId);
        }
    }
}
