using AutoDealer.Data.QueryFiltersProviders.Base;
using AutoDealer.Data.RelationsProviders.Base;
using AutoDealer.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AutoDealer.Data
{
    public static class DataServices
    {
        private static readonly LoggerFactory LoggerFactory =
            new LoggerFactory(new[] {
                new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
            });

        public static void AddDataServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options
                //.UseLoggerFactory(LoggerFactory)
                .UseNpgsql(connectionString));

            services.Scan(scan =>
            {
                scan.FromAssemblies(typeof(DataServices).Assembly)
                    .AddClasses(c => c.AssignableTo<BaseRepository>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                    .AddClasses(c => c.AssignableTo(typeof(BaseFiltersProvider<>)))
                    .AsImplementedInterfaces()
                    .AddClasses(c => c.AssignableTo<BaseRelationsProvider>())
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime();
            });
        }
    }
}
