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
using adms_extensions_saf_to_ifs_workordertask.PerformMessages;

namespace MaintenanceOrderReader.MessageHandlers
{
    public class MaintenanceOrderMessageHandler : IMessageHandler
    {
        private readonly IPerformMessageMaintenanceOrder _performMessageMaintenanceOrder;

        //private readonly ITelemetryInsightsLogger _telemetry;

        //private readonly IIfsWorkOrder _ifsWorkOrder;
        //public IMapper _mapper { get; }
        //public IMaintenanceOrders_Port _client { get; }

        private readonly IKvalitetsportalClient _kvalitetsportalen;

        //public InstallationResponseMessageHandler(ITelemetryInsightsLogger telemetry)
        //{
        //    _telemetry = telemetry;
        //}

        //public MaintenanceOrderMessageHandler(IPerformMessageMaintenanceOrder performMessageMaintenanceOrder, IIfsWorkOrder ifsWorkOrder, IMapper mapper, IMaintenanceOrders_Port soap, IKvalitetsportalClient logger)
        //{
        //    _mapper = mapper;
        //    _client = soap;
        //    _performMessageMaintenanceOrder = performMessageMaintenanceOrder;
        //    //_telemetry = telemetry;
        //    _ifsWorkOrder = ifsWorkOrder;
        //    _kvalitetsportalen = logger;
        //}

        public MaintenanceOrderMessageHandler(IPerformMessageMaintenanceOrder performMessageMaintenanceOrder, IKvalitetsportalClient logger)
        {
            //_mapper = mapper;
            //_client = soap;
            _performMessageMaintenanceOrder = performMessageMaintenanceOrder;
            //_telemetry = telemetry;
            //_ifsWorkOrder = ifsWorkOrder;
            _kvalitetsportalen = logger;
        }

        //try
        //{
        //    _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        //}
        //catch (Exception ex)
        //{
        //    int d = 1;

        //}



        public void HandleMessage(string messageXML)
        {
     
            try
            {

                var stopWatch = new Stopwatch();
                stopWatch.Start();


                var info = _performMessageMaintenanceOrder.Invoke(messageXML);


                var invocation = new Invocation
                {
                    Payload = messageXML,
                    StartTime = DateTime.Now,
                    GraphUri = "NA",
                    Resource = info.Item4
                };                

                invocation.TargetPayloads.Add(info.Item1);


                stopWatch.Stop();

                _kvalitetsportalen.LogSuccess(invocation, "MaintenanceOrders-MaintenanceOrdersIFSResp");


            }
            catch (Exception ex) 
            { 
            
                
            
            
            }

           

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






//var stopWatch = new Stopwatch();
//stopWatch.Start();

//StringReader sReader = new StringReader(messageXML);

//MaintenanceOrdersInBound.Envelope maintenanceOrders = Utils.DeSerialize<MaintenanceOrdersInBound.Envelope>(sReader);


//string jsonMsg = JsonConvert.SerializeObject(maintenanceOrders, Newtonsoft.Json.Formatting.Indented);




//var invocation = new Invocation
//{
//    Payload = messageXML,
//    StartTime = DateTime.Now,
//    GraphUri = "NA",
//    Resource = maintenanceOrders?.Body?.ChangedMaintenanceOrders?.Header?.CorrelationID
//};

//var status = _mapper.Map<MaintenanceOrdersDto>(maintenanceOrders.Body.ChangedMaintenanceOrders);


//var isAO = status.Payload.MaintenanceOrders.Work[0].IFSStatus == "INIT";

//string jsonMsgTarget = JsonConvert.SerializeObject(status, Newtonsoft.Json.Formatting.Indented);


//string textMessage = new StreamReader(@"BodyData.json").ReadToEnd();

//string testMessageTask = new StreamReader(@"BodyDataTask.json").ReadToEnd();

////var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
//var bodyObject = JsonConvert.DeserializeObject<Model.IFSWorkOrderBody>(textMessage);

//var bodyObjectTask = JsonConvert.DeserializeObject<Model.IFSWorkTaskBody>(testMessageTask);


//var textMessageS = JsonConvert.SerializeObject(bodyObject);


//var result = _ifsWorkOrder.Publish(textMessageS, false);


//bodyObjectTask.WoNo = result;

//var textMessageT = JsonConvert.SerializeObject(bodyObjectTask);

//var result2 = _ifsWorkOrder.Publish(textMessageT, true);






//invocation.TargetPayloads.Add(jsonMsgTarget);



//try
//{





//}
//catch (Exception ex)
//{
//    int qw = 2;
//}





//var status2 = _mapper.Map<Model.IFSWorkOrderBody>(maintenanceOrders.Body.ChangedMaintenanceOrders);


//int s = 1;


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


