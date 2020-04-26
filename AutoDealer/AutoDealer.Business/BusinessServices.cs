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
        }
    }
}
