namespace AutoDealer.Business.Models.Commands.Car
{
    public class CarColorAssignmentCommand
    {
        public int ColorId { get; }

        public int ModelId { get; }

        public CarColorAssignmentCommand(int colorId, int modelId)
        {
            ColorId = colorId;
            ModelId = modelId;
        }
    }
}
