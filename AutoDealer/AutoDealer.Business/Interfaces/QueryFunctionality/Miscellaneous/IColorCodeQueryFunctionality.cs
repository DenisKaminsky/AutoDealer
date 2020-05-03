using System.Collections.Generic;
using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.QueryFunctionality.Base;
using AutoDealer.Business.Models.Responses.Miscellaneous;

namespace AutoDealer.Business.Interfaces.QueryFunctionality.Miscellaneous
{
    public interface IColorCodeQueryFunctionality : IGenericQueryFunctionality<ColorCodeModel>
    {
        Task<IEnumerable<ColorCodeModel>> GetByModelIdAsync(int id);
    }
}
