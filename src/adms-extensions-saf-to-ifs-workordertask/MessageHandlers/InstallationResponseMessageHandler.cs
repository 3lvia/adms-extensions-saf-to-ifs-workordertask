//using Elvia.Telemetry;

using System.IO;
using System.Xml.Serialization;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using MaintenanceOrders;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using ServicesIfs;
using AutoMapper;

namespace BulkChangeResponseReader.MessageHandlers
{
    public class InstallationResponseMessageHandler : IMessageHandler
    {
        //private readonly ITelemetryInsightsLogger _telemetry;

        private readonly IIfsWorkOrder _ifsWorkOrder;
        public IMapper _mapper { get; }


        //public InstallationResponseMessageHandler(ITelemetryInsightsLogger telemetry)
        //{
        //    _telemetry = telemetry;
        //}

        public InstallationResponseMessageHandler(IIfsWorkOrder ifsWorkOrder, IMapper mapper)
        {
            _mapper = mapper;
            //_telemetry = telemetry;
            _ifsWorkOrder = ifsWorkOrder;
        }

      



        public void HandleMessage(string messageXML)
        {

            StringReader sReader = new StringReader(messageXML);

            MaintenanceOrders.Envelope maintenanceOrders = Utils.DeSerialize<MaintenanceOrders.Envelope>(sReader);


            string jsonMsg = JsonConvert.SerializeObject(maintenanceOrders, Newtonsoft.Json.Formatting.Indented);


            var status = _mapper.Map<Model.IFSWorkOrderBody>(maintenanceOrders.Body.ChangedMaintenanceOrders);




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
