using System;
using System.Collections.Generic;
using System.Linq;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace AutoDealer.Web.Controllers
{
    public class WeatherForecastController : BaseWebApiController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController(IMapperFactory mapperFactory) : base(mapperFactory) { }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
