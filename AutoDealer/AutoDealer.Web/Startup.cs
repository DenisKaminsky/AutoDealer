using System.IO;
using AutoDealer.Business;
using AutoDealer.Data;
using AutoDealer.Web.Extensions;
using AutoDealer.Web.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AutoDealer.Web
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddCookieAuthentication();
            services.AddControllers();
            services.AddWebServices(Configuration);
            services.AddBusinessServices();
            services.AddDataServices(Configuration.GetConnectionString("PostgreSQLConnection"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Path.Combine(Configuration["Logging:LogsFolderName"], "AutoDealer.Web.log"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionsHandler>();
            app.UseSwaggerMiddleware();
            app.UseHttpsRedirection();
            app.UseCors(builder => builder
                .WithOrigins(Configuration.GetSection("AllowedHosts").Get<string[]>())
                .AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod());
            app.UseCookiePolicy();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            app.InitializeMigrations();
        }
    }
}
