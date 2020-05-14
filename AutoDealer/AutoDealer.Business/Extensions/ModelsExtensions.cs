using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Business.Models.Commands.Miscellaneous;
using AutoDealer.Business.Models.Responses.File;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.Models.Miscellaneous;

namespace AutoDealer.Business.Extensions
{
    public static class ModelsExtensions
    {
        public static FileModel ToFileModel(this CarPhoto carPhoto, byte[] content)
        {
            return new FileModel(carPhoto.Id, carPhoto.FileName, content);
        }

        public static FileModel ToFileModel(this SupplierPhoto supplierPhoto, byte[] content)
        {
            return new FileModel(supplierPhoto.Id, supplierPhoto.FileName, content);
        }

        public static CarPhoto ToCarPhoto(this CarPhotoCreateCommand command, string filename)
        {
            return new CarPhoto {CarId = command.CarId, FileName = filename};
        }

        public static SupplierPhoto ToSupplierPhoto(this SupplierPhotoCreateCommand command, string filename)
        {
            return new SupplierPhoto { SupplierId = command.SupplierId, FileName = filename };
        }
    }
}
