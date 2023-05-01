using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Nop.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Nop.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
   
     /*      var builder = Host.CreateDefaultBuilder(args);

            builder.ConfigureServices(
                services =>
                    services.AddDbContext<testContext>(options =>
                options.UseSqlServer("Server=HP\\KARIM;Database=test;Trusted_Connection=True;MultipleActiveResultSets=true")));*/

            CreateHostBuilder(args).Build().Run();
            /*
                        var host = new WebHostBuilder()
                        .ConfigureLogging(options => options.AddConsole())
                        .ConfigureLogging(options => options.AddDebug())
                        .ConfigureServices(services => services.AddAutofac())
                        .ConfigureAppConfiguration(cb =>
                        {
                            cb.AddJsonFile("appsettings.json", optional: true).AddEnvironmentVariables();
                        })
                        .ConfigureServices(
                            services =>
                                services.AddDbContext<testContext>(options =>
                            options.UseSqlServer("Server=HP\\KARIM;Database=test;Trusted_Connection=True;MultipleActiveResultSets=true")))
                        .UseStartup<Startup>()
                            .Build();

                        host.Run();*/

            /*    var builder = WebHostBuilder.CreateBuilder(args);*/
            /*var builder = WebApplica*/
            /*  .Build().Run()*/

            // Add services to the container.
            /*            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");*/
            /* IServiceCollection serviceCollection.AddDbContext<testContext>(options =>
               {
                 options.UseSqlServer(connectionString);


            });*/


        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            


            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>();
                });

         
        }
    }
}
