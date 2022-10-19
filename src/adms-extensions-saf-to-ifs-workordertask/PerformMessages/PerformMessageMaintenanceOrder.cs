using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using AutoMapper;
using ServicesIfs;
using MaintenanceOrdersOutBound;
using Elvia.KvalitetsportalLogger;
using MaintenanceOrdersDomain;
using Newtonsoft.Json;
using System.Diagnostics;

namespace adms_extensions_saf_to_ifs_workordertask.PerformMessages
{

    public class PerformMessageMaintenanceOrder : IPerformMessageMaintenanceOrder
    {


        private readonly IIfsWorkOrder _ifsWorkOrder;
        public IMapper _mapper { get; }
        public IMaintenanceOrders_Port _client { get; }


        public PerformMessageMaintenanceOrder(IIfsWorkOrder ifsWorkOrder, IMapper mapper, IMaintenanceOrders_Port client)
        {
            _ifsWorkOrder = ifsWorkOrder;
            _mapper = mapper;
            _client = client;
        }


        public (string, string, string, string) Invoke(string xmlMessage)
        {
         
            StringReader sReader = new StringReader(xmlMessage);

            MaintenanceOrdersInBound.Envelope maintenanceOrders = Utils.DeSerialize<MaintenanceOrdersInBound.Envelope>(sReader);


            string jsonMsg = JsonConvert.SerializeObject(maintenanceOrders, Newtonsoft.Json.Formatting.Indented);


            var status = _mapper.Map<MaintenanceOrdersDto>(maintenanceOrders.Body.ChangedMaintenanceOrders);


            var isAO = status.Payload.MaintenanceOrders.Work[0].IFSStatus == "INIT";

            string jsonMsgTarget = JsonConvert.SerializeObject(status, Newtonsoft.Json.Formatting.Indented);


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




            return (textMessageT , "", "", maintenanceOrders?.Body?.ChangedMaintenanceOrders?.Header?.CorrelationID);
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
