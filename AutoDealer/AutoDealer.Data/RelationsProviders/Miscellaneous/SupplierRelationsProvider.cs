using AutoDealer.Data.Interfaces.RelationsProviders.Miscellaneous;
using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Data.RelationsProviders.Base;

namespace AutoDealer.Data.RelationsProviders.Miscellaneous
{
    public class SupplierRelationsProvider : BaseRelationsProvider, ISupplierRelationsProvider
    {
        public string[] JoinBrandAndCountry { get; } =
        {
            $"{nameof(Supplier.Brand)}.{nameof(Brand.Country)}",
            $"{nameof(Supplier.Photos)}"
        };
    }
}
