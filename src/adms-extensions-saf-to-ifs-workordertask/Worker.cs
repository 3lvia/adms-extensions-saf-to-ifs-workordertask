using MaintenanceOrdersOutBound;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace adms_extensions_saf_to_ifs_workordertask
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMaintenanceOrders_Port _client;

        public Worker(ILogger<Worker> logger, IMaintenanceOrders_Port soap)
        {
            _logger = logger;
            _client = soap;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                CreateMaintenanceOrdersRequest cmor = new CreateMaintenanceOrdersRequest();

                cmor.CreateMaintenanceOrders = new MaintenanceOrdersCreateMessageType
                {
                    Payload = new MaintenanceOrdersType
                    {
                        MaintenanceOrders = new MaintenanceOrdersTypeMaintenanceOrders
                        {

                            Organisation = new Organisation[]
                             {
                                 new Organisation
                                 {
                                     mRID = "1111"
                                 }
                             }
                        }
                    }
                };

                _client.CreateMaintenanceOrders(cmor);







                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
