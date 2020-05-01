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
                new Supplier {Id = 1, CompanyName = "Aston Martin Ltd.", Ein = "63-0407776", Phone = "+62-953-139-6996", Email = "autodealer.supplier@mail.ru", Address = "83 Pierstorff Road", BrandId = 1},
                new Supplier {Id = 2, CompanyName = "Audi AG", Ein = "63-0090042", Phone = "+86-949-817-5475", Email = "autodealer.supplier@mail.ru", Address = "4198 Steensland Center", BrandId = 2},
                new Supplier {Id = 3, CompanyName = "Bentley Motors Ltd.", Ein = "12-2307679", Phone = "+1-262-899-1119", Email = "autodealer.supplier@mail.ru", Address = "6388 Buell Street", BrandId = 3},
                new Supplier {Id = 4, CompanyName = "BMW AG", Ein = "36-4057206", Phone = "+961-747-413-9714", Email = "autodealer.supplier@mail.ru", Address = "1957 David Point", BrandId = 4},
                new Supplier {Id = 5, CompanyName = "Cadillac MCD", Ein = "22-8023603", Phone = "+63-823-431-3781", Email = "autodealer.supplier@mail.ru", Address = "1278 East Junction", BrandId = 5},
                new Supplier {Id = 6, CompanyName = "Chevrolet GM", Ein = "45-7298987", Phone = "+380-650-818-6161", Email = "autodealer.supplier@mail.ru", Address = "65 Hoffman Court", BrandId = 6},
                new Supplier {Id = 9, CompanyName = "Ford Motor Company", Ein = "39-5022725", Phone = "+220-298-594-7890", Email = "autodealer.supplier@mail.ru", Address = "37 Ohio Way", BrandId = 9},
                new Supplier {Id = 10, CompanyName = "Hyundai Motor Company", Ein = "00-4637380", Phone = "+62-227-877-7760", Email = "autodealer.supplier@mail.ru", Address = "59 Toban Crossing", BrandId = 10},
                new Supplier {Id = 11, CompanyName = "Jaguar Cars Ltd.", Ein = "63-5969386", Phone = "+93-989-504-0897", Email = "autodealer.supplier@mail.ru", Address = "8 Mifflin Road", BrandId = 11},
                new Supplier {Id = 12, CompanyName = "Jeep Motors", Ein = "87-4580033", Phone = "+86-870-833-4388", Email = "autodealer.supplier@mail.ru", Address = "9 Kenwood Hill", BrandId = 12},
                new Supplier {Id = 13, CompanyName = "Kia Motors Corporation", Ein = "31-6948865", Phone = "+7-973-391-0359", Email = "autodealer.supplier@mail.ru", Address = "4 Waywood Court", BrandId = 13},
                new Supplier {Id = 14, CompanyName = "Land Rover Ltd.", Ein = "30-3536437", Phone = "+55-666-949-2445", Email = "autodealer.supplier@mail.ru", Address = "70 Rockefeller Road", BrandId = 14},
                new Supplier {Id = 15, CompanyName = "Lexus Division", Ein = "24-1785107", Phone = "+86-573-640-2191", Email = "autodealer.supplier@mail.ru", Address = "7685 Eastwood Court", BrandId = 15},
                new Supplier {Id = 16, CompanyName = "Mazda Motor Corporation", Ein = "04-0606273", Phone = "+86-481-142-5049", Email = "autodealer.supplier@mail.ru", Address = "79281 Toban Park", BrandId = 16},
                new Supplier {Id = 17, CompanyName = "Mercedes-Benz AG", Ein = "59-4883375", Phone = "+54-497-289-6239", Email = "autodealer.supplier@mail.ru", Address = "01544 Oxford Park", BrandId = 17},
                new Supplier {Id = 18, CompanyName = "Mini Ltd.", Ein = "20-7947961", Phone = "+62-999-445-0464", Email = "autodealer.supplier@mail.ru", Address = "16663 Dryden Parkway", BrandId = 18},
                new Supplier {Id = 19, CompanyName = "Mitsubishi Group", Ein = "14-3584691", Phone = "+63-998-461-0214", Email = "autodealer.supplier@mail.ru", Address = "74 Ilene Lane", BrandId = 19},
                new Supplier {Id = 20, CompanyName = "Peugeot S.A.", Ein = "03-5438005", Phone = "+86-159-998-1958", Email = "autodealer.supplier@mail.ru", Address = "9447 Tony Center", BrandId = 20},
                new Supplier {Id = 21, CompanyName = "Porsche AG", Ein = "69-2423110", Phone = "+86-105-579-1867", Email = "autodealer.supplier@mail.ru", Address = "523 Portage Plaza", BrandId = 21},
                new Supplier {Id = 22, CompanyName = "Renault Group", Ein = "75-6428533", Phone = "+57-650-530-1340", Email = "autodealer.supplier@mail.ru", Address = "610 Ludington Trail", BrandId = 22},
                new Supplier {Id = 24, CompanyName = "Skoda Holding", Ein = "08-6770248", Phone = "+55-130-662-0873", Email = "autodealer.supplier@mail.ru", Address = "745 Bartillon Pass", BrandId = 24},
                new Supplier {Id = 25, CompanyName = "Tesla Motors", Ein = "16-6224460", Phone = "+380-536-733-2270", Email = "autodealer.supplier@mail.ru", Address = "098 Meadow Vale Park", BrandId = 25},
                new Supplier {Id = 26, CompanyName = "Toyota Motor Corporation", Ein = "51-0981895", Phone = "+33-536-332-4509", Email = "autodealer.supplier@mail.ru", Address = "3951 Almo Plaza", BrandId = 26},
                new Supplier {Id = 27, CompanyName = "Volkswagen AG", Ein = "26-3770792", Phone = "+996-689-963-5182", Email = "autodealer.supplier@mail.ru", Address = "427 Lighthouse Bay Parkway", BrandId = 27},
                new Supplier {Id = 28, CompanyName = "Volvo Group", Ein = "16-0248494", Phone = "+33-468-326-0652", Email = "autodealer.supplier@mail.ru", Address = "1886 Red Cloud Lane", BrandId = 28}
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
