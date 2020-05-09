using AutoDealer.Data.Extensions;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.Models.Car.Relations;
using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Data.Models.User;
using AutoDealer.Data.Models.WorkOrder;
using AutoDealer.Data.Models.WorkOrder.Relations;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data
{
    public class DataContext : DbContext
    {
        #region Car
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarBodyType> CarBodyTypes { get; set; }
        public DbSet<ModelSupportsBodyType> ModelsSupportBodyTypes { get; set; }
        public DbSet<ModelSupportsColor> ModelsSupportColors { get; set; }
        public DbSet<CarEngineType> CarEngineTypes { get; set; }
        public DbSet<Gearbox> Gearboxes { get; set; }
        public DbSet<CarEngine> CarEngines { get; set; }
        public DbSet<EngineSupportsGearbox> EngineSupportGearboxes { get; set; }
        public DbSet<CarComplectation> CarComplectations { get; set; }
        public DbSet<CarComplectationOption> CarComplectationOptions { get; set; }
        public DbSet<CarStock> CarsStock { get; set; }
        #endregion

        #region User
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Client> Clients { get; set; }
        #endregion

        #region WorkOrder
        public DbSet<WorkOrderClient> WorkOrderClients { get; set; }
        public DbSet<WorkOrderStatus> WorkOrderStatuses { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkOrderHasWorks> WorkOrderHasWorks { get; set; }
        #endregion

        #region Miscellaneous
        public DbSet<Country> Countries { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ColorCode> ColorCodes { get; set; }
        #endregion

        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureModels();
            builder.Seed();
        }
    }
}
