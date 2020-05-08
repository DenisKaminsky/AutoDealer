using AutoDealer.Miscellaneous.Constraints.User;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.ModelsConfigurations.User
{
    public static class UserConfigurations
    {
        public static void ConfigureUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.User.User>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<Models.User.User>()
                .Property(x => x.FirstName)
                .HasMaxLength(UserConstraints.FirstNameMaxLength)
                .IsRequired();

            modelBuilder.Entity<Models.User.User>()
                .Property(x => x.LastName)
                .HasMaxLength(UserConstraints.LastNameMaxLength)
                .IsRequired();

            modelBuilder.Entity<Models.User.User>()
                .Property(x => x.Email)
                .HasMaxLength(UserConstraints.EmailMaxLength)
                .IsRequired();

            modelBuilder.Entity<Models.User.User>()
                .Property(x => x.PasswordHash)
                .HasMaxLength(UserConstraints.PasswordHashLength)
                .IsRequired();

            modelBuilder.Entity<Models.User.User>()
                .Property(x => x.Phone)
                .HasMaxLength(UserConstraints.PhoneMaxLength)
                .IsRequired();

            modelBuilder.Entity<Models.User.User>()
                .HasCheckConstraint("CK_User_Salary", $"\"{nameof(Models.User.User.Salary)}\" >= 0");
        }
    }
}
