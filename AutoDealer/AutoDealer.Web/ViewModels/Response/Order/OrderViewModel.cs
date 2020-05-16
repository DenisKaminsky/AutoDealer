using System;
using AutoDealer.Web.ViewModels.Base;
using AutoDealer.Web.ViewModels.Response.User;

namespace AutoDealer.Web.ViewModels.Response.Order
{
    public class OrderViewModel: BaseViewModel
    {
        public int CarId { get; set; }
        public int ManagerId { get; set; }
        public UserContactInfoViewModel Manager { get; set; }
        public int ClientId { get; set; }
        public OrderStatusViewModel Status { get; set; }
        public int? DeliveryRequestId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
