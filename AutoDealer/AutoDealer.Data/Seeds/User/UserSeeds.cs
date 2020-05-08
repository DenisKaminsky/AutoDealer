using System;
using System.Linq;
using AutoDealer.Miscellaneous.Enums;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.User
{
    public static class UserSeeds
    {
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            var users = new[]
            {
                new Models.User.User { Id = 1, FirstName = "Denis", LastName = "Kaminsky", Email = "dkaminsky@autodealer.com", 
                    PasswordHash = "fcea920f7412b5da7be0cf42b8c93759", Phone = "+375(44)4839570", IsMale = true, CreatedDate = DateTime.UtcNow, 
                    Birthday = new DateTime(1999, 2, 16), Salary = 2000, RoleId = (int)UserRoles.Admin, IsActive = true },

                new Models.User.User { Id = 2, FirstName = "Kirill", LastName = "Alexeenko", Email = "kalexeenko@autodealer.com",
                    PasswordHash = "fcea920f7412b5da7be0cf42b8c93759", Phone = "+375(44)2828282", IsMale = true, CreatedDate = DateTime.UtcNow,
                    Birthday = new DateTime(1999, 1, 12), Salary = 1500, RoleId = (int)UserRoles.Admin, IsActive = true },

                new Models.User.User { Id = 3, FirstName = "Ivan", LastName = "Ivanov", Email = "iivanov@autodealer.com",
                    PasswordHash = "fcea920f7412b5da7be0cf42b8c93759", Phone = "+375(44)121212", IsMale = true, CreatedDate = DateTime.UtcNow,
                    Birthday = new DateTime(1984, 5, 21), Salary = 800, RoleId = (int)UserRoles.ServiceMan, IsActive = true },

                new Models.User.User { Id = 4, FirstName = "Kate", LastName = "Ivanova", Email = "kivanova@autodealer.com",
                    PasswordHash = "fcea920f7412b5da7be0cf42b8c93759", Phone = "+375(44)353535", IsMale = false, CreatedDate = DateTime.UtcNow,
                    Birthday = new DateTime(1995, 8, 17), Salary = 900, RoleId = (int)UserRoles.Manager, IsActive = true },

                new Models.User.User { Id = 5, FirstName = "Nataly", LastName = "Johnson", Email = "njohnson@autodealer.com",
                    PasswordHash = "fcea920f7412b5da7be0cf42b8c93759", Phone = "+375(44)676767", IsMale = false, CreatedDate = DateTime.UtcNow,
                    Birthday = new DateTime(1996, 6, 26), Salary = 900, RoleId = (int)UserRoles.SupplierManager, IsActive = true }
            };

            modelBuilder.Entity<Models.User.User>().HasData(users);

            modelBuilder.HasSequence<int>("Users_Seq", schema: "public")
                .StartsAt(users.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<Models.User.User>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"Users_Seq\"')");
        }
    }
}
