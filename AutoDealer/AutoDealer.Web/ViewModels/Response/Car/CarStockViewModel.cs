using System.Collections.Generic;
using AutoDealer.Web.ViewModels.Base;
using AutoDealer.Web.ViewModels.Response.Miscellaneous;

namespace AutoDealer.Web.ViewModels.Response.Car
{
    public class CarStockViewModel : BaseViewModel
    {
        public CarModelCarStockViewModel Model { get; set; }
        public CarBodyTypeViewModel BodyType { get; set; }
        public ColorCodeViewModel Color { get; set; }
        public CarEngineViewModel Engine { get; set; }
        public GearboxViewModel Gearbox { get; set; }
        public CarComplectationCarStockViewModel Complectation { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public IEnumerable<int> Photos { get; set; }
    }
}
