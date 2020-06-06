namespace AutoDealer.Business.Models.Responses.User
{
    public class UserSignInModel : BaseModel
    {
        public UserRoleModel Role { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public UserSignInModel(int id, UserRoleModel role, string email, string firstName, string lastName) : base(id)
        {
            Role = role;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
