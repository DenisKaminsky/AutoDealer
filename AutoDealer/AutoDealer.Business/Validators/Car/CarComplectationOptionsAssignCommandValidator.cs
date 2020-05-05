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
    public class CarComplectationOptionsAssignCommandValidator : BaseValidator<CarComplectationOptionsAssignCommand>
    {
        private readonly ICarComplectationFiltersProvider _filtersProvider;

        public CarComplectationOptionsAssignCommandValidator(IGenericReadRepository readRepository, ICarComplectationFiltersProvider filtersProvider) : base(readRepository)
        {
            _filtersProvider = filtersProvider;

            RuleFor(x => x.ComplectationId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(ComplectationExists);

            RuleForEach(x => x.Options)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(CarComplectationConstraints.NameMaxLength);
        }

        private async Task<bool> ComplectationExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_filtersProvider.ById(id)), cancellationToken);
        }
    }
}
