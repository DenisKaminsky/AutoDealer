﻿using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.QueryFunctionality.Base;
using AutoDealer.Business.Models.Responses.File;
using AutoDealer.Business.Models.Responses.Miscellaneous;

namespace AutoDealer.Business.Interfaces.QueryFunctionality.Miscellaneous
{
    public interface ISupplierQueryFunctionality : IGenericQueryFunctionality<SupplierModel>
    {
        Task<SupplierModel> GetByBrandIdAsync(int id);
        Task<FileModel> GetPhotoByIdAsync(int id);
    }
}
