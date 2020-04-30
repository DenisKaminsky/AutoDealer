namespace AutoDealer.Business.Models
{
    public class BaseModel
    {
        public int Id { get; }

        public BaseModel(int id)
        {
            Id = id;
        }
    }
}
