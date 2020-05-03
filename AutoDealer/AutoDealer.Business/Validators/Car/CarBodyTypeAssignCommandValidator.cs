using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.Repositories;

namespace AutoDealer.Business.Validators.Car
{
    public class CarBodyTypeAssignCommandValidator : BaseValidator<CarBodyTypeAssignCommand>
    {
        private readonly ICarModelFiltersProvider _modelFiltersProvider;
        private readonly ICarBodyTypeFiltersProvider _bodyTypeFiltersProvider;

        public CarBodyTypeAssignCommandValidator(IGenericReadRepository readRepository, ICarModelFiltersProvider modelFiltersProvider, ICarBodyTypeFiltersProvider bodyTypeFiltersProvider) : base(readRepository)
        {
            _modelFiltersProvider = modelFiltersProvider;
            _bodyTypeFiltersProvider = bodyTypeFiltersProvider;

            RuleFor(x => x.ModelId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(ModelExists);

            RuleFor(x => x.BodyTypeId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(BodyTypeExists);

            RuleFor(x => x.Price)
                .IsPositiveOrZeroWithMessage();
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
