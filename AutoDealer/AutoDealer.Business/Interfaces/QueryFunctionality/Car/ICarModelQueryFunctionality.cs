using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Models.Responses.Car;

namespace AutoDealer.Business.Interfaces.QueryFunctionality.Car
{
    public interface ICarModelQueryFunctionality
    {
        Task<IEnumerable<CarModelModel>> GetAllAsync();

        Task<CarModelModel> GetByIdAsync(int id);

        Task<IEnumerable<CarModelModel>> GetByBrandIdAsync(int id);
    }
}
