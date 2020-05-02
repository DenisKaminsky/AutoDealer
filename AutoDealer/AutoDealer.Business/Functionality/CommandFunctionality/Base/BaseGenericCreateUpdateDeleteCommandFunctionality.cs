using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.Models;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Base;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.Base
{
    public abstract class BaseGenericCreateUpdateDeleteCommandFunctionality<TCreateCommand, TUpdateCommand, TDataModel> : BaseGenericCreateDeleteCommandFunctionality<TCreateCommand, TDataModel>
        where TCreateCommand : ICreateCommand
        where TUpdateCommand : IUpdateCommand
        where TDataModel : BaseModel
    {
        protected BaseGenericCreateUpdateDeleteCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
        }

        public virtual async Task UpdateAsync(TUpdateCommand updateCommand)
        {
            await ValidatorFactory.GetValidator<TUpdateCommand>().ValidateAndThrowAsync(updateCommand);

            await WriteRepository.UpdateAsync(Mapper.Map<TDataModel>(updateCommand));
            await UnitOfWork.CommitAsync();
        }
    }
}
