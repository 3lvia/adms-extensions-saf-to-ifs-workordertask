//using Elvia.Configuration;
//using FakeItEasy;
//using MaintenanceOrdersIn;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;


//namespace SafToIfsWorkOrderTask.ServiceCollectionExtensions
//{
//    public static class WorkOrderCollectionExtensions
//    {
//        public static IServiceCollection AddWorkOrderServices(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
//        {
//            if (isDevelopment)
//            {
//                services.AddTransient(typeof(MaintenanceOrders_Port), (sp) => A.Fake<MaintenanceOrders_Port>());
//            }
//            else
//            {
//                var endpoint = configuration.EnsureHasValue("SAF:Endpoint");
//                var service = new MaintenanceOrders_PortClient(new MaintenanceOrders_PortClient.EndpointConfiguration(), endpoint);
//                service.ChannelFactory.Endpoint.EndpointBehaviors.Add(new CustomEndpointBehavior());

//                services.AddSingleton<MaintenanceOrders_Port, MaintenanceOrders_PortClient>(s => service);
//            }

//            return services;
//        }

//    }
//}

//    // public static class TroubleTicketsCollectionExtensions
//    // {
//    //
//    //     public static IServiceCollection AddTroubleTicketsServices(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
//    //     {
//    //         if (isDevelopment)
//    //         {
//    //             services.AddTransient(typeof(TroubleTickets_Port), (sp) => A.Fake<TroubleTickets_Port>());
//    //         }
//    //         else
//    //         {
//    //             var endpoint = configuration.EnsureHasValue("SAF:Endpoint");
//    //             var service = new TroubleTickets_PortClient(new TroubleTickets_PortClient.EndpointConfiguration(), endpoint);
//    //             service.ChannelFactory.Endpoint.EndpointBehaviors.Add(new CustomEndpointBehavior());
//    //
//    //             services.AddSingleton<TroubleTickets_Port, TroubleTickets_PortClient>(s => service);
//    //         }
//    //
//    //         return services;
//    //     }
//    //
//    // }
