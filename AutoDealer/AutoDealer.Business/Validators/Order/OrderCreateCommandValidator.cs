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
    public class OrderCreateCommandValidator : BaseValidator<OrderCreateCommand>
    {
        private readonly ICarStockFiltersProvider _carStockFiltersProvider;
        private readonly IUserFiltersProvider _userFiltersProvider;
        private readonly IClientFiltersProvider _clientFiltersProvider;

        public OrderCreateCommandValidator(IGenericReadRepository readRepository, ICarStockFiltersProvider carStockFiltersProvider, IUserFiltersProvider userFiltersProvider, IClientFiltersProvider clientFiltersProvider) : base(readRepository)
        {
            _carStockFiltersProvider = carStockFiltersProvider;
            _userFiltersProvider = userFiltersProvider;
            _clientFiltersProvider = clientFiltersProvider;

            RuleFor(x => x.CarId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(CarExists);

            RuleFor(x => x.ManagerId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(ManagerIsValid);

            RuleFor(x => x.ClientId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(ClientIsValid);
        }

        private async Task<bool> CarExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_carStockFiltersProvider.InStockById(id)), cancellationToken);
        }

        private async Task<bool> ManagerIsValid(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_userFiltersProvider.ActiveByIdAndRoleId(id, (int)UserRoles.Manager)), cancellationToken);
        }

        private async Task<bool> ClientIsValid(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_clientFiltersProvider.ById(id)), cancellationToken);
        }
    }
}
