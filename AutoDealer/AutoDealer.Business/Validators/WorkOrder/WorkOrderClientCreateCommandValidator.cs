using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.WorkOrder;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Constraints.WorkOrder;

namespace AutoDealer.Business.Validators.WorkOrder
{
    public class WorkOrderClientCreateCommandValidator : BaseValidator<WorkOrderClientCreateCommand>
    {
        public WorkOrderClientCreateCommandValidator(IGenericReadRepository readRepository) : base(readRepository)
        {
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
    }
}
