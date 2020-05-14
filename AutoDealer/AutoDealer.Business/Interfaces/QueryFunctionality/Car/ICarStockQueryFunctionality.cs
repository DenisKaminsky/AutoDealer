using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.QueryFunctionality.Base;
using AutoDealer.Business.Models.Responses.Car;
using AutoDealer.Business.Models.Responses.File;

namespace AutoDealer.Business.Interfaces.QueryFunctionality.Car
{
    public interface ICarStockQueryFunctionality : IGenericQueryFunctionality<CarStockModel>
    {
        Task<IEnumerable<CarStockModel>> GetAllInStockAsync();
        Task<CarStockModel> GetInStockByIdAsync(int id);
        Task<FileModel> GetPhotoByIdAsync(int id);
    }
}
