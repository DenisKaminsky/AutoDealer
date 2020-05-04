namespace AutoDealer.Business.Models.Commands.Car
{
    public class CarEngineGearboxAssignCommand : CarEngineGearboxUnassignCommand
    {
        public int Price { get; }

        public CarEngineGearboxAssignCommand(int modelId, int engineId, int gearboxId, int price) : base(modelId, engineId, gearboxId)
        {
            Price = price;
        }
    }
}
