using System;

namespace MaintenanceOrdersInBoundDomain;


public class MaintenanceOrdersDto 
{
    const string _flow = "MaintenanceOrders-MaintenanceOrdersResp";
    public string _id { get; set; }

    public string MessageId { get; set; }
    public DateTime PublishedDateTime { get; set; }

    public static string KvalitetsportalenFlowStatic()
    {
        return _flow;
    }

    public string KvalitetsportalenFlow()
    {
        return KvalitetsportalenFlowStatic();
    }

    public string LocalUrl()
    {
        return "/api/receivers/resultmsg-maintenanceorders-adms-endpoint/entities";
    }

    public MaintenanceOrdersTypeDto Payload { get; set; }

}




public class MaintenanceOrdersResponseMessageTypeDto
{
    public HeaderType1Dto? Header { get; set; }
    public string? CorrelationId { get; set; }
    public DetailedFaultResponseTypeDto[]? Payload { get; set; }

}


public class HeaderType1Dto
{
    public string? verb { get; set; }
    public string? source { get; set; }
    public string? operation { get; set; }
    public string? messageId { get; set; }
    public System.DateTime? publishedDateTime { get; set; }

}


public class DetailedFaultResponseTypeDto
{
    public string? mRID { get; set; }
    public bool? success { get; set; }
    public StandardFaultDto[]? StandardFault { get; set; }

}


public class StandardFaultDto
{
    public EventLog1Dto? EventLog { get; set; }

}


public class EventLog1Dto
{
    public string? detailedMessageText { get; set; }
    public string? messageText { get; set; }
    public string? resultCode { get; set; }
    public string? severity { get; set; }
    public string? stackTrace { get; set; }

}


public class MaintenanceOrdersEventMessageTypeDto
{
    public HeaderTypeDto? Header { get; set; }
    public string? CorrelationId { get; set; }
    public MaintenanceOrdersTypeDto? Payload { get; set; }

}


public class HeaderTypeDto
{
    public string? Verb { get; set; }  //HeaderTypeVerb  
    public string? Noun { get; set; }
    public string? Revision { get; set; }
    public ReplayDetectionTypeDto? ReplayDetection { get; set; }
    public string? Context { get; set; }
    public System.DateTime? Timestamp { get; set; }
    public bool? TimestampSpecified { get; set; }
    public string? Source { get; set; }
    public bool? AsyncReplyFlag { get; set; }
    public bool? AsyncReplyFlagSpecified { get; set; }
    public string? ReplyAddress { get; set; }
    public bool? AckRequired { get; set; }
    public bool? AckRequiredSpecified { get; set; }
    public UserTypeDto? User { get; set; }
    public string? MessageID { get; set; }
    public string? CorrelationID { get; set; }
    public string? Comment { get; set; }
    public MessagePropertyDto[]? Property { get; set; }
    //public Xml.XmlElementDto[]? Any { get; set; }
    public string? Any { get; set; }
}


public class ReplayDetectionTypeDto
{
    public string? Nonce { get; set; }
    public System.DateTime? Created { get; set; }

}


public class UserTypeDto
{
    public string? UserID { get; set; }
    public string? Organization { get; set; }

}


public class MessagePropertyDto
{
    public string? Name { get; set; }
    public string? Value { get; set; }

}


public class MaintenanceOrdersTypeDto
{
    public MaintenanceOrdersTypeMaintenanceOrdersDto? MaintenanceOrders { get; set; }

}


public class MaintenanceOrdersTypeMaintenanceOrdersDto
{
    public OrganisationDto[]? Organisation { get; set; }
    public WorkDto[]? Work { get; set; }

}


public class OrganisationDto
{
    public string? mRID { get; set; }

}


