using AutoDealer.Business.Models.Responses.File;
using AutoDealer.Data.Models.Car;
using AutoDealer.Data.Models.Miscellaneous;

namespace AutoDealer.Business.Extensions
{
    public static class ModelsExtensions
    {
        public static FileModel ToFileModel(this CarPhoto carPhoto, byte[] content)
        {
            return new FileModel(carPhoto.Id, carPhoto.FileName, carPhoto.FileSize, content);
        }

        public static FileModel ToFileModel(this SupplierPhoto supplierPhoto, byte[] content)
        {
            return new FileModel(supplierPhoto.Id, supplierPhoto.FileName, supplierPhoto.FileSize, content);
        }
    }
}
