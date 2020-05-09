using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.WorkOrder
{
    public class Work : BaseModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
