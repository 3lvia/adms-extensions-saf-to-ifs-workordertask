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
using MaintenanceOrdersInBoundDomain;
using Newtonsoft.Json;
using System.Diagnostics;
using Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using Apache.NMS;
using MaintenanceOrdersInBound;

namespace adms_extensions_saf_to_ifs_workordertask.PerformMessages
{

    public class PerformMessageMaintenanceOrder : IPerformMessageMaintenanceOrder
    {

        private readonly IIfsCloudService _ifsCloudService;
        public IMapper _mapper { get; }
        public MaintenanceOrdersOutBound.IMaintenanceOrders_Port _client { get; }


        public PerformMessageMaintenanceOrder(IIfsCloudService ifsCloudService, IMapper mapper, MaintenanceOrdersOutBound.IMaintenanceOrders_Port client)
        {
            _ifsCloudService = ifsCloudService;
            _mapper = mapper;
            _client = client;
        }

      
        public (string, string, string, string) Invoke(string xmlMessage)
        {
            MaintenanceOrdersInBound.Envelope maintenanceOrders;
            MaintenanceOrdersDto maintenanceOrdersDto;
            WorkOrderIfsDto workOrderIfsDto;
            WorkOrderTaskIfsDto workOrderTaskIfsDto;

            MapInBoundMessage(xmlMessage, out maintenanceOrdersDto, out workOrderIfsDto, out workOrderTaskIfsDto);


            /////////////////////////////////////////
            /// TEMP - i påvente av beskrivelser.
            
            workOrderIfsDto.Sender = "ELSMART";
            workOrderIfsDto.Context = "STANDARD";
            workOrderIfsDto.MchCode = "NS.0890";
            workOrderIfsDto.ErrDescr = ".";
            workOrderIfsDto.WorkDescrLo = "Test";
            workOrderIfsDto.OrgCode = "01B2B001";

            workOrderTaskIfsDto.Sender = "ELSMART";
            workOrderTaskIfsDto.Context = "STANDARD";
            workOrderTaskIfsDto.WoNo = "263";
            workOrderTaskIfsDto.ExtRefKeyTask = "HUB.4321";
            workOrderTaskIfsDto.MchCode = "NS.0152";
            workOrderTaskIfsDto.Description = "Just another task \u2013 never-ending story";
            workOrderTaskIfsDto.LongDescription = "LongDescr";
            workOrderTaskIfsDto.ReportedBy = "ELVIA_ENTR";
            workOrderTaskIfsDto.OrgCode = "01B2B001";

            ////////////////////////////////////////

            string requestMessageWorkOrder = "";
            string resultWorkOrderNumber = "";
            string requestMessageWorkOrderTask = "";
            string resultWorkOrderTaskNumber = "";

            try
            {
                requestMessageWorkOrder = JsonConvert.SerializeObject(workOrderIfsDto, Newtonsoft.Json.Formatting.Indented);

                resultWorkOrderNumber = _ifsCloudService.CreateWorkOrder(requestMessageWorkOrder);

                workOrderTaskIfsDto.WoNo = resultWorkOrderNumber; //AO

                requestMessageWorkOrderTask = JsonConvert.SerializeObject(workOrderTaskIfsDto, Newtonsoft.Json.Formatting.Indented);
          
                resultWorkOrderTaskNumber = _ifsCloudService.CreateWorkOrderTask(requestMessageWorkOrderTask);
            }
            catch(Exception ex)
            {
                throw new Exception("ERROR: " + ex.Message + "___#####__" + requestMessageWorkOrder + "___#####__" + requestMessageWorkOrderTask + "___#####__"); 

            }
     

            string targetMessages  = "\r\n\r\nWorkOrderRequest: \r\n" + requestMessageWorkOrder + "\r\nResult:" + resultWorkOrderNumber;
                   targetMessages += "\r\n\r\nWorkOrderTaskRequest: \r\n" + requestMessageWorkOrderTask + "\r\nResult:" + resultWorkOrderTaskNumber;


            string id = maintenanceOrdersDto.MessageId;
           
            return (targetMessages, "", "", id);
        }





        private void MapInBoundMessage(string xmlMessage, out MaintenanceOrdersDto maintenanceOrdersDto, out Model.WorkOrderIfsDto workOrderDto, out Model.WorkOrderTaskIfsDto workOrderTaskDto)
        {
            StringReader sReader = new StringReader(xmlMessage);

            var maintenanceOrders = Utils.DeSerialize<MaintenanceOrdersInBound.Envelope>(sReader);

            maintenanceOrdersDto = _mapper.Map<MaintenanceOrdersDto>(maintenanceOrders.Body.ChangedMaintenanceOrders);

            workOrderDto = _mapper.Map<Model.WorkOrderIfsDto>(maintenanceOrders.Body.ChangedMaintenanceOrders);

            workOrderTaskDto = _mapper.Map<Model.WorkOrderTaskIfsDto>(maintenanceOrders.Body.ChangedMaintenanceOrders);
        }




