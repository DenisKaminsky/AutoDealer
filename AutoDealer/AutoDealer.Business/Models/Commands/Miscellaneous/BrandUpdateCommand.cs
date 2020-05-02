using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.Miscellaneous
{
    public class BrandUpdateCommand : BaseModel, IUpdateCommand
    {
        public string Name { get; }

        public int CountryId { get; }

        public int? SupplierId { get; }

        public BrandUpdateCommand(int id, string name, int countryId, int? supplierId) : base(id)
        {
            Name = name;
            CountryId = countryId;
            SupplierId = supplierId;
        }
    }
}
