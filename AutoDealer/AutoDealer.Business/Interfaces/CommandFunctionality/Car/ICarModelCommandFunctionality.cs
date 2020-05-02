using System.Threading.Tasks;
using AutoDealer.Business.Models.Commands.Car;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.Car
{
    public interface ICarModelCommandFunctionality
    {
        Task AddAsync(CarModelCreateCommand carModel);

        Task UpdateAsync(CarModelUpdateCommand carModel);

        Task RemoveAsync(int id);
    }
}
