namespace AutoDealer.Business.Models.Commands.Miscellaneous
{
    public class SupplierCreateCommand
    {
        public string CompanyName { get; }

        public string Ein { get; }

        public string Phone { get; }

        public string Email { get; }

        public string Address { get; }

        public int BrandId { get; }

        public SupplierCreateCommand(string companyName, string ein, string phone, string email, string address, int brandId)
        {
            CompanyName = companyName;
            Ein = ein;
            Phone = phone;
            Email = email;
            Address = address;
            BrandId = brandId;
        }
    }
}