public class WorkDto
{
    public string? mRID { get; set; }
    public string? RECORD_OID { get; set; }
    public string? Category { get; set; }
    public string? TYPE { get; set; }
    public string? WorkCategory { get; set; }
    public System.DateTime? lastModifiedDateTime { get; set; }
    public bool? lastModifiedDateTimeSpecified { get; set; }
    public string? statusKind { get; set; }
    public string? WorkStatusNum { get; set; }
    public WorkNamesDto[]? Names { get; set; }
    public string? WorkOrderNo { get; set; }
    public string? IFS_RECORD_NUM { get; set; }
    public string? IFSStatus { get; set; }
    public WorkPriorityDto? priority { get; set; }
    public string? subject { get; set; }
    public EquipmentDto? TriggerEquipment { get; set; }
    public WorkTimeScheduleDto[]? TimeSchedules { get; set; }
    public System.DateTime? EST_TS { get; set; }
    public bool? EST_TSSpecified { get; set; }
    public System.DateTime? ACT_TS { get; set; }
    public bool? ACT_TSSpecified { get; set; }
    public System.DateTime? EST_TC { get; set; }
    public bool? EST_TCSpecified { get; set; }
    public System.DateTime? ACT_TC { get; set; }
    public bool? ACT_TCSpecified { get; set; }
    public System.DateTime? OPERATOR_EST_TS { get; set; }
    public bool? OPERATOR_EST_TSSpecified { get; set; }
    public System.DateTime? OPERATOR_BEGIN_EST { get; set; }
    public bool? OPERATOR_BEGIN_ESTSpecified { get; set; }
    public System.DateTime? OPERATOR_END_EST { get; set; }
    public bool? OPERATOR_END_ESTSpecified { get; set; }
    public System.DateTime? OPERATOR_EST_TC { get; set; }
    public bool? OPERATOR_EST_TCSpecified { get; set; }
    public string? END_ACT_DELAY_CAUSE { get; set; }
    public string? CAUSE_OR_REASON { get; set; }
    public string? FAULT_CATEGORY { get; set; }
    public string? FAULT_EQUIPMENT { get; set; }
    public string? DeviceLocation { get; set; }
    public string? EMERGENCY_HAZARD_INDICATOR { get; set; }
    public string? POLE_NUMBER { get; set; }
    public string? SUBSTATION { get; set; }
    public string? STORM_OID { get; set; }
    public string? CREATION_USER_NAME { get; set; }
    public System.DateTime? CREATION_TIMESTAMP { get; set; }
    public bool? CREATION_TIMESTAMPSpecified { get; set; }
    public string? POWER_IS_CUT { get; set; }
    public WorkLocationDto? WorkLocation { get; set; }
    public string? userName { get; set; }
    public WorkTaskDto[]? WorkTasks { get; set; }

}


public class WorkNamesDto
{
    public string? name { get; set; }

}


public class WorkPriorityDto
{
    public string? rank { get; set; }

}


public class EquipmentDto
{
    public string? mRID { get; set; }
    public EquipmentNamesDto[]? Names { get; set; }
    public string? type { get; set; }
    public string? B1TEXT { get; set; }
    public string? B2TEXT { get; set; }
    public string? B3TEXT { get; set; }
    public string? ELTEXT { get; set; }
    public string? Feedername { get; set; }
    public string? FeederLV { get; set; }
    public string? VoltageLevelNum { get; set; }

}


public class EquipmentNamesDto
{
    public string? name { get; set; }

}


public class WorkTimeScheduleDto
{
    public string? kind { get; set; }
    public WorkTimeScheduleScheduleIntervalDto? scheduleInterval { get; set; }

}


public class WorkTimeScheduleScheduleIntervalDto
{
    public System.DateTime? end { get; set; }
    public bool? endSpecified { get; set; }
    public System.DateTime? start { get; set; }
    public bool? startSpecified { get; set; }

}


public class WorkLocationDto
{
    public string? mRID { get; set; }
    public WorkLocationCoordinateSystemDto? CoordinateSystem { get; set; }
    public WorkLocationPositionPointsDto[]? PositionPoints { get; set; }

}


public class WorkLocationCoordinateSystemDto
{
    public string? crsUrn { get; set; }

}


public class WorkLocationPositionPointsDto
{
    public string? sequenceNumber { get; set; }
    public string? xPosition { get; set; }
    public string? yPosition { get; set; }
    public string? zPosition { get; set; }

}


