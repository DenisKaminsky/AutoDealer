using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.QueryFunctionality.Base;
using AutoDealer.Business.Models.Responses.Car;

namespace AutoDealer.Business.Interfaces.QueryFunctionality.Car
{
    public interface ICarComplectationQueryFunctionality : IGenericQueryFunctionality<CarComplectationModel>
    {
        Task<IEnumerable<CarComplectationModel>> GetByModelIdAsync(int id);
    }
}
