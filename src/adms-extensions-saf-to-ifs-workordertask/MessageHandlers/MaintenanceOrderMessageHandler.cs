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

namespace MaintenanceOrderReader.MessageHandlers
{
    public class MaintenanceOrderMessageHandler : IMessageHandler
    {
        //private readonly ITelemetryInsightsLogger _telemetry;

        private readonly IIfsWorkOrder _ifsWorkOrder;
        public IMapper _mapper { get; }
        public IMaintenanceOrders_Port _client { get; }


        //public InstallationResponseMessageHandler(ITelemetryInsightsLogger telemetry)
        //{
        //    _telemetry = telemetry;
        //}

        public MaintenanceOrderMessageHandler(IIfsWorkOrder ifsWorkOrder, IMapper mapper, IMaintenanceOrders_Port soap)
        {
            _mapper = mapper;
            _client = soap;
            //_telemetry = telemetry;
            _ifsWorkOrder = ifsWorkOrder;
        }

      



        public void HandleMessage(string messageXML)
        {

            StringReader sReader = new StringReader(messageXML);

            MaintenanceOrdersInBound.Envelope maintenanceOrders = Utils.DeSerialize<MaintenanceOrdersInBound.Envelope>(sReader);


            string jsonMsg = JsonConvert.SerializeObject(maintenanceOrders, Newtonsoft.Json.Formatting.Indented);


            var status = _mapper.Map<Model.IFSWorkOrderBody>(maintenanceOrders.Body.ChangedMaintenanceOrders);

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

            //_client.CreateMaintenanceOrders(cmor);


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