        private void SetOutBoundValues()
        {
            var rootObject = new MaintenanceOrdersOutBoundDomain.IFSMaintenanceOrdersMessageTypeDto
            {
                Header = new MaintenanceOrdersOutBoundDomain.HeaderTypeDto
                {
                    Verb = "text_1",
                    Noun = "text_2",
                    Revision = "text_3",
                    ReplayDetection = new MaintenanceOrdersOutBoundDomain.ReplayDetectionTypeDto
                    {
                        Nonce = "text_4",
                        Created = DateTime.Now
                    },
                    Context = "text_5",
                    Timestamp = DateTime.Now,
                    TimestampSpecified = true,
                    Source = "text_6",
                    AsyncReplyFlag = true,
                    AsyncReplyFlagSpecified = true,
                    ReplyAddress = "text_7",
                    AckRequired = true,
                    AckRequiredSpecified = true,
                    User = new MaintenanceOrdersOutBoundDomain.UserTypeDto
                    {
                        UserID = "text_8",
                        Organization = "text_9"
                    },
                    MessageID = "text_10",
                    CorrelationID = "text_11",
                    Comment = "text_12",
                    Property = new MaintenanceOrdersOutBoundDomain.MessagePropertyDto[]
                    {
                        new MaintenanceOrdersOutBoundDomain.MessagePropertyDto
                        {
                        Name = "text_13",
                        Value = "text_14"
                        }
       
                    },

                },
                Payload = new MaintenanceOrdersOutBoundDomain.IFSMaintenanceOrdersMessageType1Dto
                {
                    MaintenanceOrders = new MaintenanceOrdersOutBoundDomain.WorkDto[]
                    {
                        new MaintenanceOrdersOutBoundDomain.WorkDto
                        {
                            MRID = "text_17",
                            WorkOrderNo = "text_18",
                            IFS_RECORD_NUM = "text_19",
                            IFSStatus = "text_20",
                            WorkTasks = new MaintenanceOrdersOutBoundDomain.WorkTaskDto[]
                            {
                                new MaintenanceOrdersOutBoundDomain.WorkTaskDto
                                {
                                    MRID = "text_21",
                                    TaskIFSID = "text_22",
                                    IFSStatus = "text_23"
                                }            
                            },
                        },      
                    },
                },
            };


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













////string textMessageS = JsonSerializer.Serialize(workOrderIfsDto);

////string textMessageS = new StreamReader(@"BodyData.json").ReadToEnd();

//var resultAONumber = _ifsCloudService.CreateWorkOrder(textMessageS);





//workOrderTaskIfsDto.WoNo = resultAONumber;

//string jsonMsgTarget = JsonConvert.SerializeObject(workOrderTaskIfsDto, Newtonsoft.Json.Formatting.Indented);


//var result2 = _ifsCloudService.CreateWorkOrderTask(jsonMsgTarget);

//int tst = 2;


////var tst = _mapper.Map<Model.WorkOrderIfsDto>(maintenanceOrders.Body.ChangedMaintenanceOrders);

////var isAO = status.Payload.MaintenanceOrders.Work[0].IFSStatus == "INIT";


////string jsonMsgTarget = JsonConvert.SerializeObject(status, Newtonsoft.Json.Formatting.Indented);


////string textMessage = new StreamReader(@"BodyData.json").ReadToEnd();

////string testMessageTask = new StreamReader(@"BodyDataTask.json").ReadToEnd();

//////var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
////var bodyObject = JsonConvert.DeserializeObject<Model.WorkOrderIfsDto>(textMessage);

////var bodyObjectTask = JsonConvert.DeserializeObject<Model.WorkTaskIfsDto>(testMessageTask);


////var textMessageS = JsonConvert.SerializeObject(bodyObject);








////bodyObjectTask.WoNo = result;

////var textMessageT = JsonConvert.SerializeObject(bodyObjectTask);

////var result2 = _ifsWorkOrder.Publish(textMessageT, true);


////return (textMessageT, "", "", maintenanceOrdersDto?.Body?.ChangedMaintenanceOrders?.Header?.CorrelationID);

//return ("", "", "", "");
