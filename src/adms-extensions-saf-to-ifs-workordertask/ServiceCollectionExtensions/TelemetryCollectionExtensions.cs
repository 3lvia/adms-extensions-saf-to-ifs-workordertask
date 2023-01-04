using Elvia.Configuration;
using Elvia.KvalitetsportalLogger;
using Elvia.Telemetry;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SafToIfsWorkOrderTask.ServiceCollectionExtensions;

public static class TelemetryCollectionExtensions
{
    public static IServiceCollection AddTelemetryServices(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
    {
        //if (isDevelopment)
        //{
        //    return services;
        //}
                                                      
        var instrumentationKey = configuration.EnsureHasValue("adms-extensions/kv/appinsights/adms-extensions/instrumentation_key");
        services.AddStandardElviaTelemetryLoggingWorkerService(
            instrumentationKey,
            writeToConsole: true,
            retainTelemetryWhere: telemetryItem => telemetryItem switch
            {
                DependencyTelemetry => false,
                _ => true,
            });

        return services;
    }
}