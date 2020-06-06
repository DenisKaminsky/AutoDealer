using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Order;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Order;
using AutoDealer.Data.Interfaces.RelationsProviders.Order;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Enums;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Business.Validators.Order
{
    public class OrderPromoteCommandValidator : BaseValidator<OrderPromoteCommand>
    {
        private readonly IOrderFiltersProvider _orderFiltersProvider;

        public OrderPromoteCommandValidator(IGenericReadRepository readRepository, IOrderFiltersProvider orderFiltersProvider, IOrderRelationsProvider orderRelationsProvider) : base(readRepository)
        {
            _orderFiltersProvider = orderFiltersProvider;

            RuleFor(x => x.OrderId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(OrderExists)
                .CustomAsync(async (orderId, context, cancellationToken) =>
                {
                    var query = await ReadRepository.GetQueryableAsync(_orderFiltersProvider.ById(orderId), orderRelationsProvider.JoinDeliveryRequest);
                    var orderInfo = query
                        .Select(x => new
                        {
                            OrderStatus = x.StatusId, 
                            DeliveryRequestStatus = x.DeliveryRequest != null ? x.DeliveryRequest.StatusId : (int?)null
                        })
                        .FirstOrDefault();

                    if ((OrderStatuses)orderInfo.OrderStatus == OrderStatuses.Completed)
                    {
                        context.AddFailure(nameof(OrderPromoteCommand.OrderId), "Order is completed.");
                        return;
                    }

                    if (orderInfo.DeliveryRequestStatus.HasValue && (DeliveryRequestStatuses)orderInfo.DeliveryRequestStatus != DeliveryRequestStatuses.Closed)
                    {
                        context.AddFailure(nameof(OrderPromoteCommand.OrderId), "You cannot promote the order until the corresponding delivery request is completed.");
                    }
                });
        }

        private async Task<bool> OrderExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_orderFiltersProvider.ById(id)), cancellationToken);
        }
    }
}
