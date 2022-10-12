using Elvia.Configuration;
using FakeItEasy;
using MaintenanceOrdersOutBound;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafToIfsWorkOrder.Configurations;


namespace SesamToSafAPI.Configurations
{

    public interface IGenericConfiguration
    {
        public void AddTransient(IServiceCollection services, IConfiguration configuration, bool isDevelopment);
    }



    public class IFSWorkOrderConfiguration : IGenericConfiguration
    {
        public void AddTransient(IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            //if (isDevelopment)
            //{
            //    services.AddTransient(typeof(IMaintenanceOrders_Port), (sp) => A.Fake<IMaintenanceOrders_Port>());
            //}
            //else
            //{
                var endpoint = "http://localhost:5021/api/message";
                var service = new MaintenanceOrders_PortClient(new MaintenanceOrders_PortClient.EndpointConfiguration(), endpoint);
                service.ChannelFactory.Endpoint.EndpointBehaviors.Add(new CustomEndpointBehavior());

                services.AddSingleton<IMaintenanceOrders_Port, MaintenanceOrders_PortClient>(s => service);



                //var endpoint = configuration.EnsureHasValue("SAF:Endpoint");
                //var service = new MaintenanceOrders_PortClient(new MaintenanceOrders_PortClient.EndpointConfiguration(), endpoint);

                //service.ChannelFactory.Endpoint.EndpointBehaviors.Add(endpoint);

                //service.ChannelFactory.Endpoint.EndpointBehaviors.Add(new CustomEndpointBehavior());

                //services.AddSingleton<IMaintenanceOrders_Port, MaintenanceOrders_PortClient>(s => service);
            //}
        }

    }
}






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
