namespace AutoDealer.Business.Models.Responses.User
{
    public class UserContactInfo : BaseModel
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Phone { get; }

        public UserContactInfo(int id, string firstName, string lastName, string phone) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
    }
}
