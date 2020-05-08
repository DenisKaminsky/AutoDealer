using AutoDealer.Data.Models.User;
using AutoDealer.Miscellaneous.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AutoDealer.Data.Seeds.User
{
    public static class UserRoleSeeds
    {
        public static void SeedUserRoles(this ModelBuilder modelBuilder)
        {
            var roles = Enum.GetValues(typeof(UserRoles)).Cast<UserRoles>()
                .Select(x => new UserRole {Id = (int) x, Name = x.ToString()}).ToArray();
            
            modelBuilder.Entity<UserRole>().HasData(roles);

            modelBuilder.HasSequence<int>("UserRoles_Seq", schema: "public")
                .StartsAt(roles.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<UserRole>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"UserRoles_Seq\"')");
        }
    }
}
