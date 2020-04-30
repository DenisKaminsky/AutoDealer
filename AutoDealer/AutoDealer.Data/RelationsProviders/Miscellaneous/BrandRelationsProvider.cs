using AutoDealer.Data.Interfaces.RelationsProviders.Miscellaneous;
using AutoDealer.Data.Models.Miscellaneous;
using AutoDealer.Data.RelationsProviders.Base;

namespace AutoDealer.Data.RelationsProviders.Miscellaneous
{
    public class BrandRelationsProvider : BaseRelationsProvider, IBrandRelationsProvider
    {
        public string[] JoinCountry { get; } = {nameof(Brand.Country)};
    }
}
