using AutoDealer.Business.Functionality.Base;
using AutoDealer.Business.Functionality.Factories;
using AutoDealer.Business.Functionality.UnitOfWork;
using AutoDealer.Business.Interfaces.UnitOfWork;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AutoDealer.Business
{
    public static class BusinessServices
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IValidatorFactory, FluentValidatorsFactory>();
           
            services.Scan(scan =>
            {
                scan.FromAssemblies(typeof(BusinessServices).Assembly)
                    .AddClasses(c => c.AssignableTo<BaseFunctionality>())
                    .AsImplementedInterfaces()
                    .AddClasses(c => c.AssignableTo(typeof(IValidator<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });
        }
    }
}
