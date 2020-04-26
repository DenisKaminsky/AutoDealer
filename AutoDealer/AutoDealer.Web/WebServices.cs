using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using AutoDealer.Business;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Functionality.Factories;

namespace AutoDealer.Web
{
    public static class WebServices
    {
        public static void AddWebServices(this IServiceCollection collection)
        {
            collection.AddSingleton<IMapperFactory>(opt => new MapperFactory(
                new KeyValuePair<string, IMapper>(nameof(BusinessServices), Business.Extensions.MapperExtensions.GetMapper()),
                new KeyValuePair<string, IMapper>(nameof(WebServices), Extensions.MapperExtensions.GetMapper())));

            collection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo { Title = "AutoDealer API", Version = "V1" });
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.XML"));
            });
        }
    }
}
