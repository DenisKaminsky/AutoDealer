using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Order;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.User;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Enums;
using FluentValidation;

namespace AutoDealer.Business.Validators.Order
{
    public class DeliveryRequestCreateCommandValidator : BaseValidator<DeliveryRequestCreateCommand>
    {
        private readonly ICarModelFiltersProvider _modelFiltersProvider;
        private readonly IModelSupportsBodyTypeFiltersProvider _modelBodyTypeFiltersProvider;
        private readonly IModelSupportsColorFiltersProvider _modelColorFiltersProvider;
        private readonly ICarComplectationFiltersProvider _complectationFiltersProvider;
        private readonly IEngineSupportsGearboxFiltersProvider _engineGearboxFiltersProvider;
        private readonly IUserFiltersProvider _userFiltersProvider;

        public DeliveryRequestCreateCommandValidator(IGenericReadRepository readRepository, ICarModelFiltersProvider modelFiltersProvider, 
            IModelSupportsBodyTypeFiltersProvider modelBodyTypeFiltersProvider, IModelSupportsColorFiltersProvider modelColorFiltersProvider, 
            ICarComplectationFiltersProvider complectationFiltersProvider, IEngineSupportsGearboxFiltersProvider engineGearboxFiltersProvider, IUserFiltersProvider userFiltersProvider) : base(readRepository)
        {
            _modelFiltersProvider = modelFiltersProvider;
            _modelBodyTypeFiltersProvider = modelBodyTypeFiltersProvider;
            _modelColorFiltersProvider = modelColorFiltersProvider;
            _complectationFiltersProvider = complectationFiltersProvider;
            _engineGearboxFiltersProvider = engineGearboxFiltersProvider;
            _userFiltersProvider = userFiltersProvider;

            RuleFor(x => x.ModelId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(ModelExists)
                .DependentRules(() =>
                {
                    RuleFor(x => x.BodyTypeId)
                        .NotEmptyWithMessage()
                        .MustAsync(BodyTypeIsValid)
                        .WithMessage($"The {{PropertyName}} is not compatible with the provided model.");

                    RuleFor(x => x.ColorId)
                        .NotEmptyWithMessage()
                        .MustAsync(ColorIsValid)
                        .WithMessage($"The {{PropertyName}} is not compatible with the provided model.");

                    RuleFor(x => x.EngineGearboxId)
                        .NotEmptyWithMessage()
                        .MustAsync(EngineGearboxIsValid)
                        .WithMessage($"The {{PropertyName}} is not compatible with the provided model.");

                    RuleFor(x => x.ComplectationId)
                        .NotEmptyWithMessage()
                        .MustAsync(ComplectationIsValid)
                        .WithMessage($"The {{PropertyName}} is not compatible with the provided model.");
                });

            RuleFor(x => x.ManagerId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(ManagerIsValid);

            RuleFor(x => x.Amount)
                .IsPositiveWithMessage();
        }

        private async Task<bool> ModelExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_modelFiltersProvider.ById(id)), cancellationToken);
        }

        private async Task<bool> BodyTypeIsValid(DeliveryRequestCreateCommand model, int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_modelBodyTypeFiltersProvider.ByModelIdAndBodyTypeId(model.ModelId, model.BodyTypeId)), cancellationToken);
        }

        private async Task<bool> ColorIsValid(DeliveryRequestCreateCommand model, int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_modelColorFiltersProvider.ByModelIdAndColorId(model.ModelId, model.ColorId)), cancellationToken);
        }

        private async Task<bool> EngineGearboxIsValid(DeliveryRequestCreateCommand model, int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_engineGearboxFiltersProvider.ByModelEngineGearbox(model.ModelId, model.EngineGearboxId)), cancellationToken);
        }

        private async Task<bool> ComplectationIsValid(DeliveryRequestCreateCommand model, int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_complectationFiltersProvider.ByModelIdAndComplectationId(model.ModelId, model.ComplectationId)), cancellationToken);
        }

        private async Task<bool> ManagerIsValid(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_userFiltersProvider.ActiveByIdAndRoleId(id, (int)UserRoles.Manager)), cancellationToken);
        }
    }
}
