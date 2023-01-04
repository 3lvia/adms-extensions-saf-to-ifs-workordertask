//using Elvia.Telemetry;

using System.IO;
using System.Xml.Serialization;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using MaintenanceOrdersOutBound;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using ServicesIfs;
using AutoMapper;
using System;
using Elvia.KvalitetsportalLogger;
using System.Diagnostics;
using MaintenanceOrdersInBoundDomain;
using adms_extensions_saf_to_ifs_workordertask.PerformMessages;


namespace MaintenanceOrderReader.MessageHandlers
{
    public class MaintenanceOrderMessageHandler : IMessageHandler
    {
        private readonly IPerformMessageMaintenanceOrder _performMessageMaintenanceOrder;
        private readonly IKvalitetsportalClient _kvalitetsportalen;

  
        public MaintenanceOrderMessageHandler(IPerformMessageMaintenanceOrder performMessageMaintenanceOrder, IKvalitetsportalClient logger)
        {
            _performMessageMaintenanceOrder = performMessageMaintenanceOrder;
            _kvalitetsportalen = logger;
        }



        public void HandleMessage(string xmlMessage)
        {

            var stopWatch = new Stopwatch();
            Invocation invocation = null;
            
            try
            {

                stopWatch.Start();

                invocation = new Invocation
                {
                    Payload = xmlMessage,
                    StartTime = DateTime.Now,
                    GraphUri = "NA",
                    Resource = "NA"
                };

                var info = _performMessageMaintenanceOrder.Invoke(xmlMessage);

                invocation.Resource = info.Item2;

                invocation.TargetPayloads.Add(info.Item1);

                stopWatch.Stop();

                _kvalitetsportalen.LogSuccess(invocation, "MaintenanceOrders-MaintenanceOrdersIFSResp");

            }
            catch (Exception ex)
            {
                stopWatch.Stop();
                _kvalitetsportalen.LogException(invocation, ex, "MaintenanceOrders-MaintenanceOrdersIFSResp");

                throw new InvalidOperationException("zzzzz");
            }
        }
    }




    public class Utils
    {
        public static Tm DeSerialize<Tm>(StringReader sReader)
        {
            Tm status;

            using (XmlReader reader = XmlReader.Create(sReader))
            {
                var ser = new XmlSerializer(typeof(Tm));
                status = (Tm)ser.Deserialize(reader);
            }

            return status;
        }

    }


}


