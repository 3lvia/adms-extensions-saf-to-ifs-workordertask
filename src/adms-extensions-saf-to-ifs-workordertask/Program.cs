using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SafToIfsWorkOrderTask.ServiceCollectionExtensions;
using Microsoft.Extensions.Configuration;
using Elvia.Configuration;
using System;
using System.Threading;
using IfsResponseServices.Vault;
using Elvia.Telemetry;

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

                    IHashiVaultWrapper hashiVaultWrapper = new HashiVaultWrapper();

                    var isDevelopment = env.IsDevelopment();
                    var configuration = hostContext.Configuration;

                    var instrumentationKeyPath = configuration["Vault:AppInsights:InstrumentationKey"];
                    var instrumentationKey = hashiVaultWrapper.EnsureHasValue(instrumentationKeyPath);

                    services
                        .AddMemoryCache()
                        .AddActiveMQServices(configuration, isDevelopment)
                        .AddSafServices(configuration, isDevelopment)
                        .AddTelemetryServices(configuration, isDevelopment)
                        .AddStandardElviaTelemetryLogging(instrumentationKey, true)
                        //.AddKvalitetsportalenServices(isDevelopment)
                        .AddKvalitetsportalenServices(configuration, isDevelopment, hashiVaultWrapper)
                        .AddAuthServices()
                        .AddAutoMapper(typeof(Program))
                        .AddPerformMessageServices()
                        .AddIfsCloudMessageServices();

                });

    }

}

