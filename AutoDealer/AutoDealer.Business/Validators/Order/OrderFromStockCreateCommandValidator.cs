using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Models.Commands.Order;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Business.Validators.Order
{
    public class OrderFromStockCreateCommandValidator : BaseValidator<OrderFromStockCreateCommand>
    {
        private readonly ICarStockFiltersProvider _carStockFiltersProvider;

        public OrderFromStockCreateCommandValidator(IGenericReadRepository readRepository, IValidator<OrderWithDeliveryRequestCreateCommand> validator, ICarStockFiltersProvider carStockFiltersProvider) : base(readRepository)
        {
            _carStockFiltersProvider = carStockFiltersProvider;

            RuleFor(x => x)
                .SetValidator(validator)
                .MustAsync(CarAmountIsValid)
                .WithMessage("There are not enough cars in stock to create an order.");
        }

        private async Task<bool> CarAmountIsValid(OrderFromStockCreateCommand command, CancellationToken cancellationToken)
        {
            var query = await ReadRepository.GetQueryableAsync(_carStockFiltersProvider.ById(command.CarId));
            var amount = await query.Select(x => x.Amount).FirstOrDefaultAsync(cancellationToken);

            return amount >= 1;
        }
    }
}
