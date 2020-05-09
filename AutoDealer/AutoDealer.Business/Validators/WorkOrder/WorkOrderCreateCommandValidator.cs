using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.WorkOrder;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.User;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.WorkOrder;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Enums;
using FluentValidation;

namespace AutoDealer.Business.Validators.WorkOrder
{
    public class WorkOrderCreateCommandValidator : BaseValidator<WorkOrderCreateCommand>
    {
        private readonly IUserFiltersProvider _userFiltersProvider;
        private readonly IWorkFiltersProvider _workFiltersProvider;

        public WorkOrderCreateCommandValidator(IGenericReadRepository readRepository, IUserFiltersProvider userFiltersProvider,
            IValidator<WorkOrderClientCreateCommand> clientValidator, IWorkFiltersProvider workFiltersProvider) : base(readRepository)
        {
            _userFiltersProvider = userFiltersProvider;
            _workFiltersProvider = workFiltersProvider;

            RuleFor(x => x.WorkerId)
                .NotEmptyWithMessage()
                .MustAsync(WorkerIsValid)
                .WithMessage($"The {{PropertyName}} is invalid. User should be Active and has ServiceMan role.");

            RuleFor(x => x.Client)
                .SetValidator(clientValidator);

            RuleFor(x => x.WorksIds)
                .NotEmptyWithMessage();

            RuleForEach(x => x.WorksIds)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(WorkExists);
        }

        private async Task<bool> WorkerIsValid(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_userFiltersProvider.ActiveByIdAndRoleId(id, (int)UserRoles.ServiceMan)), cancellationToken);
        }

        private async Task<bool> WorkExists(int workId, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_workFiltersProvider.ById(workId)), cancellationToken);
        }
    }
}
