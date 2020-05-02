namespace AutoDealer.Business.Models.Commands.Miscellaneous
{
    public class SupplierUpdateCommand: BaseModel
    {
        public string CompanyName { get; }

        public string Ein { get; }

        public string Phone { get; }

        public string Email { get; }

        public string Address { get; }
        
        public SupplierUpdateCommand(int id, string companyName, string ein, string phone, string email, string address): base(id)
        {
            CompanyName = companyName;
            Ein = ein;
            Phone = phone;
            Email = email;
            Address = address;
        }
    }
}
