using AutoDealer.Business.Models.Responses.User;
using System;

namespace AutoDealer.Business.Models.Responses.Order
{
    public class OrderModel : BaseModel
    {
        public int CarId { get; }
        public int ManagerId { get; }
        public UserContactInfo Manager { get; }
        public int ClientId { get; }
        public OrderStatusModel Status { get; }
        public int? DeliveryRequestId { get; }
        public bool CanPromote { get; }
        public DateTime CreateDate { get; }
        public DateTime? CompletedDate { get; }

        public OrderModel(int id, int carId, int managerId, UserContactInfo manager, int clientId, OrderStatusModel status, int? deliveryRequestId, DateTime createDate, DateTime? completedDate, bool canPromote) : base(id)
        {
            CarId = carId;
            ManagerId = managerId;
            Manager = manager;
            ClientId = clientId;
            Status = status;
            DeliveryRequestId = deliveryRequestId;
            CreateDate = createDate;
            CompletedDate = completedDate;
            CanPromote = canPromote;
        }
    }
}
