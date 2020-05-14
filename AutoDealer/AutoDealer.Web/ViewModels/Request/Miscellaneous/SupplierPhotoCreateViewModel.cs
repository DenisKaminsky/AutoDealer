using Microsoft.AspNetCore.Http;

namespace AutoDealer.Web.ViewModels.Request.Miscellaneous
{
    public class SupplierPhotoCreateViewModel
    {
        public int SupplierId { get; set; }
        public IFormFile Photo { get; set; }
    }
}
