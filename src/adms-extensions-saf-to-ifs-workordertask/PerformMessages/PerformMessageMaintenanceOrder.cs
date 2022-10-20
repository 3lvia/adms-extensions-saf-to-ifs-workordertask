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
using Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using IValueProvider = Newtonsoft.Json.Serialization.IValueProvider;

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
            MaintenanceOrdersInBound.Envelope maintenanceOrders;
            MaintenanceOrdersDto maintenanceOrdersDto;
            WorkOrderIfsDto workOrderIfsDto;

            MapInBoundMessage(xmlMessage, out maintenanceOrdersDto, out workOrderIfsDto);


            /////////////////////////////////////////
            /// TEMP - i påvente av beskrivelser.
            
            workOrderIfsDto.Sender = "ELSMART";
            workOrderIfsDto.Context = "STANDARD";
            workOrderIfsDto.MchCode = "NS.0890";
            workOrderIfsDto.ErrDescr = ".";
            workOrderIfsDto.WorkDescrLo = "Test";
            workOrderIfsDto.OrgCode = "01B2B001";

            ////////////////////////////////////////


            var textMessageS = JsonConvert.SerializeObject(workOrderIfsDto, Newtonsoft.Json.Formatting.Indented);

            //string textMessageS = JsonSerializer.Serialize(workOrderIfsDto);

            //string textMessageS = new StreamReader(@"BodyData.json").ReadToEnd();

            var resultAONumber = _ifsWorkOrder.Publish(textMessageS, false);

            int tst = 2;

            //var tst = _mapper.Map<Model.WorkOrderIfsDto>(maintenanceOrders.Body.ChangedMaintenanceOrders);

            //var isAO = status.Payload.MaintenanceOrders.Work[0].IFSStatus == "INIT";


            //string jsonMsgTarget = JsonConvert.SerializeObject(status, Newtonsoft.Json.Formatting.Indented);


            //string textMessage = new StreamReader(@"BodyData.json").ReadToEnd();

            //string testMessageTask = new StreamReader(@"BodyDataTask.json").ReadToEnd();

            ////var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            //var bodyObject = JsonConvert.DeserializeObject<Model.WorkOrderIfsDto>(textMessage);

            //var bodyObjectTask = JsonConvert.DeserializeObject<Model.WorkTaskIfsDto>(testMessageTask);


            //var textMessageS = JsonConvert.SerializeObject(bodyObject);


        





            //bodyObjectTask.WoNo = result;

            //var textMessageT = JsonConvert.SerializeObject(bodyObjectTask);

            //var result2 = _ifsWorkOrder.Publish(textMessageT, true);


            //return (textMessageT, "", "", maintenanceOrdersDto?.Body?.ChangedMaintenanceOrders?.Header?.CorrelationID);

            return ("", "", "", "");
        }


        private void MapInBoundMessage(string xmlMessage, out MaintenanceOrdersDto maintenanceOrdersDto, out Model.WorkOrderIfsDto workOrderDto)
        {
            StringReader sReader = new StringReader(xmlMessage);

            var maintenanceOrders = Utils.DeSerialize<MaintenanceOrdersInBound.Envelope>(sReader);
            //string jsonMsg = JsonConvert.SerializeObject(maintenanceOrders, Newtonsoft.Json.Formatting.Indented);


            maintenanceOrdersDto = _mapper.Map<MaintenanceOrdersDto>(maintenanceOrders.Body.ChangedMaintenanceOrders);

            workOrderDto = _mapper.Map<Model.WorkOrderIfsDto>(maintenanceOrders.Body.ChangedMaintenanceOrders);
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
