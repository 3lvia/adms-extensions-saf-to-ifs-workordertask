using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class IFSWorkOrderBody
    {
        public string Sender { get; set; }
        //public string Context { get; set; }
        //public string ContextSub { get; set; }
        //public string RegDate { get; set; }
        //public string Objstate { get; set; }
        //public string ExtRefKeyWo { get; set; }
        //public string MchCode { get; set; }
        //public string UuidObject { get; set; }
        //public string ErrDescr { get; set; }
        //public string ErrDescrLo { get; set; }
        //public string WorkDescrLo { get; set; }
        //public string LatestFinish { get; set; }
        //public string ReportedBy { get; set; }
        //public string CustomerNo { get; set; }
        //public string UuidCustomer { get; set; }
        //public string ReferenceNo { get; set; }
        //public string PhoneNo { get; set; }
        //public string Contact { get; set; }
        //public string OrgCode { get; set; }
        //public string WorkMasterSign { get; set; }

        //public InfoFields[] InfoFields { get; set; }
        //public WorkTasks[] WorkTasks { get; set; }
    }

    public class InfoFields
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }


    public class WorkTasks
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
        public InfoFields[] InfoFields { get; set; }
    }





}
