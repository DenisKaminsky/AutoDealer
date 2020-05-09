namespace AutoDealer.Business.Models.Responses.WorkOrder
{
    public class WorkOrderClientModel : BaseModel
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Phone { get; }

        public WorkOrderClientModel(int id, string firstName, string lastName, string phone) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
    }
}
