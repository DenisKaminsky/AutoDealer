using System;
using AutoDealer.Data.Models.Base;
using AutoDealer.Data.Models.Car;

namespace AutoDealer.Data.Models.Order
{
    public class Order : BaseModel
    {
        public int CarId { get; set; }
        public CarStock Car { get; set; }
        public int ManagerId { get; set; }
        public User.User Manager { get; set; }
        public int ClientId { get; set; }
        public User.Client Client { get; set; }
        public int StatusId { get; set; }
        public OrderStatus Status { get; set; }
        public int? DeliveryRequestId { get; set; }
        public DeliveryRequest DeliveryRequest { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
