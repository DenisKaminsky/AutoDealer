namespace AutoDealer.Business.Models.Responses.Miscellaneous
{
    public class SupplierModel: BaseModel
    {
        public string CompanyName { get; }

        public string Ein { get; }

        public string Phone { get; }

        public string Email { get; }

        public string Address { get; }
        
        public BrandModel Brand { get; }

        public SupplierModel(int id, string companyName, string ein, string phone, string email, string address, BrandModel brand) : base(id)
        {
            CompanyName = companyName;
            Ein = ein;
            Phone = phone;
            Email = email;
            Address = address;
            Brand = brand;
        }
    }
}
