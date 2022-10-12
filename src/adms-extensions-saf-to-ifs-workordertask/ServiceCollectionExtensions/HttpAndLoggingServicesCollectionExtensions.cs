//using System;
//using System.Net.Http;
//using Elvia.Configuration;
//using Elvia.Configuration.HashiVault;
//using Elvia.KvalitetsportalLogger;
//using Elvia.Telemetry;
//using FakeItEasy;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//namespace SafToIfsWorkOrderTask.ServiceCollectionExtensions

//public static class HttpAndLoggingServicesCollectionExtensions
//{
//    public static IServiceCollection AddHttpAndLoggingServices(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
//    {
//        if (isDevelopment)
//        {
//            services.AddTransient(typeof(ITelemetryInsightsLogger), sp => A.Fake<ITelemetryInsightsLogger>());
//            AddMockedHttpClient(services);
//            services.AddSingleton(k => A.Fake<IKvalitetsportalLogger>());
//        }
//        else
//        {
//            var instrumentationKey = HashiVault.EnsureHasValue("adms-extensions/kv/applicationinsights/instrumentation_key/instrumentation_key");

//            services.AddStandardElviaTelemetryLogging(instrumentationKey);
//            AddHttpClient(services, configuration);
//            AddKvalitetsportalenLogging(services, configuration);
//        }

//        return services;
//    }

//    private static void AddKvalitetsportalenLogging(IServiceCollection services, IConfiguration configuration)
//    {
//        string env = configuration.EnsureHasValue("Environment");
//        var logQueueConnectionString = HashiVault.EnsureHasValue("adms-extensions/kv/servicebus/iss-dataflowactivity/primary-connection-string");
//        var blobStoreConnectionString = HashiVault.EnsureHasValue("adms-extensions/kv/storage/issinvocationstorage/primary-connection-string");
//        var successQueueName = "successfulinvocations";
//        var exceptionsQueueName = "exceptioninvocations";
//        var flowName = ""; // this gets overridden as Implementation.IntegratoinName()-SesamModel.GetType().Name

//        services.AddSingleton<IKvalitetsportalLogger, KvalitetsportalLogger>(k => new KvalitetsportalLogger(env, flowName, logQueueConnectionString, blobStoreConnectionString, successQueueName, exceptionsQueueName, disableAsync: true));
//    }

//    private static void AddHttpClient(IServiceCollection services, IConfiguration configuration)
//    {
//        string sesamHost = configuration.EnsureHasValue("SAF:Endpoint");

//        var httpClient = new HttpClient
//        {
//            BaseAddress = new Uri(sesamHost)
//        };
//        services.AddSingleton(httpClient); //httpclient should always be a singleton
//    }

//    private static void AddMockedHttpClient(IServiceCollection services)
//    {
//        var httpMessageHandlerMock = A.Fake<HttpMessageHandler>();
//        var httpClientMock = new HttpClient(httpMessageHandlerMock);
//        httpClientMock.BaseAddress = new Uri("http://localhost");
//        services.AddSingleton(httpClientMock);
//    }
//}