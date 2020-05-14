using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoDealer.Business.Extensions;
using AutoDealer.Business.Models.Commands.Miscellaneous;
using AutoDealer.Business.Validators.Base;
using AutoDealer.Data.Interfaces.QueryFiltersProviders.Miscellaneous;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Miscellaneous.Constraints.Miscellaneous;
using AutoDealer.Miscellaneous.Enums;
using AutoDealer.Miscellaneous.Interfaces;
using FluentValidation;

namespace AutoDealer.Business.Validators.Miscellaneous
{
    public class SupplierPhotoCreateCommandValidator : BaseValidator<SupplierPhotoCreateCommand>
    {
        private readonly ISupplierFiltersProvider _supplierFiltersProvider;

        public SupplierPhotoCreateCommandValidator(IGenericReadRepository readRepository, ISupplierFiltersProvider supplierFiltersProvider) : base(readRepository)
        {
            _supplierFiltersProvider = supplierFiltersProvider;
            CascadeMode = CascadeMode.Continue;

            RuleFor(x => x.SupplierId)
                .MustExistsWithMessageAsync(SupplierExists);

            RuleFor(x => x.Photo)
                .MustAsync(FileSizeIsValid)
                .WithMessage($"File size should be up to {SupplierPhotoConstraints.FileMaxSize/1000000.0f}MB")
                .MustAsync(FileTypeIsValid)
                .WithMessage($"File type is prohibited. Allowed types - {GetSupportedFileTypesString()}");
        }

        private async Task<bool> SupplierExists(int id, CancellationToken cancellationToken)
        {
            return await Task.Run(() => ReadRepository.ValidateExists(_supplierFiltersProvider.ById(id)), cancellationToken);
        }

        private Task<bool> FileSizeIsValid(IFileAttachment file, CancellationToken cancellationToken)
        {
            return Task.Run(() => file.FileSize <= SupplierPhotoConstraints.FileMaxSize, cancellationToken);
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
