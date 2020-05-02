using AutoDealer.Web.ViewModels.Base;

namespace AutoDealer.Web.ViewModels.Request.Miscellaneous
{
    public class SupplierUpdateViewModel : BaseViewModel
    {
        public string CompanyName { get; set; }

        public string Ein { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}
