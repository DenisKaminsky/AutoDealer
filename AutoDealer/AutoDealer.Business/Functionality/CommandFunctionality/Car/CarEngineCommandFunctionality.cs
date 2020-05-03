﻿using AutoDealer.Business.Functionality.CommandFunctionality.Base;
using AutoDealer.Business.Interfaces.CommandFunctionality.Car;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Car;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.Car
{
    public class CarEngineCommandFunctionality 
        : BaseGenericCreateUpdateDeleteCommandFunctionality<CarEngineCreateCommand, CarEngineUpdateCommand, CarEngine>, ICarEngineCommandFunctionality
    {
        public CarEngineCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository, 
            IValidatorFactory validatorFactory) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
        }
    }
}
