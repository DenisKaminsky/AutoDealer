using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Interfaces.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace AutoDealer.Business.Validators.Car
{
    public class CarColorAssignmentCommandValidator : BaseValidator<CarColorAssignmentCommand>
    {
        private readonly ICarModelFiltersProvider _modelFiltersProvider;
        private readonly IColorCodeFiltersProvider _colorFiltersProvider;
        private readonly IModelSupportsColorFiltersProvider _modelColorFiltersProvider;

        public CarColorAssignmentCommandValidator(IGenericReadRepository readRepository, ICarModelFiltersProvider modelFiltersProvider, IColorCodeFiltersProvider colorFiltersProvider, IModelSupportsColorFiltersProvider modelColorFiltersProvider) : base(readRepository)
        {
            _modelFiltersProvider = modelFiltersProvider;
            _colorFiltersProvider = colorFiltersProvider;
            _modelColorFiltersProvider = modelColorFiltersProvider;

            RuleFor(x => x.ModelId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(ModelExists);

            RuleFor(x => x.ColorId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(ColorExists);
        }

        protected override bool PreValidate(ValidationContext<CarColorAssignmentCommand> context, ValidationResult result)
        {
            var isExists = ReadRepository.ValidateExists(_modelColorFiltersProvider.ByModelIdAndColorId(context.InstanceToValidate.ModelId,context.InstanceToValidate.ColorId));

            if (isExists)
            {
                result.Errors.Add(new ValidationFailure("", "Color is already assigned!"));
                return false;
            }
            return true;
        }

        private async Task<bool> ModelExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_modelFiltersProvider.ById(id)), cancellationToken);
        }

        private async Task<bool> ColorExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_colorFiltersProvider.ById(id)), cancellationToken);
        }
    }
}
