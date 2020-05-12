using AutoDealer.Data.Models.Order;
using AutoDealer.Miscellaneous.Constraints.Order;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Order
{
    public static class OrderStatusConfigurations
    {
        public static void ConfigureOrderStatus(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderStatus>()
                .Property(x => x.Name)
                .HasMaxLength(OrderStatusConstraints.NameMaxLength)
                .IsRequired();
        }
    }
}
