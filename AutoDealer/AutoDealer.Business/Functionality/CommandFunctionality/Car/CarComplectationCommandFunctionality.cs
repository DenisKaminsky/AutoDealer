using System.Collections.Generic;
using System.Linq;
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
    public class CarComplectationCommandFunctionality 
        : BaseGenericCreateDeleteCommandFunctionality<CarComplectationCreateCommand, CarComplectation>, ICarComplectationCommandFunctionality
    {
        public CarComplectationCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory) 
            : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
        }

        public async Task AddOptionsAsync(CarComplectationOptionsAssignCommand assignCommand)
        {
            await ValidatorFactory.GetValidator<CarComplectationOptionsAssignCommand>().ValidateAndThrowAsync(assignCommand);
            var itemsToAdd = Mapper.Map<IEnumerable<CarComplectationOption>>(assignCommand).ToArray();

            await WriteRepository.AddRangeAsync(itemsToAdd);
            await UnitOfWork.CommitAsync();
        }

        public async Task RemoveOptionAsync(int id)
        {
            var isRemoved = await WriteRepository.RemoveByIdAsync<CarComplectationOption>(id);

            if (!isRemoved)
                throw new NotFoundException("Item was not found!");

            await UnitOfWork.CommitAsync();
        }
    }
}
