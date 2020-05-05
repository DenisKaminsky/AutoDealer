using System.Collections.Generic;

namespace AutoDealer.Web.ViewModels.Request.Car
{
    public class CarComplectationOptionsAssignViewModel
    {
        public int ComplectationId { get; set; }
        public IEnumerable<string> Options { get; set; }
    }
}
