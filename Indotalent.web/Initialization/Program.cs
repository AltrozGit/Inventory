using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using Serilog;
using System;
using System.IO;

namespace Indotalent
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Serilog.Log.Logger = new LoggerConfiguration()
           .WriteTo.File("C:/Logs/InventoryLogs/log-.txt", rollingInterval: RollingInterval.Day)  // Creates daily log files
           .CreateLogger();

            try
            {
                Serilog.Log.Information("Application Starting Up");
                CreateHostBuilder(args).Build().Run();
            }

          
            catch (Exception ex)
            {
                Serilog.Log.Fatal(ex, "Application start-up failed.");
            }
            finally
            {
                Serilog.Log.CloseAndFlush();
            }
        }
        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStaticWebAssets();
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    config.AddJsonFile("appsettings.bundles.json");
                    config.AddJsonFile($"appsettings.machine.json", optional: true);
                });
        }
    }
}
