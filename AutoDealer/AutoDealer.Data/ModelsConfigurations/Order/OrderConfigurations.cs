using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Order
{
    public static class OrderConfigurations
    {
        public static void ConfigureOrder(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Order.Order>()
                .HasOne(p => p.DeliveryRequest)
                .WithOne(s => s.Order)
                .HasForeignKey<Models.Order.Order>(b => b.DeliveryRequestId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
