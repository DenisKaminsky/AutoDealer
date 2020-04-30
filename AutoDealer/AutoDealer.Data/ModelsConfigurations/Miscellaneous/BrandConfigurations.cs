﻿using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Miscellaneous.Constraints.Miscellaneous;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.Miscellaneous
{
    public static class BrandConfigurations
    {
        public static void ConfigureBrand(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<Brand>()
                .Property(x => x.Name)
                .HasMaxLength(BrandConstraints.NameMaxLength)
                .IsRequired();
        }
    }
}