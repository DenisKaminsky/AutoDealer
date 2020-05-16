using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Car;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Constraints.Car;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Miscellaneous.Interfaces;
using FluentValidation;

namespace AutoDealer.Business.Validators.Car
{
    public class CarPhotoCreateCommandValidator : BaseValidator<CarPhotoCreateCommand>
    {
        private readonly ICarModelFiltersProvider _modelFiltersProvider;
        private readonly ICarBodyTypeFiltersProvider _bodyTypeFiltersProvider;
        private readonly IColorCodeFiltersProvider _colorFiltersProvider;

        public CarPhotoCreateCommandValidator(IGenericReadRepository readRepository, ICarModelFiltersProvider modelFiltersProvider, ICarBodyTypeFiltersProvider bodyTypeFiltersProvider, IColorCodeFiltersProvider colorFiltersProvider) : base(readRepository)
        {
            _modelFiltersProvider = modelFiltersProvider;
            _bodyTypeFiltersProvider = bodyTypeFiltersProvider;
            _colorFiltersProvider = colorFiltersProvider;

            RuleFor(x => x.ModelId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(ModelExists);

            RuleFor(x => x.BodyTypeId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(BodyTypeExists);

            RuleFor(x => x.ColorId)
                .NotEmptyWithMessage()
                .MustExistsWithMessageAsync(ColorExists);

            RuleFor(x => x.Photo)
                .NotEmptyWithMessage()
                .DependentRules(() =>
                {
                    RuleFor(x => x.Photo)
                        .Cascade(CascadeMode.Continue)
                        .MustAsync(FileSizeIsValid)
                        .WithMessage($"File size should be up to {CarPhotoConstraints.FileMaxSize / 1000000.0f}MB")
                        .MustAsync(FileTypeIsValid)
                        .WithMessage($"File type is prohibited. Allowed types - {GetSupportedFileTypesString()}");
                });
        }

        private async Task<bool> ModelExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_modelFiltersProvider.ById(id)), cancellationToken);
        }

        private async Task<bool> BodyTypeExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_bodyTypeFiltersProvider.ById(id)), cancellationToken);
        }

        private async Task<bool> ColorExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_colorFiltersProvider.ById(id)), cancellationToken);
        }

        private Task<bool> FileSizeIsValid(IFileAttachment file, CancellationToken cancellationToken)
        {
            return Task.Run(() => file.FileSize <= CarPhotoConstraints.FileMaxSize, cancellationToken);
        }

        private Task<bool> FileTypeIsValid(IFileAttachment file, CancellationToken cancellationToken)
        {
            var supportedTypes = GetSupportedFileTypes();
            var type = Path.GetExtension(file.FileName).Replace(".", "");

            return Task.Run(() => supportedTypes.Contains(type, StringComparer.OrdinalIgnoreCase), cancellationToken);
        }

        private IEnumerable<string> GetSupportedFileTypes()
        {
            return Enum.GetValues(typeof(SupportedPhotoExtensions)).Cast<SupportedPhotoExtensions>()
                .Select(x => x.ToString());
        }

        private string GetSupportedFileTypesString()
        {
            var supportedTypes = GetSupportedFileTypes();
            return string.Join(", ", supportedTypes);
        }
    }
}
