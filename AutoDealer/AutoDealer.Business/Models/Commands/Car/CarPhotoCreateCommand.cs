using AutoDealer.Business.Interfaces.Models;
using AutoDealer.Miscellaneous.Interfaces;

namespace AutoDealer.Business.Models.Commands.Car
{
    public class CarPhotoCreateCommand : ICreateCommand
    {
        public int ModelId { get; set; }
        public int BodyTypeId { get; set; }
        public int ColorId { get; set; }
        public IFileAttachment Photo { get; set; }
    }
}
