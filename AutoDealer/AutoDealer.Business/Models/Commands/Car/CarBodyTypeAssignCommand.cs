namespace AutoDealer.Business.Models.Commands.Car
{
    public class CarBodyTypeAssignCommand : CarBodyTypeUnassignCommand
    {
        public int Price { get; set; }
    }
}
