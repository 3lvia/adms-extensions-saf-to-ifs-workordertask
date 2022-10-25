using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SafToIfsWorkOrderTask.ServiceCollectionExtensions;
using Microsoft.Extensions.Configuration;
using Elvia.Configuration;

namespace adms_extensions_saf_to_ifs_workordertask
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration((context, config) =>
                 {
                     config.AddJsonFile($"appsettings.json", true);
                     config.AddEnvironmentVariables();
                     config.AddHashiVaultSecrets();
                 })
                .ConfigureServices((hostContext, services) =>
                {

                    IHostEnvironment env = hostContext.HostingEnvironment;

                    var isDevelopment = env.IsDevelopment();
                    var configuration = hostContext.Configuration;

                    services
                        .AddMemoryCache()
                        .AddActiveMQServices(configuration, isDevelopment)
                        .AddSafServices(configuration, isDevelopment)
                        .AddTelemetryServices(configuration, isDevelopment)
                        .AddKvalitetsportalenServices(isDevelopment)
                        .AddAuthServices()
                        .AddAutoMapper(typeof(Program))
                        .AddPerformMessageServices()
                        .AddIfsCloudMessageServices();       
                    
                });

    }

}

