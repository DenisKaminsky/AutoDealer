using System;
using AutoDealer.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AutoDealer.Web.Extensions
{
    public static class DataExtensions
    {
        public static void InitializeMigrations(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceProvider>().CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
            dbContext.Database.Migrate();
        }
    }
}
