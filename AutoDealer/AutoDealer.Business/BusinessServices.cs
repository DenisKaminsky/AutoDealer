using AutoDealer.Business.Functionality;
using AutoDealer.Business.Functionality.UnitOfWork;
using AutoDealer.Business.Interfaces.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace AutoDealer.Business
{
    public static class BusinessServices
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Scan(scan =>
            {
                scan.FromAssemblies(typeof(BusinessServices).Assembly)
                    .AddClasses(c => c.AssignableTo<BaseFunctionality>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });
        }
    }
}
