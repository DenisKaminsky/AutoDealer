using System;
using System.Linq;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Web.Controllers.Base;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Get()
        {
            var rng = new Random();
            //throw new Exception("sd");
            var a = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            return ResponseWithData(StatusCodes.Status201Created, a);
        }
    }
}
