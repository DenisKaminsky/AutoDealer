using AutoDealer.Business.Interfaces.Models;
using AutoDealer.Miscellaneous.Interfaces;

namespace AutoDealer.Business.Models.Commands.Car
{
    public class CarPhotoCreateCommand : ICreateCommand
    {
        public int CarId { get; set; }
        public IFileAttachment Photo { get; set; }
    }
}
