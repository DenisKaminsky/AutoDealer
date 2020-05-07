using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.Repositories;
using FluentValidation;

namespace AutoDealer.Business.Validators.Car
{
    public class CarStockUpdateCommandValidator : BaseValidator<CarStockUpdateCommand>
    {
        private readonly ICarModelFiltersProvider _modelFiltersProvider;
        private readonly IModelSupportsBodyTypeFiltersProvider _modelBodyTypeFiltersProvider;
        private readonly IModelSupportsColorFiltersProvider _modelColorFiltersProvider;
        private readonly ICarComplectationFiltersProvider _complectationFiltersProvider;
        private readonly IEngineSupportsGearboxFiltersProvider _engineGearboxFiltersProvider;
        private readonly ICarStockFiltersProvider _carStockFiltersProvider;

        public CarStockUpdateCommandValidator(IGenericReadRepository readRepository, IModelSupportsBodyTypeFiltersProvider modelBodyTypeFiltersProvider, ICarModelFiltersProvider modelFiltersProvider, IModelSupportsColorFiltersProvider modelColorFiltersProvider, ICarComplectationFiltersProvider complectationFiltersProvider, IEngineSupportsGearboxFiltersProvider engineGearboxFiltersProvider, ICarStockFiltersProvider carStockFiltersProvider) : base(readRepository)
        {
            _modelBodyTypeFiltersProvider = modelBodyTypeFiltersProvider;
            _modelFiltersProvider = modelFiltersProvider;
            _modelColorFiltersProvider = modelColorFiltersProvider;
            _complectationFiltersProvider = complectationFiltersProvider;
            _engineGearboxFiltersProvider = engineGearboxFiltersProvider;
            _carStockFiltersProvider = carStockFiltersProvider;

            RuleFor(x => x.Id)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(CarExists);

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

            RuleFor(x => x.Amount)
                .IsPositiveOrZeroWithMessage();

            RuleFor(x => x.Price)
                .IsPositiveOrZeroWithMessage();
        }

        private async Task<bool> CarExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_carStockFiltersProvider.ById(id)), cancellationToken);
        }

        private async Task<bool> ModelExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_modelFiltersProvider.ById(id)), cancellationToken);
        }

        private async Task<bool> BodyTypeIsValid(CarStockUpdateCommand model, int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_modelBodyTypeFiltersProvider.ByModelIdAndBodyTypeId(model.ModelId, model.BodyTypeId)), cancellationToken);
        }

        private async Task<bool> ColorIsValid(CarStockUpdateCommand model, int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_modelColorFiltersProvider.ByModelIdAndColorId(model.ModelId, model.ColorId)), cancellationToken);
        }

        private async Task<bool> EngineGearboxIsValid(CarStockUpdateCommand model, int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_engineGearboxFiltersProvider.ByModelEngineGearbox(model.ModelId, model.EngineGearboxId)), cancellationToken);
        }

        private async Task<bool> ComplectationIsValid(CarStockUpdateCommand model, int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_complectationFiltersProvider.ByModelIdAndComplectationId(model.ModelId, model.ComplectationId)), cancellationToken);
        }
    }
}
