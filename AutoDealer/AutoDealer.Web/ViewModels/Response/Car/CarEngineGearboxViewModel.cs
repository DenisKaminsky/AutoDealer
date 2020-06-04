using AutoDealer.Web.ViewModels.Base;

namespace AutoDealer.Web.ViewModels.Response.Car
{
    public class CarEngineGearboxViewModel : BaseViewModel
    {
        public CarEngineViewModel Engine { get; set; }
        public GearboxViewModel Gearbox { get; set; }
    }
}
