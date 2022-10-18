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
using MaintenanceOrdersDomain;

namespace MaintenanceOrderReader.MessageHandlers
{
    public class MaintenanceOrderMessageHandler : IMessageHandler
    {
        //private readonly ITelemetryInsightsLogger _telemetry;

        private readonly IIfsWorkOrder _ifsWorkOrder;
        public IMapper _mapper { get; }
        public IMaintenanceOrders_Port _client { get; }

        private readonly IKvalitetsportalClient _kvalitetsportalen;

        //public InstallationResponseMessageHandler(ITelemetryInsightsLogger telemetry)
        //{
        //    _telemetry = telemetry;
        //}

        public MaintenanceOrderMessageHandler(IIfsWorkOrder ifsWorkOrder, IMapper mapper, IMaintenanceOrders_Port soap, IKvalitetsportalClient logger)
        {
            _mapper = mapper;
            _client = soap;
            //_telemetry = telemetry;
            _ifsWorkOrder = ifsWorkOrder;
            _kvalitetsportalen = logger;
        }

      



        public void HandleMessage(string messageXML)
        {

            //try
            //{
            //    _mapper.ConfigurationProvider.AssertConfigurationIsValid();
            //}
            //catch (Exception ex)
            //{
            //    int d = 1;

            //}


            var stopWatch = new Stopwatch();
            stopWatch.Start();

            StringReader sReader = new StringReader(messageXML);

            MaintenanceOrdersInBound.Envelope maintenanceOrders = Utils.DeSerialize<MaintenanceOrdersInBound.Envelope>(sReader);


            //string jsonMsg = JsonConvert.SerializeObject(maintenanceOrders, Newtonsoft.Json.Formatting.Indented);


    

            var invocation = new Invocation
            {
                Payload = messageXML,
                StartTime = DateTime.Now,
                GraphUri = "NA",
                Resource = maintenanceOrders?.Body?.ChangedMaintenanceOrders?.Header?.CorrelationID
            };


            //try
            //{
                //var status = _mapper.Map<MaintenanceOrdersEventMessageTypeDto>(maintenanceOrders.Body.ChangedMaintenanceOrders.Payload);

                var status = _mapper.Map<MaintenanceOrdersDto>(maintenanceOrders.Body.ChangedMaintenanceOrders);


            //}
            //catch (Exception ex)
            //{
            //    int qw = 2;
            //}


            string jsonMsg = JsonConvert.SerializeObject(status, Newtonsoft.Json.Formatting.Indented);


            invocation.TargetPayloads.Add(jsonMsg);

            stopWatch.Stop();

            _kvalitetsportalen.LogSuccess(invocation, "MaintenanceOrders-MaintenanceOrdersIFSResp");



            var status2 = _mapper.Map<Model.IFSWorkOrderBody>(maintenanceOrders.Body.ChangedMaintenanceOrders);


            int s = 1;


            //CreateMaintenanceOrdersRequest cmor = new CreateMaintenanceOrdersRequest();

            //cmor.CreateMaintenanceOrders = new MaintenanceOrdersCreateMessageType
            //{
            //    Payload = new MaintenanceOrdersType
            //    {
            //        MaintenanceOrders = new MaintenanceOrdersTypeMaintenanceOrders
            //        {

            //            Organisation = new Organisation[]
            //             {
            //                 new Organisation
            //                 {
            //                     mRID = "1111"
            //                 }
            //             }


            //        }
            //    }
            //};

            ////_client.CreateMaintenanceOrders(cmor);


            string textMessage = new StreamReader(@"BodyData.json").ReadToEnd();

            string testMessageTask = new StreamReader(@"BodyDataTask.json").ReadToEnd();

            //var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var bodyObject = JsonConvert.DeserializeObject<Model.IFSWorkOrderBody>(textMessage);

            var bodyObjectTask = JsonConvert.DeserializeObject<Model.IFSWorkTaskBody>(testMessageTask);


            var textMessageS = JsonConvert.SerializeObject(bodyObject);


            var result = _ifsWorkOrder.Publish(textMessageS, false);


            bodyObjectTask.WoNo = result;

            var textMessageT = JsonConvert.SerializeObject(bodyObjectTask);

            var result2 = _ifsWorkOrder.Publish(textMessageT, true);


            int debug = 1;
            //_telemetry.TrackTrace(messageText);
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
