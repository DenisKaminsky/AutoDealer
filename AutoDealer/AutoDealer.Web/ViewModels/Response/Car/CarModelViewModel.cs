using AutoDealer.Web.ViewModels.Base;

namespace AutoDealer.Web.ViewModels.Response.Car
{
    public class CarModelViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int Price { get; set; }
    }
}
