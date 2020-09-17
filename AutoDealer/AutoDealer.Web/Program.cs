using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AutoDealer.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                /*.UseKestrel(opts =>
                {
                    opts.ListenAnyIP(5002, x => x.UseHttps());
                    opts.ListenLocalhost(5003, x => x.UseHttps());
                })*/;
        }
    }
}
