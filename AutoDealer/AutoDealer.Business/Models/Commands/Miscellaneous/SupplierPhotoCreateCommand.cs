using AutoDealer.Business.Interfaces.Models;
using AutoDealer.Miscellaneous.Interfaces;

namespace AutoDealer.Business.Models.Commands.Miscellaneous
{
    public class SupplierPhotoCreateCommand : ICreateCommand
    {
        public int SupplierId { get; set; }
        public IFileAttachment Photo { get; set; }
    }
}
