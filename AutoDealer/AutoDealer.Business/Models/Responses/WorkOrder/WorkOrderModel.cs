using System;
using System.Collections.Generic;
using AutoDealer.Business.Models.Responses.User;

namespace AutoDealer.Business.Models.Responses.WorkOrder
{
    public class WorkOrderModel : BaseModel
    {
        public DateTime CreatedDate { get; }
        public DateTime? CompletedDate { get; }
        public UserContactInfo Worker { get; }
        public WorkOrderStatusModel Status { get; }
        public WorkOrderClientModel Client { get; }
        public int TotalPrice { get; }
        public IEnumerable<WorkModel> Works { get; }

        public WorkOrderModel(int id, DateTime createdDate, DateTime? completedDate, UserContactInfo worker, WorkOrderStatusModel status, WorkOrderClientModel client, int totalPrice, IEnumerable<WorkModel> works) : base(id)
        {
            CreatedDate = createdDate;
            CompletedDate = completedDate;
            Worker = worker;
            Status = status;
            Client = client;
            TotalPrice = totalPrice;
            Works = works;
        }
    }
}
