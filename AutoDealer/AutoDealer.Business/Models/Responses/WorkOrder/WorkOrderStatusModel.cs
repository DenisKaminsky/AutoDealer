namespace AutoDealer.Business.Models.Responses.WorkOrder
{
    public class WorkOrderStatusModel : BaseModel
    {
        public string Name { get; }

        public WorkOrderStatusModel(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
