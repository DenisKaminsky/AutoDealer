using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using AutoDealer.Business;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using AutoDealer.Web.Middleware;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Functionality.Factories;
using AutoDealer.Web.Attributes;
using Microsoft.Extensions.Configuration;
using AutoDealer.Miscellaneous.Interfaces;
using AutoDealer.Miscellaneous.FileSystem;

namespace AutoDealer.Web
{
    public static class WebServices
    {
        public static void AddWebServices(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddScoped<LogFilterAttribute>();
            collection.AddScoped<IFileManager>(opt => new FileManager(
                configuration["FileSystem:RootFolder"],
                configuration["FileSystem:CarStock:Photos"],
                configuration["FileSystem:Suppliers:Photos"]));

            collection.AddSingleton<ExceptionsHandler>();
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
