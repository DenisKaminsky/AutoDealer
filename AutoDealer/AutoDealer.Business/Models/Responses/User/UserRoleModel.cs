namespace AutoDealer.Business.Models.Responses.User
{
    public class UserRoleModel : BaseModel
    {
        public string Name { get; }
        public UserRoleModel(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
