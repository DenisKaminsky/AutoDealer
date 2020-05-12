using System;
using System.Linq;
using AutoDealer.Data.Models.Order;
using AutoDealer.Miscellaneous.Enums;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.Order
{
    public static class OrderStatusSeeds
    {
        public static void SeedOrderStatuses(this ModelBuilder modelBuilder)
        {
            var statuses = Enum.GetValues(typeof(OrderStatuses)).Cast<OrderStatuses>()
                .Select(x => new OrderStatus { Id = (int)x, Name = x.ToString() }).ToArray();

            modelBuilder.Entity<OrderStatus>().HasData(statuses);

            modelBuilder.HasSequence<int>("OrderStatuses_Seq", schema: "public")
                .StartsAt(statuses.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<OrderStatus>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"OrderStatuses_Seq\"')");
        }
    }
}
