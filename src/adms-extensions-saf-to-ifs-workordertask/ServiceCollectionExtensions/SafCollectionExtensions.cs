using Elvia.Configuration;
using MaintenanceOrdersOutBound;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafToIfsWorkOrder.Configurations;


namespace SafToIfsWorkOrderTask.ServiceCollectionExtensions;


//public interface IGenericConfiguration
//{
//    public void AddTransient(IServiceCollection services, IConfiguration configuration, bool isDevelopment);
//}
public static class SafCollectionExtensions
{
    public static IServiceCollection AddSafServices(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
    {
        //if (isDevelopment)
        //{
        //    services
        //        .AddSafMockedHttpClient()
        //        .AddTransient(typeof(MaintenanceOrders_Port_Port), (sp) => A.Fake<CustInst_Port>());
        //}
        //else
        //{
        //var endpoint = "http://localhost:5020/api/message";

        var endpoint = configuration.EnsureHasValue("SAF:Endpoint");
        var service = new MaintenanceOrders_PortClient(new MaintenanceOrders_PortClient.EndpointConfiguration(), endpoint);



        //var endpoint = configuration.EnsureHasValue("SAF:Endpoint");
        //    var service = new MaintenanceOrders_PortClient(endpoint);

        services.AddSingleton<IMaintenanceOrders_Port, MaintenanceOrders_PortClient>(s => service);

        //services
        //        .AddSafHttpClient(configuration)
        //        .AddSingleton<MaintenanceOrders_Port, CustInst_PortClient>(_ => service);
        //}

        return services;
    }
}






    //private static IServiceCollection AddSafMockedHttpClient(this IServiceCollection services)
    //{
    //    var httpMessageHandlerMock = A.Fake<HttpMessageHandler>();
    //    var httpClientMock = new HttpClient(httpMessageHandlerMock)
    //    {
    //        BaseAddress = new Uri("http://localhost")
    //    };
    //    services.AddSingleton(httpClientMock);

//    return services;
//}

//private static IServiceCollection AddSafHttpClient(this IServiceCollection services, IConfiguration configuration)
//{
//    string sesamHost = configuration.EnsureHasValue("SAF:Endpoint");

//    var httpClient = new HttpClient
//    {
//        BaseAddress = new Uri(sesamHost)
//    };
//    services.AddSingleton(httpClient); //httpclient should always be a singleton

//    return services;
//}
//}


//public class IFSWorkOrderConfiguration// : IGenericConfiguration
//    {
//        public void AddTransient(IServiceCollection services, IConfiguration configuration, bool isDevelopment)
//        {
//            //if (isDevelopment)
//            //{
//            //    services.AddTransient(typeof(IMaintenanceOrders_Port), (sp) => A.Fake<IMaintenanceOrders_Port>());
//            //}
//            //else
//            //{
//                var endpoint = "http://localhost:5021/api/message";
//                var service = new MaintenanceOrders_PortClient(new MaintenanceOrders_PortClient.EndpointConfiguration(), endpoint);
//                service.ChannelFactory.Endpoint.EndpointBehaviors.Add(new CustomEndpointBehavior());

//                services.AddSingleton<IMaintenanceOrders_Port, MaintenanceOrders_PortClient>(s => service);



//                //var endpoint = configuration.EnsureHasValue("SAF:Endpoint");
//                //var service = new MaintenanceOrders_PortClient(new MaintenanceOrders_PortClient.EndpointConfiguration(), endpoint);

//                //service.ChannelFactory.Endpoint.EndpointBehaviors.Add(endpoint);

//                //service.ChannelFactory.Endpoint.EndpointBehaviors.Add(new CustomEndpointBehavior());

//                //services.AddSingleton<IMaintenanceOrders_Port, MaintenanceOrders_PortClient>(s => service);
//            //}
//        }

//    }
//}






//namespace SafToIfsWorkOrderTask.ServiceCollectionExtensions
//{
//    public static class IFSWorkOrderCollectionExtensions
//    {
//        public static IServiceCollection AddIFSWorkOrderServices(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
//        {
//            if (isDevelopment)
//            {
//                services.AddTransient(typeof(IMaintenanceOrders_Port), (sp) => A.Fake<IMaintenanceOrders_Port>());
//            }
//            else
//            {
//                var endpoint = configuration.EnsureHasValue("SAF:Endpoint");
//                var service = new MaintenanceOrders_PortClient(new MaintenanceOrders_PortClient.EndpointConfiguration(), endpoint);
//                service.ChannelFactory.Endpoint.EndpointBehaviors.Add(new CustomEndpointBehavior());

//                services.AddSingleton<IMaintenanceOrders_Port, MaintenanceOrders_PortClient>(s => service);
//            }

//            return services;
//        }

//    }
//}
