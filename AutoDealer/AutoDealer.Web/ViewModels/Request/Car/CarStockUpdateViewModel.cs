namespace AutoDealer.Web.ViewModels.Request.Car
{
    public class CarStockUpdateViewModel : CarStockCreateViewModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
    }
}
