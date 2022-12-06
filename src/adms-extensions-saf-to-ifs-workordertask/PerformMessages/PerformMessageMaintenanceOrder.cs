﻿using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using AutoMapper;
using ServicesIfs;
using MaintenanceOrdersInBoundDomain;
using Newtonsoft.Json;
using Model;
using ServicesUniqueId;

namespace adms_extensions_saf_to_ifs_workordertask.PerformMessages
{

    public class PerformMessageMaintenanceOrder : IPerformMessageMaintenanceOrder
    {
        private readonly IUniqueIdService _uniqueIdService;
        private readonly IIfsCloudService _ifsCloudService;
        public IMapper _mapper { get; }
        public MaintenanceOrdersOutBound.IMaintenanceOrders_Port _client { get; }


        public PerformMessageMaintenanceOrder(IUniqueIdService uniqueIdService, IIfsCloudService ifsCloudService, IMapper mapper, MaintenanceOrdersOutBound.IMaintenanceOrders_Port client)
        {
            _uniqueIdService = uniqueIdService;
            _ifsCloudService = ifsCloudService;
            _mapper = mapper;
            _client = client;
        }


        public (string, string) Invoke(string xmlMessage)
        {
            MaintenanceOrdersOutBound.IFSMaintenanceOrdersInput iFSMaintenanceOrdersInput;

            MaintenanceOrdersDto maintenanceOrdersDto;
            WorkOrderIfsDto workOrderIfsDto;
            WorkOrderTaskIfsDto workOrderTaskIfsDto;

            string requestMessageWorkOrder = "";
            string resultWorkOrderNumber = "";
            string requestMessageWorkOrderTask = "";
            string resultWorkOrderTaskNumber = "";

            string returnXMLMessageToSaf = "";

            try
            {

                //"ObjectType": "db83df58-1140-4a60-b6d1-9dacc6f2cbf0",

                string oName = "KhaiQ 11 H01";
                //////oName = "Ulven/300/T4/A";

                oName = "Kjelsås 11 4911";
                var test = _uniqueIdService.GetUniqueId(oName).Result;

                //var g = new Guid("8ba41b41-f627-47a6-ac53-7354ae9b022d");
                //g = test;

                var ssss = _uniqueIdService.GetName(test).Result;

                //throw new Exception("in ifscloudservice");
                //MapInBoundMessage(xmlMessage, out maintenanceOrdersDto, out workOrderIfsDto, out workOrderTaskIfsDto);


                workOrderIfsDto = new WorkOrderIfsDto();

                maintenanceOrdersDto = new MaintenanceOrdersDto();

                workOrderTaskIfsDto = new WorkOrderTaskIfsDto();

                //SetFieldsTemp(workOrderIfsDto, workOrderTaskIfsDto);// To be removed..

                workOrderIfsDto.Sender = "ELSMART";  //Obl.
                //workOrderIfsDto.Sender = "ADMS-EXTENSIONS";  //Obl.
                workOrderIfsDto.Context = "STANDARD";        //Obl.

                //workOrderIfsDto.MchCode =  "0022/11/H1";//"NS.0152";

                workOrderIfsDto.MchCode = "NS.0152";

                workOrderIfsDto.RegDate = "2022-11-25T15:00:00";//Obl.

                workOrderIfsDto.ErrDescr = ".";//Obl.
                workOrderIfsDto.LatestFinish = "2022-11-30T08:09:47";

                workOrderIfsDto.OrgCode = "01B2B001";//Obl.

                //_________________________________________________________________________________________

                requestMessageWorkOrder = JsonConvert.SerializeObject(workOrderIfsDto, Newtonsoft.Json.Formatting.Indented);

                resultWorkOrderNumber = _ifsCloudService.CreateWorkOrder(requestMessageWorkOrder).Result;

                workOrderTaskIfsDto.Sender = "ELSMART";  //Obl.
                //workOrderTaskIfsDto.Sender = "ADMS-EXTENSIONS"; //Obl.
                workOrderTaskIfsDto.Context = "STANDARD";       //Obl.
                workOrderTaskIfsDto.ContextSub = "";

                workOrderTaskIfsDto.WoNo = resultWorkOrderNumber;

                //workOrderTaskIfsDto.ExtRefKeyTask = "HUB.4321";
                //workOrderTaskIfsDto.MchCode = "0022/11/H1";
                workOrderTaskIfsDto.MchCode = "NS.0152";

                workOrderTaskIfsDto.Description = "Just another task \u2013 never-ending story";
                workOrderTaskIfsDto.LongDescription = "LongDescr";
                workOrderTaskIfsDto.ReportedBy = "ELVIA_ENTR";
                //workOrderTaskIfsDto.ReportedBy = "ADMS/ISS";
                workOrderTaskIfsDto.OrgCode = "01B2B001";


                //workOrderTaskIfsDto.WoNo = resultWorkOrderNumber; //AO

                requestMessageWorkOrderTask = JsonConvert.SerializeObject(workOrderTaskIfsDto, Newtonsoft.Json.Formatting.Indented);

                resultWorkOrderTaskNumber = _ifsCloudService.CreateWorkOrderTask(requestMessageWorkOrderTask).Result;

                MapOutBoundMessage(resultWorkOrderNumber, resultWorkOrderTaskNumber, maintenanceOrdersDto, out iFSMaintenanceOrdersInput);


                ////_client.IFSMaintenanceOrders(iFSMaintenanceOrdersInput);

                //returnXMLMessageToSaf = JsonConvert.SerializeObject(iFSMaintenanceOrdersInput, Newtonsoft.Json.Formatting.Indented);

            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: " + ex.Message + "  " + ex.StackTrace + "___#####__" + requestMessageWorkOrder + "___#####__" + requestMessageWorkOrderTask + "___#####__");
            }


            string targetMessages  = "\r\n\r\nWorkOrderRequest: \r\n" + requestMessageWorkOrder + "\r\nResult:" + resultWorkOrderNumber;
                   targetMessages += "\r\n\r\nWorkOrderTaskRequest: \r\n" + requestMessageWorkOrderTask + "\r\nResult:" + resultWorkOrderTaskNumber;
                   targetMessages += "\r\n\r\nReturnMessageToSAF: \r\n" + returnXMLMessageToSaf + "\r\n";

            string id = maintenanceOrdersDto.MessageId;

            return (targetMessages, id);
        }



