﻿using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.Car
{
    public class CarStockUpdateCommand : BaseModel, IUpdateCommand
    {
        public int ModelId { get; set; }
        public int BodyTypeId { get; set; }
        public int ColorId { get; set; }
        public int EngineGearboxId { get; set; }
        public int ComplectationId { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }

        public CarStockUpdateCommand(int id) : base(id)
        {
        }
    }
}
