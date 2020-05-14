using AutoDealer.Data.Models.Base;

namespace AutoDealer.Data.Models.Miscellaneous
{
    public class SupplierPhoto : BaseModel
    {
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public string FileName { get; set; }
    }
}
