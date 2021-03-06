﻿using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.Base;
using AutoDealer.Business.Models.Commands.Car;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.Car
{
    public interface ICarComplectationCommandFunctionality : IBaseGenericCreateDeleteCommandFunctionality<CarComplectationCreateCommand>
    {
        Task AddOptionsAsync(CarComplectationOptionsAssignCommand assignCommand);

        Task RemoveOptionAsync(int id);
    }
}
