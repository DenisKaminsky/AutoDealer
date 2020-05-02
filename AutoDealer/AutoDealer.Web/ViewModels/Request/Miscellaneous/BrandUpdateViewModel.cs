using AutoDealer.Web.ViewModels.Base;

namespace AutoDealer.Web.ViewModels.Request.Miscellaneous
{
    public class BrandUpdateViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public int CountryId { get; set; }

        public int? SupplierId { get; set; }
    }
}
