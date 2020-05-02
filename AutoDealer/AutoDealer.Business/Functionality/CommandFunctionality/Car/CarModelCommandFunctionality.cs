using System.Threading.Tasks;
using AutoDealer.Business.Functionality.CommandFunctionality.Base;
using AutoDealer.Business.Interfaces.CommandFunctionality.Car;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Car;
using AutoDealer.Miscellaneous.Exceptions;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.Car
{
    public class CarModelCommandFunctionality: BaseCommandFunctionality, ICarModelCommandFunctionality
    {
        public CarModelCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
        }

        public async Task AddAsync(CarModelCreateCommand carModel)
        {
            await ValidatorFactory.GetValidator<CarModelCreateCommand>().ValidateAndThrowAsync(carModel);

            await WriteRepository.AddAsync(Mapper.Map<CarModel>(carModel));
            await UnitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(CarModelUpdateCommand carModel)
        {
            await ValidatorFactory.GetValidator<CarModelUpdateCommand>().ValidateAndThrowAsync(carModel);

            await WriteRepository.UpdateAsync(Mapper.Map<CarModel>(carModel));
            await UnitOfWork.CommitAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var isRemoved = await WriteRepository.RemoveByIdAsync<CarModel>(id);

            if (!isRemoved)
                throw new NotFoundException("Car model was not found!");

            await UnitOfWork.CommitAsync();
        }
    }
}
