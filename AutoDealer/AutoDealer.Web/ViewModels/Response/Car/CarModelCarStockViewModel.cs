using AutoDealer.Web.ViewModels.Base;
using AutoDealer.Web.ViewModels.Response.Miscellaneous;

namespace AutoDealer.Web.ViewModels.Response.Car
{
    public class CarModelCarStockViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public BrandViewModel Brand { get; set; }
    }
}