public class WorkTaskDto
{
    public string? mRID { get; set; }
    public System.DateTime? lastModifiedDateTime { get; set; }
    public bool? lastModifiedDateTimeSpecified { get; set; }
    public System.DateTime? creationDateTime { get; set; }
    public bool? creationDateTimeSpecified { get; set; }
    public System.DateTime? crewETA { get; set; }
    public bool? crewETASpecified { get; set; }
    public System.DateTime? crewATA { get; set; }
    public bool? crewATASpecified { get; set; }
    public System.DateTime? crewETC { get; set; }
    public bool? crewETCSpecified { get; set; }
    public System.DateTime? crewATC { get; set; }
    public bool? crewATCSpecified { get; set; }
    public string? instruction { get; set; }
    public string? subject { get; set; }
    public string? repairSequence { get; set; }
    public string? editable { get; set; }
    public string? crewType { get; set; }  //CrewType  
    public bool? crewTypeSpecified { get; set; }
    public string? deviceType { get; set; }  //DeviceType  
    public bool? deviceTypeSpecified { get; set; }
    public string? statusKind { get; set; }
    public string? sequenceNumber { get; set; }
    public string? taskKind { get; set; }
    public CrewDto[]? Crews { get; set; }
    public WorkTaskNamesDto[]? Names { get; set; }
    public string? TaskIFSID { get; set; }
    public string? IFSStatus { get; set; }
    public WorkTimeScheduleDto[]? TimeSchedules { get; set; }
    public AssetDto[]? Assets { get; set; }

}


public class CrewDto
{
    public string? mRID { get; set; }
    public System.DateTime? lastModifiedDateTime { get; set; }
    public bool? lastModifiedDateTimeSpecified { get; set; }
    public StatusDto? status { get; set; }
    public CrewMemberDto[]? CrewMembers { get; set; }
    public CrewNamesDto[]? Names { get; set; }
    public WorkAssetDto[]? WorkAssets { get; set; }

}


public class StatusDto
{
    public System.DateTime? dateTime { get; set; }
    public string? value { get; set; }

}


public class CrewMemberDto
{
    public CrewMemberPersonDto? Person { get; set; }

}


public class CrewMemberPersonDto
{
    public string? mRID { get; set; }
    public System.DateTime? lastModifiedDateTime { get; set; }
    public bool? lastModifiedDateTimeSpecified { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string? prefix { get; set; }
    public string? employeeId { get; set; }
    public TelephoneNumberDto? mobilePhone { get; set; }
    public ElectronicAddressDto? electronicAddress { get; set; }

}


public class TelephoneNumberDto
{
    public string? localNumber { get; set; }

}


public class ElectronicAddressDto
{
    public string? email1 { get; set; }

}


public class CrewNamesDto
{
    public string? name { get; set; }
    public CrewNamesNameTypeDto? NameType { get; set; }

}


public class CrewNamesNameTypeDto
{
    public string? description { get; set; }
    public string? name { get; set; }
    public CrewNamesNameTypeNameTypeAuthorityDto? NameTypeAuthority { get; set; }

}


public class CrewNamesNameTypeNameTypeAuthorityDto
{
    public string? description { get; set; }
    public string? name { get; set; }

}


public class WorkAssetDto
{
    public string? usageKind { get; set; }
    public string? mRID { get; set; }
    public System.DateTime? lastModifiedDateTime { get; set; }
    public bool? lastModifiedDateTimeSpecified { get; set; }
    public bool? critical { get; set; }
    public string? utcNumber { get; set; }
    public StatusDto? status { get; set; }
    public string? type { get; set; }
    public WorkLocationDto? Location { get; set; }
    public AssetNamesDto[]? Names { get; set; }

}


public class AssetNamesDto
{
    public string? name { get; set; }

}


public class WorkTaskNamesDto
{
    public string? name { get; set; }

}


public class AssetDto
{
    public string? mRID { get; set; }
    public System.DateTime? lastModifiedDateTime { get; set; }
    public bool? lastModifiedDateTimeSpecified { get; set; }
    public bool? critical { get; set; }
    public string? utcNumber { get; set; }
    public StatusDto? status { get; set; }
    public string? type { get; set; }
    public WorkLocationDto? Location { get; set; }
    public AssetNamesDto[]? Names { get; set; }

}


