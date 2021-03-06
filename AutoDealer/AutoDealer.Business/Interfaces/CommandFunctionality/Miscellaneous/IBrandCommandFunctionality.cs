﻿using AutoDealer.Business.Interfaces.CommandFunctionality.Base;
using AutoDealer.Business.Models.Commands.Miscellaneous;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.Miscellaneous
{
    public interface IBrandCommandFunctionality 
        : IBaseGenericCreateUpdateDeleteCommandFunctionality<BrandCreateCommand, BrandUpdateCommand>
    {
    }
}
