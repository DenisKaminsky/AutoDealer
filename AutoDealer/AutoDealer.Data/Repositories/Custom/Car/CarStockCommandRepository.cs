using System.Linq;
using System.Threading.Tasks;
using AutoDealer.Data.Interfaces.Repositories.Custom.Car;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Data.Repositories.Custom.Car
{
    public class CarStockCommandRepository : BaseRepository, ICarStockCommandRepository
    {
        public CarStockCommandRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<int> CalculateCarPriceAsync(int modelId, int bodyTypeId, int engineGearboxId, int complectationId)
        {
            var modelPrice = DbContext.CarModels.Where(x => x.Id == modelId).Select(x => x.Price).FirstOrDefaultAsync();
            var bodyTypePrice = DbContext.ModelsSupportBodyTypes
                .Where(x => x.ModelId == modelId && x.BodyTypeId == bodyTypeId).Select(x => x.Price).FirstOrDefaultAsync();
            var engineGearboxPrice = DbContext.EngineSupportGearboxes
                .Where(x => x.Id == engineGearboxId).Select(x => x.Price).FirstOrDefaultAsync();
            var complectationPrice = DbContext.CarComplectations
                .Where(x => x.Id == engineGearboxId).Select(x => x.Price).FirstOrDefaultAsync();

            return await modelPrice + await bodyTypePrice + await engineGearboxPrice + await complectationPrice;
        }
    }
}
