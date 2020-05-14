using AutoDealer.Web.ViewModels.Base;
using System.Collections.Generic;

namespace AutoDealer.Web.ViewModels.Response.Miscellaneous
{
    public class SupplierViewModel : BaseViewModel
    {
        public string CompanyName { get; set; }

        public string Ein { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public BrandViewModel Brand { get; set; }

        public IEnumerable<int> Photos { get; set; }
    }
}
