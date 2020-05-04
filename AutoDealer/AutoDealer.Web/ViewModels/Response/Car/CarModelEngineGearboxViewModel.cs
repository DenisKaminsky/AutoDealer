using AutoDealer.Web.ViewModels.Base;

namespace AutoDealer.Web.ViewModels.Response.Car
{
    public class CarModelEngineGearboxViewModel : BaseViewModel
    {
        public CarEngineViewModel Engine { get; set; }
        public GearboxViewModel Gearbox { get; set; }
        public int Price { get; set; }
    }
}
