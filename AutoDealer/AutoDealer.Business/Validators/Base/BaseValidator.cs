using AutoDealer.Data.Interfaces.Repositories;
using FluentValidation;

namespace AutoDealer.Business.Validators.Base
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        protected readonly IGenericReadRepository ReadRepository;

        protected BaseValidator(IGenericReadRepository readRepository)
        {
            ReadRepository = readRepository;
        }
    }
}
