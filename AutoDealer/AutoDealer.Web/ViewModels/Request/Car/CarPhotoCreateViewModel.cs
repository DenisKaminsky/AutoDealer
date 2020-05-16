using Microsoft.AspNetCore.Http;

namespace AutoDealer.Web.ViewModels.Request.Car
{
    public class CarPhotoCreateViewModel
    {
        public int ModelId { get; set; }
        public int BodyTypeId { get; set; }
        public int ColorId { get; set; }
        public IFormFile Photo { get; set; }
    }
}
