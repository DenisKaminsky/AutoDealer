﻿using AutoDealer.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AutoDealer.Data
{
    public static class DataServices
    {
        public static void AddDataServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

            services.Scan(scan =>
            {
                scan.FromAssemblies(typeof(DataServices).Assembly)
                    .AddClasses(c => c.AssignableTo<BaseGenericRepository>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });
        }
    }
}
