using Microsoft.AspNetCore.Http;

namespace AutoDealer.Web.ViewModels.Request.Car
{
    public class CarPhotoCreateViewModel
    {
        public int CarId { get; set; }
        public IFormFile Photo { get; set; }
    }
}
