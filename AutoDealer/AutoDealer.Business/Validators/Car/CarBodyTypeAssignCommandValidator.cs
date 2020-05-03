using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace AutoDealer.Business.Validators.Car
{
    public class CarBodyTypeAssignCommandValidator : BaseValidator<CarBodyTypeAssignCommand>
    {
        private readonly ICarModelFiltersProvider _modelFiltersProvider;
        private readonly ICarBodyTypeFiltersProvider _bodyTypeFiltersProvider;
        private readonly IModelSupportsBodyTypeFiltersProvider _modelBodyTypeFiltersProvider;

        public CarBodyTypeAssignCommandValidator(IGenericReadRepository readRepository, ICarModelFiltersProvider modelFiltersProvider, ICarBodyTypeFiltersProvider bodyTypeFiltersProvider, IModelSupportsBodyTypeFiltersProvider modelBodyTypeFiltersProvider) : base(readRepository)
        {
            _modelFiltersProvider = modelFiltersProvider;
            _bodyTypeFiltersProvider = bodyTypeFiltersProvider;
            _modelBodyTypeFiltersProvider = modelBodyTypeFiltersProvider;

            RuleFor(x => x.ModelId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(ModelExists);

            RuleFor(x => x.BodyTypeId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(BodyTypeExists);

            RuleFor(x => x.Price)
                .IsPositiveOrZeroWithMessage();
        }

        protected override bool PreValidate(ValidationContext<CarBodyTypeAssignCommand> context, ValidationResult result)
        {
            var isExists = ReadRepository.ValidateExists(_modelBodyTypeFiltersProvider.ByModelIdAndBodyTypeId(context.InstanceToValidate.ModelId, context.InstanceToValidate.BodyTypeId));

            if (isExists)
            {
                result.Errors.Add(new ValidationFailure("", "Body Type is already assigned!"));
                return false;
            }
            return true;
        }

        private async Task<bool> ModelExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_modelFiltersProvider.ById(id)), cancellationToken);
        }

        private async Task<bool> BodyTypeExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_bodyTypeFiltersProvider.ById(id)), cancellationToken);
        }
    }
}