        private void MapInBoundMessage(string xmlMessage, out MaintenanceOrdersDto maintenanceOrdersDto, out Model.WorkOrderIfsDto workOrderDto, out Model.WorkOrderTaskIfsDto workOrderTaskDto)
        {
            StringReader sReader = new StringReader(xmlMessage);

            var maintenanceOrders = Utils.DeSerialize<MaintenanceOrdersInBound.Envelope>(sReader);

            maintenanceOrdersDto = _mapper.Map<MaintenanceOrdersDto>(maintenanceOrders.Body.ChangedMaintenanceOrders);

            workOrderDto = _mapper.Map<Model.WorkOrderIfsDto>(maintenanceOrders.Body.ChangedMaintenanceOrders);

            workOrderTaskDto = _mapper.Map<Model.WorkOrderTaskIfsDto>(maintenanceOrders.Body.ChangedMaintenanceOrders);
        }



        private void MapOutBoundMessage(string resultWorkOrderNumber, string resultWorkOrderTaskNumber, MaintenanceOrdersDto maintenanceOrdersDto, out MaintenanceOrdersOutBound.IFSMaintenanceOrdersInput iFSMaintenanceOrdersInput)
        {

            var iFSMaintenanceOrdersInputDto = new MaintenanceOrdersOutBoundDomain.IFSMaintenanceOrdersInputDto
            {
                IFSMaintenanceOrders = new MaintenanceOrdersOutBoundDomain.IFSMaintenanceOrdersMessageTypeDto
                {
                    Header = new MaintenanceOrdersOutBoundDomain.HeaderTypeDto
                    {
                        //Verb = "text_1",
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
                                WorkOrderNo = resultWorkOrderNumber,
                                IFS_RECORD_NUM = "text_19",
                                IFSStatus = "OK",
                                WorkTasks = new MaintenanceOrdersOutBoundDomain.WorkTaskDto[]
                                {
                                    new MaintenanceOrdersOutBoundDomain.WorkTaskDto
                                    {
                                        MRID = "text_21",
                                        TaskIFSID = resultWorkOrderTaskNumber,
                                        IFSStatus = "OK"
                                    }
                                },
                            },
                        },
                    },
                }

            };



            iFSMaintenanceOrdersInput = _mapper.Map<MaintenanceOrdersOutBound.IFSMaintenanceOrdersInput>(iFSMaintenanceOrdersInputDto);
        }



        private static void SetFieldsTemp(WorkOrderIfsDto workOrderIfsDto, WorkOrderTaskIfsDto workOrderTaskIfsDto)
        {
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



