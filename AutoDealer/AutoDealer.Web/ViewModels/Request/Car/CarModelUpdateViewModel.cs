﻿using AutoDealer.Web.ViewModels.Base;

namespace AutoDealer.Web.ViewModels.Request.Car
{
    public class CarModelUpdateViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int Price { get; set; }
    }
}
