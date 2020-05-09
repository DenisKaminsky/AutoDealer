using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.WorkOrder
{
    public class WorkOrderClient : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}
