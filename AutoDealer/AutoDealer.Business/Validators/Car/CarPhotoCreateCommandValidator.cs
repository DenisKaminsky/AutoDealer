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
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Constraints.Car;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Miscellaneous.Interfaces;
using FluentValidation;

namespace AutoDealer.Business.Validators.Car
{
    public class CarPhotoCreateCommandValidator : BaseValidator<CarPhotoCreateCommand>
    {
        private readonly ICarStockFiltersProvider _carStockFiltersProvider;

        public CarPhotoCreateCommandValidator(IGenericReadRepository readRepository, ICarStockFiltersProvider carStockFiltersProvider) : base(readRepository)
        {
            _carStockFiltersProvider = carStockFiltersProvider;
            CascadeMode = CascadeMode.Continue;

            RuleFor(x => x.CarId)
                .MustExistsWithMessageAsync(CarExists);

            RuleFor(x => x.Photo)
                .MustAsync(FileSizeIsValid)
                .WithMessage($"File size should be up to {CarPhotoConstraints.FileMaxSize/1000000.0f}MB")
                .MustAsync(FileTypeIsValid)
                .WithMessage($"File type is prohibited. Allowed types - {GetSupportedFileTypesString()}"); 
        }

        private async Task<bool> CarExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_carStockFiltersProvider.ById(id)), cancellationToken);
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
