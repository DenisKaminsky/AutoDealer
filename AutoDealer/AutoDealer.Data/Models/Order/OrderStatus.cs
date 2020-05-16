using System.Collections.Generic;
using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.Order
{
    public class OrderStatus : BaseModel
    {
        public string Name { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
