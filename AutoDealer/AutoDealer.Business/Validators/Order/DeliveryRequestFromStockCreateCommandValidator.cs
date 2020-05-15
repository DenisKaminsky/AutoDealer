using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Order;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.User;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Enums;

namespace AutoDealer.Business.Validators.Order
{
    public class DeliveryRequestFromStockCreateCommandValidator : BaseValidator<DeliveryRequestFromStockCreateCommand>
    {
        private readonly ICarStockFiltersProvider _carStockFiltersProvider;
        private readonly IUserFiltersProvider _userFiltersProvider;

        public DeliveryRequestFromStockCreateCommandValidator(IGenericReadRepository readRepository, ICarStockFiltersProvider carStockFiltersProvider, IUserFiltersProvider userFiltersProvider) : base(readRepository)
        {
            _carStockFiltersProvider = carStockFiltersProvider;
            _userFiltersProvider = userFiltersProvider;

            RuleFor(x => x.CarId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(CarExists);

            RuleFor(x => x.ManagerId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(ManagerIsValid);

            RuleFor(x => x.Amount)
                .IsPositiveWithMessage();
        }

        private async Task<bool> CarExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_carStockFiltersProvider.InStockById(id)), cancellationToken);
        }

        private async Task<bool> ManagerIsValid(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_userFiltersProvider.ActiveByIdAndRoleId(id, (int)UserRoles.Manager)), cancellationToken);
        }
    }
}
