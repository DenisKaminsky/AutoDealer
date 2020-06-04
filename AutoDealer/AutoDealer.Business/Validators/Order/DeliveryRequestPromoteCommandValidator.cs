using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Order;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Order;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Enums;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Business.Validators.Order
{
    public class DeliveryRequestPromoteCommandValidator : BaseValidator<DeliveryRequestPromoteCommand>
    {
        private readonly IDeliveryRequestFiltersProvider _deliveryRequestFiltersProvider;

        public DeliveryRequestPromoteCommandValidator(IGenericReadRepository readRepository, IDeliveryRequestFiltersProvider deliveryRequestFiltersProvider) : base(readRepository)
        {
            _deliveryRequestFiltersProvider = deliveryRequestFiltersProvider;

            RuleFor(x => x.DeliveryRequestId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(DeliveryRequestExists)
                .CustomAsync(async (deliveryRequestId, context, cancellationToken) =>
                {
                    var query = await ReadRepository.GetQueryableAsync(deliveryRequestFiltersProvider.ById(deliveryRequestId));
                    var deliveryRequestStatus = (DeliveryRequestStatuses)await query.Select(x => x.StatusId).FirstOrDefaultAsync();

                    string errorMessage;
                    switch (deliveryRequestStatus)
                    {
                        case DeliveryRequestStatuses.Opened:
                            errorMessage = "Delivery request is not assigned to the user.";
                            break;
                        case DeliveryRequestStatuses.Closed:
                            errorMessage = "Delivery request is closed.";
                            break;
                        default:
                            errorMessage = string.Empty;
                            break;
                    }

                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        context.AddFailure(nameof(DeliveryRequestAssignCommand.DeliveryRequestId), errorMessage);
                    }
                });
        }

        private async Task<bool> DeliveryRequestExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_deliveryRequestFiltersProvider.ById(id)), cancellationToken);
        }
    }
}
