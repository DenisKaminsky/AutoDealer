using System;
using AutoDealer.Web.ViewModels.Base;
using AutoDealer.Web.ViewModels.Response.User;

namespace AutoDealer.Web.ViewModels.Response.Order
{
    public class DeliveryRequestViewModel : BaseViewModel
    {
        public int CarId { get; set; }
        public int? SupplierId { get; set; }
        public UserContactInfoViewModel Manager { get; set; }
        public UserContactInfoViewModel SupplierManager { get; set; }
        public DeliveryRequestStatusViewModel Status { get; set; }
        public int Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
