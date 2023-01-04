using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class WorkOrderIfsDto
    {
        public string Sender { get; set; }
        public string Context { get; set; }
        public string ContextSub { get; set; }
        public string RegDate { get; set; }
        public string Objstate { get; set; }
        public string ExtRefKeyWo { get; set; }
        public string MchCode { get; set; }
        public string UuidObject { get; set; }
        public string ErrDescr { get; set; }
        public string ErrDescrLo { get; set; }
        public string WorkDescrLo { get; set; }
        public string LatestFinish { get; set; }
        public string ReportedBy { get; set; }
        public string CustomerNo { get; set; }
        public string UuidCustomer { get; set; }
        public string ReferenceNo { get; set; }
        public string PhoneNo { get; set; }
        public string Contact { get; set; }
        public string OrgCode { get; set; }
        public string WorkMasterSign { get; set; }

        public List<InfoFieldsDto> InfoFields { get; set; } = new List<InfoFieldsDto>();
        public List<WorkTasksDto> WorkTasks { get; set; } = new List<WorkTasksDto>();
    }

    public class InfoFieldsDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }


    public class WorkTasksDto
    {
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public string PlannedStart { get; set; }
        public string PlannedFinish { get; set; }
        public string MchCode { get; set; }
        public string UuidObject { get; set; }
        public string OrgCode { get; set; }
        public string Objstate { get; set; }
        public string ExtRefKeyTask { get; set; }
        public string ReportedBy { get; set; }
        public string Contact { get; set; }
        public string ContactPhoneNo { get; set; }
        public string ReferenceNo { get; set; }
        public string CustomerNo { get; set; }
        public string UuidCustomer { get; set; }
        public string VendorNo { get; set; }
        public InfoFieldsDto[] InfoFields { get; set; }

    }





}
