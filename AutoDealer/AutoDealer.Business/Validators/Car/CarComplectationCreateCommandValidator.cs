using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Constraints.Car;

namespace AutoDealer.Business.Validators.Car
{
    public class CarComplectationCreateCommandValidator : BaseValidator<CarComplectationCreateCommand>
    {
        private readonly ICarModelFiltersProvider _modelFiltersProvider;
        private readonly ICarComplectationFiltersProvider _complectationFiltersProvider;

        public CarComplectationCreateCommandValidator(IGenericReadRepository readRepository, ICarModelFiltersProvider modelFiltersProvider, ICarComplectationFiltersProvider complectationFiltersProvider) : base(readRepository)
        {
            _modelFiltersProvider = modelFiltersProvider;
            _complectationFiltersProvider = complectationFiltersProvider;

            RuleFor(x => x.Name)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(CarComplectationConstraints.NameMaxLength)
                .MustNotExistWithMessageAsync(NameDoesNotExist);

            RuleFor(x => x.Price)
                .IsPositiveOrZeroWithMessage();

            RuleFor(x => x.ModelId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(ModelExists);
        }

        private async Task<bool> NameDoesNotExist(string name, CancellationToken cancellationToken)
        {
            return await Task.Run(() => !ReadRepository.ValidateExists(_complectationFiltersProvider.ByName(name)), cancellationToken);
        }

        private async Task<bool> ModelExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_modelFiltersProvider.ById(id)), cancellationToken);
        }
    }
}
