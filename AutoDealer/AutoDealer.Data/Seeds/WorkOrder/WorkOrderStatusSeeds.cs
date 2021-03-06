﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using AutoDealer.Data.Models.WorkOrder;
using AutoDealer.Miscellaneous.Enums;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.WorkOrder
{
    public static class WorkOrderStatusSeeds
    {
        public static void SeedWorkOrderStatuses(this ModelBuilder modelBuilder)
        {
            var statuses = Enum.GetValues(typeof(WorkOrderStatuses)).Cast<WorkOrderStatuses>()
                .Select(x => new WorkOrderStatus { Id = (int)x, Name = Regex.Replace(x.ToString(), "(\\B[A-Z])", " $1") }).ToArray();

            modelBuilder.Entity<WorkOrderStatus>().HasData(statuses);

            modelBuilder.HasSequence<int>("WorkOrderStatuses_Seq", schema: "public")
                .StartsAt(statuses.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<WorkOrderStatus>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"WorkOrderStatuses_Seq\"')");
        }
    }
}
