using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.QueryFunctionality.Base;
using AutoDealer.Business.Models.Responses.Car;

namespace AutoDealer.Business.Interfaces.QueryFunctionality.Car
{
    public interface ICarBodyTypeQueryFunctionality : IGenericQueryFunctionality<CarBodyTypeModel>
    {
        Task<IEnumerable<CarBodyTypeWithPriceModel>> GetByModelIdAsync(int id);
    }
}
