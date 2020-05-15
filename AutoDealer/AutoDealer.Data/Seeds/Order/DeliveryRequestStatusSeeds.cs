using System;
using System.Linq;
using System.Text.RegularExpressions;
using AutoDealer.Data.Models.Order;
using AutoDealer.Miscellaneous.Enums;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.Order
{
    public static class DeliveryRequestStatusSeeds
    {
        public static void SeedDeliveryRequestStatus(this ModelBuilder modelBuilder)
        {
            var statuses = Enum.GetValues(typeof(DeliveryRequestStatuses)).Cast<DeliveryRequestStatuses>()
                .Select(x => new DeliveryRequestStatus { Id = (int)x, Name = Regex.Replace(x.ToString(), "(\\B[A-Z])", " $1") }).ToArray();

            modelBuilder.Entity<DeliveryRequestStatus>().HasData(statuses);

            modelBuilder.HasSequence<int>("DeliveryRequestStatuses_Seq", schema: "public")
                .StartsAt(statuses.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<OrderStatus>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"DeliveryRequestStatuses_Seq\"')");
        }
    }
}
