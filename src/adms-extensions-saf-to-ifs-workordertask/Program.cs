using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Apache.NMS;
using MaintenanceOrderReader.ActiveMQ;
using MaintenanceOrderReader.MessageHandlers;
using ServicesIfs;
using System;
using MaintenanceOrdersOutBound;
using SafToIfsWorkOrder.Configurations;
using SafToIfsWorkOrderTask.ServiceCollectionExtensions;

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
                .ConfigureServices((hostContext, services) =>
                {

                    IHostEnvironment env = hostContext.HostingEnvironment;

                    var isDevelopment = env.IsDevelopment();

          

                    services
                        .AddMemoryCache()
                        .AddKvalitetsportalenServices(isDevelopment)
                        .AddAuthServices()
                        .AddAutoMapper(typeof(Program));


                    //services.AddHostedService<Worker>();
                    //services.AddSingleton<IClientCredentialsConfiguration, ClientCredentialsConfiguration>();

                    //services.AddSingleton<IAccessTokenService, AccessTokenService>();

                    services.AddSingleton<IIfsWorkOrder, IfsWorkOrder>();


                    var endpoint = "http://localhost:5020/api/message";
                    var service = new MaintenanceOrders_PortClient(new MaintenanceOrders_PortClient.EndpointConfiguration(), endpoint);
                    service.ChannelFactory.Endpoint.EndpointBehaviors.Add(new CustomEndpointBehavior());

                    services.AddSingleton<IMaintenanceOrders_Port, MaintenanceOrders_PortClient>(s => service);



                    //services.AddTransient<IClientCredentialsConfiguration, ClientCredentialsConfiguration>();

                    //services.AddTransient<IAccessTokenService, AccessTokenService>();


                    //services.AddHostedService<Worker>();

                    string maintenanceOrder = "queue://MaintenanceOrder"; // configuration.EnsureHasValue("bulkChangeCustomersResponseQueue");


                    //Uri activeMqUri = new("amqp://CXPC-R90W8BW3:61616");

                    Uri activeMqUri = new("amqp://CXPC-12V5L12:61616");


                    IConnectionFactory factory = new NMSConnectionFactory(activeMqUri);

                    services.AddTransient<MaintenanceOrderMessageHandler>();

                    services.AddSingleton<IHostedService>(x =>
                        ActivatorUtilities.CreateInstance<ActiveMQReader>(x, factory, maintenanceOrder, x.GetService<MaintenanceOrderMessageHandler>())
                    );





                });

    }

}







//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace adms_extensions_saf_to_ifs_workordertask
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            CreateHostBuilder(args).Build().Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureServices((hostContext, services) =>
//                {
//                    services.AddHostedService<Worker>();
//                });
//    }
//}
