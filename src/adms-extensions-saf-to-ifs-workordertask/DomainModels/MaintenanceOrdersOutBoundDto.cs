using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceOrdersOutBoundDomain;


public class IFSMaintenanceOrdersInputDto
{
    public IFSMaintenanceOrdersMessageTypeDto IFSMaintenanceOrders { get; set; }

}



public class IFSMaintenanceOrdersMessageTypeDto
{
    public HeaderTypeDto? Header { get; set; }
    public IFSMaintenanceOrdersMessageType1Dto? Payload { get; set; }

}


public class HeaderTypeDto
{
    //public HeaderTypeVerbDto? Verb { get; set; }
    public System.String? Verb { get; set; }

    public System.String? Noun { get; set; }
    public System.String? Revision { get; set; }
    public ReplayDetectionTypeDto? ReplayDetection { get; set; }
    public System.String? Context { get; set; }
    public System.DateTime? Timestamp { get; set; }
    public Boolean? TimestampSpecified { get; set; }
    public System.String? Source { get; set; }
    public Boolean? AsyncReplyFlag { get; set; }
    public Boolean? AsyncReplyFlagSpecified { get; set; }
    public System.String? ReplyAddress { get; set; }
    public Boolean? AckRequired { get; set; }
    public Boolean? AckRequiredSpecified { get; set; }
    public UserTypeDto? User { get; set; }
    public System.String? MessageID { get; set; }
    public System.String? CorrelationID { get; set; }
    public System.String? Comment { get; set; }
    public MessagePropertyDto[]? Property { get; set; }
    public System.Xml.XmlElement[] anyField { get; set; }

}


public class HeaderTypeVerbDto
{
    public Int32? Value__ { get; set; }

}


public class ReplayDetectionTypeDto
{
    public System.String? Nonce { get; set; }
    public System.DateTime? Created { get; set; }

}


public class UserTypeDto
{
    public System.String? UserID { get; set; }
    public System.String? Organization { get; set; }

}


public class MessagePropertyDto
{
    public System.String? Name { get; set; }
    public System.String? Value { get; set; }

}


public class IFSMaintenanceOrdersMessageType1Dto
{
    public WorkDto[]? MaintenanceOrders { get; set; }

}


public class WorkDto
{
    public System.String? MRID { get; set; }
    public System.String? WorkOrderNo { get; set; }
    public System.String? IFS_RECORD_NUM { get; set; }
    public System.String? IFSStatus { get; set; }
    public WorkTaskDto[]? WorkTasks { get; set; }

}


public class WorkTaskDto
{
    public System.String? MRID { get; set; }
    public System.String? TaskIFSID { get; set; }
    public System.String? IFSStatus { get; set; }

}
