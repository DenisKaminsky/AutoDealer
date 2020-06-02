using System;
using AutoDealer.Data.Models.Base;
using AutoDealer.Data.Models.Car;

namespace AutoDealer.Data.Models.Order
{
    public class DeliveryRequest : BaseModel
    {
        public int CarId { get; set; }
        public CarStock Car { get; set; }
        public int ManagerId { get; set; }
        public User.User Manager { get; set; }
        public int? SupplierManagerId { get; set; }
        public User.User SupplierManager { get; set; }
        public int StatusId { get; set; }
        public DeliveryRequestStatus Status { get; set; }
        public int Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public Order Order { get; set; }
    }
}
