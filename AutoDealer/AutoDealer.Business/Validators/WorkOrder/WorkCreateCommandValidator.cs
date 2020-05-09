using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.WorkOrder;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Constraints.WorkOrder;

namespace AutoDealer.Business.Validators.WorkOrder
{
    public class WorkCreateCommandValidator : BaseValidator<WorkCreateCommand>
    {
        public WorkCreateCommandValidator(IGenericReadRepository readRepository) : base(readRepository)
        {
            RuleFor(x => x.Name)
                .NotEmptyWithMessage()
                .MaxLengthWithMessage(WorkConstraints.NameMaxLength);

            RuleFor(x => x.Price)
                .IsPositiveOrZeroWithMessage();
        }
    }
}
