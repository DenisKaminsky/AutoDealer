using AutoDealer.Web.ViewModels.Base;

namespace AutoDealer.Web.ViewModels.Response.Miscellaneous
{
    public class BrandViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public CountryViewModel Country { get; set; }
    }
}
