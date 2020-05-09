using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.WorkOrder;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.WorkOrder;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Constraints.WorkOrder;

namespace AutoDealer.Business.Validators.WorkOrder
{
    public class WorkOrderClientUpdateCommandValidator : BaseValidator<WorkOrderClientUpdateCommand>
    {
        private readonly IWorkOrderClientFiltersProvider _filtersProvider;

        public WorkOrderClientUpdateCommandValidator(IGenericReadRepository readRepository, IWorkOrderClientFiltersProvider filtersProvider) : base(readRepository)
        {
            _filtersProvider = filtersProvider;

            RuleFor(x => x.Id)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(ClientExists);

            RuleFor(x => x.FirstName)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(WorkOrderClientConstraints.FirstNameMaxLength);

            RuleFor(x => x.LastName)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(WorkOrderClientConstraints.LastNameMaxLength);

            RuleFor(x => x.Phone)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(WorkOrderClientConstraints.PhoneMaxLength)
                .IsValidPhoneNumberWithMessage();
        }

        private async Task<bool> ClientExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_filtersProvider.ById(id)), cancellationToken);
        }
    }
}
