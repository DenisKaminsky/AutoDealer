using AutoDealer.Web.ViewModels.Base;

namespace AutoDealer.Web.ViewModels.Request.Car
{
    public class CarEngineUpdateViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public int Volume { get; set; }
        public int Power { get; set; }
        public int Price { get; set; }
        public int TypeId { get; set; }
    }
}
