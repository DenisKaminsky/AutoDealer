using AutoDealer.Web.ViewModels.Base;

namespace AutoDealer.Web.ViewModels.Response.Car
{
    public class CarEngineViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public int Volume { get; set; }
        public int Power { get; set; }
        public CarEngineTypeViewModel Type { get; set; }
    }
}
