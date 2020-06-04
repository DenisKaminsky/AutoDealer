using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Order;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Order;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.User;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Enums;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AutoDealer.Business.Validators.Order
{
    public class DeliveryRequestAssignCommandValidator : BaseValidator<DeliveryRequestAssignCommand>
    {
        private readonly IDeliveryRequestFiltersProvider _deliveryRequestFiltersProvider;
        private readonly IUserFiltersProvider _userFiltersProvider;

        public DeliveryRequestAssignCommandValidator(IGenericReadRepository readRepository, IDeliveryRequestFiltersProvider deliveryRequestFiltersProvider, IUserFiltersProvider userFiltersProvider) : base(readRepository)
        {
            _deliveryRequestFiltersProvider = deliveryRequestFiltersProvider;
            _userFiltersProvider = userFiltersProvider;
            RuleFor(x => x.DeliveryRequestId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(DeliveryRequestExists)
                .Custom(async (deliveryRequestId, context) =>
                {
                    var query = await ReadRepository.GetQueryableAsync(_deliveryRequestFiltersProvider.ById(deliveryRequestId));
                    var deliveryRequestStatus = (DeliveryRequestStatuses)await query.Select(x => x.StatusId).FirstOrDefaultAsync();

                    string errorMessage;
                    switch (deliveryRequestStatus)
                    {
                        case DeliveryRequestStatuses.Opened:
                            errorMessage = string.Empty;
                            break;
                        case DeliveryRequestStatuses.Closed:
                            errorMessage = "Delivery request is closed.";
                            break;
                        default:
                            errorMessage = "Delivery request is already assigned.";
                            break;
                    }

                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        context.AddFailure(nameof(DeliveryRequestAssignCommand.DeliveryRequestId), errorMessage);
                    }
                });

            RuleFor(x => x.SupplierManagerId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(SupplierManagerIsValid);
        }

        private async Task<bool> DeliveryRequestExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_deliveryRequestFiltersProvider.ById(id)), cancellationToken);
        }

        private async Task<bool> SupplierManagerIsValid(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_userFiltersProvider.ActiveByIdAndRoleId(id, (int)UserRoles.SupplierManager)), cancellationToken);
        }
    }
}
