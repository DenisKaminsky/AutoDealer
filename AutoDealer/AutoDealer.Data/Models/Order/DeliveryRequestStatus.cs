using System.Collections.Generic;
using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.Order
{
    public class DeliveryRequestStatus : BaseModel
    {
        public string Name { get; set; }
        public IEnumerable<DeliveryRequest> DeliveryRequests { get; set; }
    }
}
