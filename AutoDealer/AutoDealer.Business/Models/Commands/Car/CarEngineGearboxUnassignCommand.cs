namespace AutoDealer.Business.Models.Commands.Car
{
    public class CarEngineGearboxUnassignCommand
    {
        public int ModelId { get; }
        public int EngineId { get; }
        public int GearboxId { get; }

        public CarEngineGearboxUnassignCommand(int modelId, int engineId, int gearboxId)
        {
            ModelId = modelId;
            EngineId = engineId;
            GearboxId = gearboxId;
        }
    }
}
