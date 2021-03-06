﻿using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.Repositories;
using FluentValidation;

namespace AutoDealer.Business.Validators.Car
{
    public class CarStockCreateCommandValidator : BaseValidator<CarStockCreateCommand>
    {
        private readonly ICarModelFiltersProvider _modelFiltersProvider;
        private readonly IModelSupportsBodyTypeFiltersProvider _modelBodyTypeFiltersProvider;
        private readonly IModelSupportsColorFiltersProvider _modelColorFiltersProvider;
        private readonly ICarComplectationFiltersProvider _complectationFiltersProvider;
        private readonly IEngineSupportsGearboxFiltersProvider _engineGearboxFiltersProvider;

        public CarStockCreateCommandValidator(IGenericReadRepository readRepository, IModelSupportsBodyTypeFiltersProvider modelBodyTypeFiltersProvider, 
            ICarModelFiltersProvider modelFiltersProvider, IModelSupportsColorFiltersProvider modelColorFiltersProvider, 
            ICarComplectationFiltersProvider complectationFiltersProvider, IEngineSupportsGearboxFiltersProvider engineGearboxFiltersProvider) : base(readRepository)
        {
            _modelBodyTypeFiltersProvider = modelBodyTypeFiltersProvider;
            _modelFiltersProvider = modelFiltersProvider;
            _modelColorFiltersProvider = modelColorFiltersProvider;
            _complectationFiltersProvider = complectationFiltersProvider;
            _engineGearboxFiltersProvider = engineGearboxFiltersProvider;

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
        }
        
        private async Task<bool> ModelExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_modelFiltersProvider.ById(id)), cancellationToken);
        }

        private async Task<bool> BodyTypeIsValid(CarStockCreateCommand model, int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_modelBodyTypeFiltersProvider.ByModelIdAndBodyTypeId(model.ModelId, model.BodyTypeId)), cancellationToken);
        }

        private async Task<bool> ColorIsValid(CarStockCreateCommand model, int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_modelColorFiltersProvider.ByModelIdAndColorId(model.ModelId, model.ColorId)), cancellationToken);
        }

        private async Task<bool> EngineGearboxIsValid(CarStockCreateCommand model, int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_engineGearboxFiltersProvider.ByModelEngineGearbox(model.ModelId, model.EngineGearboxId)), cancellationToken);
        }

        private async Task<bool> ComplectationIsValid(CarStockCreateCommand model, int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_complectationFiltersProvider.ByModelIdAndComplectationId(model.ModelId, model.ComplectationId)), cancellationToken);
        }
    }
}
