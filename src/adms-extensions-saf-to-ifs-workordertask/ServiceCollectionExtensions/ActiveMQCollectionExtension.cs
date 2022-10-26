using System;
using Apache.NMS;
using Elvia.Configuration;
using FakeItEasy;
using MaintenanceOrderReader.ActiveMQ;
using MaintenanceOrderReader.MessageHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SafToIfsWorkOrderTask.ServiceCollectionExtensions;

public static class BulkChangeCollectionExtension
{
    public static IServiceCollection AddActiveMQServices(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
    {

        string maintenanceOrderResponseQueue = configuration.EnsureHasValue("maintenanceOrderResponseQueue");
   

        IConnectionFactory factory = CreateConnectionFactory(configuration, isDevelopment);

        services.AddTransient<MaintenanceOrderMessageHandler>();

        return services.AddSingleton<IHostedService>(x =>
            ActivatorUtilities.CreateInstance<ActiveMQReader>(x, factory, maintenanceOrderResponseQueue, x.GetService<MaintenanceOrderMessageHandler>())
        );

    }

    private static IConnectionFactory CreateConnectionFactory(IConfiguration configuration, bool isDevelopment)
    {
        //if (isDevelopment)
        //{
        //    return A.Fake<IConnectionFactory>();
        //}

        string uriString = configuration.EnsureHasValue("safActiveMQUri");
        Uri activeMqUri = new(uriString);
        return new NMSConnectionFactory(activeMqUri);
    }
}