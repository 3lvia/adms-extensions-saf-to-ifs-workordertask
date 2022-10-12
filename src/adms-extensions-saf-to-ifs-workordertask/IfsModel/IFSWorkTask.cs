using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class IFSWorkTaskBody
    {
        public string Sender { get; set; }
        public string Context { get; set; }
        public string ContextSub { get; set; }
        public string RegDate { get; set; }
        public string Objstate { get; set; }
        public string WoNo { get; set; }
        public string ExtRefKeyWo { get; set; }
        public string ExtRefKeyTask { get; set; }
        public string MchCode { get; set; }
        public string UuidObject { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public string PlannedStart { get; set; }
        public string PlannedFinish { get; set; }
        public string ReportedBy { get; set; }
        public string Contact { get; set; }
        public string ContactPhoneNo { get; set; }
        public string ReferenceNo { get; set; }
        public string CustomerNo { get; set; }
        public string UuidCustomer { get; set; }
        public string VendorNo { get; set; }
        public string OrgCode { get; set; }
        public InfoFields[] InfoFields { get; set; }
    }
}
