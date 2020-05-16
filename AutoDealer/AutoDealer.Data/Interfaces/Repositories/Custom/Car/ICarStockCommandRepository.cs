using System.Threading.Tasks;

namespace AutoDealer.Data.Interfaces.Repositories.Custom.Car
{
    public interface ICarStockCommandRepository
    {
        Task<int> CalculateCarPriceAsync(int modelId, int bodyTypeId, int engineGearboxId, int complectationId);
    }
}
