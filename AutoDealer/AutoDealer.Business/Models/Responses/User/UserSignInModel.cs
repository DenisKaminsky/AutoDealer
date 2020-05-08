namespace AutoDealer.Business.Models.Responses.User
{
    public class UserSignInModel : BaseModel
    {
        public UserRoleModel Role { get; }
        public string Email { get; }

        public UserSignInModel(int id, UserRoleModel role, string email) : base(id)
        {
            Role = role;
            Email = email;
        }
    }
}
