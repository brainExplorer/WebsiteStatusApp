using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteStatus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microspft",LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(@"D:\CSharp Projects\WebsiteStatusApp\WebsiteStatus\Logfile.txt")
                .CreateLogger();

            try
            {
                Log.Information("Startingup the service.");
                CreateHostBuilder(args).Build().Run();
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex,"There was a problem while starting a program.");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            

        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseWindowsService()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();
            })
            .UseSerilog();

    }
}
