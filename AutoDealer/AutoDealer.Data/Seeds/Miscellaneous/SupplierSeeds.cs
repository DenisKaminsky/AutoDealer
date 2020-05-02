using System.Linq;
using AutoDealer.Data.Models.Miscellaneous;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Seeds.Miscellaneous
{
    public static class SupplierSeeds
    {
        public static void SeedSuppliers(this ModelBuilder modelBuilder)
        {
            var suppliers = new[]
            {
                new Supplier {Id = 1, CompanyName = "Aston Martin Ltd.", Ein = "63-0407776", Phone = "+62-953-139-6996", Email = "autodealer.supplier@mail.ru", Address = "83 Pierstorff Road" },
                new Supplier {Id = 2, CompanyName = "Audi AG", Ein = "63-0090042", Phone = "+86-949-817-5475", Email = "autodealer.supplier@mail.ru", Address = "4198 Steensland Center" },
                new Supplier {Id = 3, CompanyName = "Bentley Motors Ltd.", Ein = "12-2307679", Phone = "+1-262-899-1119", Email = "autodealer.supplier@mail.ru", Address = "6388 Buell Street" },
                new Supplier {Id = 4, CompanyName = "BMW AG", Ein = "36-4057206", Phone = "+961-747-413-9714", Email = "autodealer.supplier@mail.ru", Address = "1957 David Point" },
                new Supplier {Id = 5, CompanyName = "Cadillac MCD", Ein = "22-8023603", Phone = "+63-823-431-3781", Email = "autodealer.supplier@mail.ru", Address = "1278 East Junction" },
                new Supplier {Id = 6, CompanyName = "Land Rover Ltd.", Ein = "30-3536437", Phone = "+55-666-949-2445", Email = "autodealer.supplier@mail.ru", Address = "70 Rockefeller Road" },
                new Supplier {Id = 7, CompanyName = "Mercedes-Benz AG", Ein = "59-4883375", Phone = "+54-497-289-6239", Email = "autodealer.supplier@mail.ru", Address = "01544 Oxford Park" },
                new Supplier {Id = 8, CompanyName = "Porsche AG", Ein = "69-2423110", Phone = "+86-105-579-1867", Email = "autodealer.supplier@mail.ru", Address = "523 Portage Plaza" },
                new Supplier {Id = 9, CompanyName = "Volkswagen AG", Ein = "26-3770792", Phone = "+996-689-963-5182", Email = "autodealer.supplier@mail.ru", Address = "427 Lighthouse Bay Parkway" },
            };
            
            modelBuilder.Entity<Supplier>().HasData(suppliers);

            modelBuilder.HasSequence<int>("Suppliers_Seq", schema: "public")
                .StartsAt(suppliers.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<Supplier>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"Suppliers_Seq\"')");
        }
    }
}
