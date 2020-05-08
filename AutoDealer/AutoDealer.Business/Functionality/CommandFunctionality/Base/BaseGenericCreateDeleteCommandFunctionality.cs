using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.Models;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Base;
using AutoDealer.Miscellaneous.Exceptions;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.Base
{
    public abstract class BaseGenericCreateDeleteCommandFunctionality<TCreateCommand, TDataModel> : BaseCommandFunctionality
        where TCreateCommand : ICreateCommand
        where TDataModel : BaseModel
    {
        protected BaseGenericCreateDeleteCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, 
            IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
        }

        public virtual async Task<int> AddAsync(TCreateCommand createCommand)
        {
            await ValidatorFactory.GetValidator<TCreateCommand>().ValidateAndThrowAsync(createCommand);

            var item = Mapper.Map<TDataModel>(createCommand);
            await WriteRepository.AddAsync(item);
            await UnitOfWork.CommitAsync();

            return item.Id;
        }
        
        public virtual async Task RemoveAsync(int id)
        {
            var isRemoved = await WriteRepository.RemoveByIdAsync<TDataModel>(id);

            if (!isRemoved)
                throw new NotFoundException("Item was not found!");

            await UnitOfWork.CommitAsync();
        }
    }
}
