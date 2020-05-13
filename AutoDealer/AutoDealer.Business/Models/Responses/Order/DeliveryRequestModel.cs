using System;
using AutoDealer.Business.Models.Responses.User;

namespace AutoDealer.Business.Models.Responses.Order
{
    public class DeliveryRequestModel : BaseModel
    {
        public int CarId { get; }
        public int? SupplierId { get; }
        public UserContactInfo Manager { get; }
        public UserContactInfo SupplierManager { get; }
        public DeliveryRequestStatusModel Status { get; }
        public int Amount { get; }
        public DateTime CreateDate { get; }
        public DateTime? CompletedDate { get; }

        public DeliveryRequestModel(int id, int carId, int? supplierId, UserContactInfo manager, UserContactInfo supplierManager, DeliveryRequestStatusModel status, int amount, DateTime createDate, DateTime? completedDate) : base(id)
        {
            CarId = carId;
            SupplierId = supplierId;
            Manager = manager;
            SupplierManager = supplierManager;
            Status = status;
            Amount = amount;
            CreateDate = createDate;
            CompletedDate = completedDate;
        }
    }
}
