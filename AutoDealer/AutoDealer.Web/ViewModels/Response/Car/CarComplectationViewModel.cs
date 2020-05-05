using AutoDealer.Web.ViewModels.Base;

namespace AutoDealer.Web.ViewModels.Response.Car
{
    public class CarComplectationViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int ModelId { get; set; }
    }
}
