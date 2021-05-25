using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OverviewAndDependencyInjectionsSample
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // https://github.com/serilog/serilog/wiki/Configuration-Basics 

            //Codebasierte Konfiguration des Loggers
            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Debug()
            //    .WriteTo.Console()
            //    .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
            //    .CreateLogger();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.Information("Unsere Beispielanwedung starten :-) ");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) //Kestrel Default WebServer ist hier mit implementiert.
                .UseSerilog()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("samplewebsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
