using System;

namespace MaintenanceOrdersDomain;

public class MaintenanceOrdersDto 
{
    public string _id { get; set; }

    public string MessageId { get; set; }
    public DateTime PublishedDateTime { get; set; }

    public string KvalitetsportalenFlow()
    {
        return "MaintenanceOrders-MaintenanceOrdersResp";
    }

    public string LocalUrl()
    {
        return "/api/receivers/resultmsg-maintenanceorders-adms-endpoint/entities";
    }

    public MaintenanceOrdersTypeDto Payload { get; set; }

}




//public class EnvelopeDto
//{
//    public EnvelopeBodyDto? Body { get; set; }

//}


//public class EnvelopeBodyDto
//{
//    public MaintenanceOrdersEventMessageTypeDto? ChangedMaintenanceOrders { get; set; }
//    public MaintenanceOrdersResponseMessageTypeDto? MaintenanceOrdersEventMessageType { get; set; }
//    public MaintenanceOrdersResponseMessageTypeDto? IFSMaintenanceOrdersResponseMessageType { get; set; }

//}


public class MaintenanceOrdersEventMessageTypeDto
{
    public HeaderTypeDto? Header { get; set; }
    public System.String? CorrelationId { get; set; }
    public MaintenanceOrdersTypeDto? Payload { get; set; }

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

    public System.Xml.XmlElement[] Any { get; set; }

    //public System.String any { get; set; }
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
    public System.String? MRID { get; set; }

}


public class WorkDto
{
    public System.String? MRID { get; set; }
    public System.String? RECORD_OID { get; set; }
    public System.String? Category { get; set; }
    public System.String? TYPE { get; set; }
    public System.String? WorkCategory { get; set; }
    public System.DateTime? LastModifiedDateTime { get; set; }
    public Boolean? LastModifiedDateTimeSpecified { get; set; }
    public System.String? StatusKind { get; set; }
    public System.String? WorkStatusNum { get; set; }
    public WorkNamesDto[]? Names { get; set; }
    public System.String? WorkOrderNo { get; set; }
    public System.String? IFS_RECORD_NUM { get; set; }
    public System.String? IFSStatus { get; set; }
    public WorkPriorityDto? Priority { get; set; }
    public System.String? Subject { get; set; }
    public EquipmentDto? TriggerEquipment { get; set; }
    public WorkTimeScheduleDto[]? TimeSchedules { get; set; }
    public System.DateTime? EST_TS { get; set; }
    public Boolean? EST_TSSpecified { get; set; }
    public System.DateTime? ACT_TS { get; set; }
    public Boolean? ACT_TSSpecified { get; set; }
    public System.DateTime? EST_TC { get; set; }
    public Boolean? EST_TCSpecified { get; set; }
    public System.DateTime? ACT_TC { get; set; }
    public Boolean? ACT_TCSpecified { get; set; }
    public System.DateTime? OPERATOR_EST_TS { get; set; }
    public Boolean? OPERATOR_EST_TSSpecified { get; set; }
    public System.DateTime? OPERATOR_BEGIN_EST { get; set; }
    public Boolean? OPERATOR_BEGIN_ESTSpecified { get; set; }
    public System.DateTime? OPERATOR_END_EST { get; set; }
    public Boolean? OPERATOR_END_ESTSpecified { get; set; }
    public System.DateTime? OPERATOR_EST_TC { get; set; }
    public Boolean? OPERATOR_EST_TCSpecified { get; set; }
    public System.String? END_ACT_DELAY_CAUSE { get; set; }
    public System.String? CAUSE_OR_REASON_NUM { get; set; }
    public System.String? FAULT_CATEGORY_NUM { get; set; }
    public System.String? FAULT_EQUIPMENT_NUM { get; set; }
    public System.String? DeviceLocation { get; set; }
    public System.String? EMERGENCY_HAZARD_INDICATOR { get; set; }
    public System.String? POLE_NUMBER { get; set; }
    public System.String? SUBSTATION { get; set; }
    public System.String? STORM_OID { get; set; }
    public System.String? CREATION_USER_NAME { get; set; }
    public System.DateTime? CREATION_TIMESTAMP { get; set; }
    public Boolean? CREATION_TIMESTAMPSpecified { get; set; }
    public System.String? POWER_IS_CUT { get; set; }
    public WorkLocationDto? WorkLocation { get; set; }
    public System.String? UserName { get; set; }
    public WorkTaskDto[]? WorkTasks { get; set; }

}


public class WorkNamesDto
{
    public System.String? Name { get; set; }

}


public class WorkPriorityDto
{
    public System.String? Rank { get; set; }

}


public class EquipmentDto
{
    public System.String? MRID { get; set; }
    public EquipmentNamesDto[]? Names { get; set; }
    public System.String? Type { get; set; }
    public System.String? B1TEXT { get; set; }
    public System.String? B2TEXT { get; set; }
    public System.String? B3TEXT { get; set; }
    public System.String? ELTEXT { get; set; }
    public System.String? Feedername { get; set; }
    public System.String? VoltageLevelNum { get; set; }

}


public class EquipmentNamesDto
{
    public System.String? Name { get; set; }

}


public class WorkTimeScheduleDto
{
    public System.String? Kind { get; set; }
    public WorkTimeScheduleScheduleIntervalDto? ScheduleInterval { get; set; }

}


public class WorkTimeScheduleScheduleIntervalDto
{
    public System.DateTime? End { get; set; }
    public Boolean? EndSpecified { get; set; }
    public System.DateTime? Start { get; set; }
    public Boolean? StartSpecified { get; set; }

}


public class WorkLocationDto
{
    public System.String? MRID { get; set; }
    public WorkLocationCoordinateSystemDto? CoordinateSystem { get; set; }
    public WorkLocationPositionPointsDto[]? PositionPoints { get; set; }

}


public class WorkLocationCoordinateSystemDto
{
    public System.String? CrsUrn { get; set; }

}


public class WorkLocationPositionPointsDto
{
    public System.String? SequenceNumber { get; set; }
    public System.String? XPosition { get; set; }
    public System.String? YPosition { get; set; }
    public System.String? ZPosition { get; set; }

}


public class WorkTaskDto
{
    public System.String? MRID { get; set; }
    public System.DateTime? LastModifiedDateTime { get; set; }
    public Boolean? LastModifiedDateTimeSpecified { get; set; }
    public System.DateTime? CreationDateTime { get; set; }
    public Boolean? CreationDateTimeSpecified { get; set; }
    public System.DateTime? CrewETA { get; set; }
    public Boolean? CrewETASpecified { get; set; }
    public System.DateTime? CrewATA { get; set; }
    public Boolean? CrewATASpecified { get; set; }
    public System.DateTime? CrewETC { get; set; }
    public Boolean? CrewETCSpecified { get; set; }
    public System.DateTime? CrewATC { get; set; }
    public Boolean? CrewATCSpecified { get; set; }
    public System.String? Instruction { get; set; }
    public System.String? Subject { get; set; }
    public System.String? RepairSequence { get; set; }
    public System.String? Editable { get; set; }
    //public CrewTypeDto? CrewType { get; set; }

    public System.String? CrewType { get; set; }
    public Boolean? CrewTypeSpecified { get; set; }
    //public DeviceTypeDto? DeviceType { get; set; }

    public System.String? DeviceType { get; set; }
    public Boolean? DeviceTypeSpecified { get; set; }
    public System.String? StatusKind { get; set; }
    public System.String? SequenceNumber { get; set; }
    public System.String? TaskKind { get; set; }
    public CrewDto[]? Crews { get; set; }
    public WorkTaskNamesDto[]? Names { get; set; }
    public System.String? TaskIFSID { get; set; }
    public System.String? IFSStatus { get; set; }
    public WorkTimeScheduleDto[]? TimeSchedules { get; set; }
    public AssetDto[]? Assets { get; set; }

}


public class CrewTypeDto
{
    public Int32? Value__ { get; set; }

}


public class DeviceTypeDto
{
    public Int32? Value__ { get; set; }

}


public class CrewDto
{
    public System.String? MRID { get; set; }
    public System.DateTime? LastModifiedDateTime { get; set; }
    public Boolean? LastModifiedDateTimeSpecified { get; set; }
    public StatusDto? Status { get; set; }
    public CrewMemberDto[]? CrewMembers { get; set; }
    public CrewNamesDto[]? Names { get; set; }
    public WorkAssetDto[]? WorkAssets { get; set; }

}


public class StatusDto
{
    public System.DateTime? DateTime { get; set; }
    public System.String? Value { get; set; }

}


public class CrewMemberDto
{
    public CrewMemberPersonDto? Person { get; set; }

}


public class CrewMemberPersonDto
{
    public System.String? MRID { get; set; }
    public System.DateTime? LastModifiedDateTime { get; set; }
    public Boolean? LastModifiedDateTimeSpecified { get; set; }
    public System.String? FirstName { get; set; }
    public System.String? LastName { get; set; }
    public System.String? Prefix { get; set; }
    public System.String? EmployeeId { get; set; }
    public TelephoneNumberDto? MobilePhone { get; set; }
    public ElectronicAddressDto? ElectronicAddress { get; set; }

}


public class TelephoneNumberDto
{
    public System.String? LocalNumber { get; set; }

}


public class ElectronicAddressDto
{
    public System.String? Email1 { get; set; }

}


public class CrewNamesDto
{
    public System.String? Name { get; set; }
    public CrewNamesNameTypeDto? NameType { get; set; }

}


public class CrewNamesNameTypeDto
{
    public System.String? Description { get; set; }
    public System.String? Name { get; set; }
    public CrewNamesNameTypeNameTypeAuthorityDto? NameTypeAuthority { get; set; }

}


public class CrewNamesNameTypeNameTypeAuthorityDto
{
    public System.String? Description { get; set; }
    public System.String? Name { get; set; }

}


public class WorkAssetDto
{
    public System.String? UsageKind { get; set; }

}


public class WorkTaskNamesDto
{
    public System.String? Name { get; set; }

}


public class AssetDto
{
    public System.String? MRID { get; set; }
    public System.DateTime? LastModifiedDateTime { get; set; }
    public Boolean? LastModifiedDateTimeSpecified { get; set; }
    public Boolean? Critical { get; set; }
    public System.String? UtcNumber { get; set; }
    public StatusDto? Status { get; set; }
    public System.String? Type { get; set; }
    public WorkLocationDto? Location { get; set; }
    public AssetNamesDto[]? Names { get; set; }

}


public class AssetNamesDto
{
    public System.String? Name { get; set; }

}


public class MaintenanceOrdersResponseMessageTypeDto
{
    public HeaderType1Dto? Header { get; set; }
    public System.String? CorrelationId { get; set; }
    public DetailedFaultResponseTypeDto[]? Payload { get; set; }

}


public class HeaderType1Dto
{
    //public HeaderTypeVerb1Dto? Verb { get; set; }
    //public HeaderTypeSourceDto? Source { get; set; }

    public System.String? Verb { get; set; }
    public System.String? Source { get; set; }

    public System.String? Operation { get; set; }
    public System.String? MessageId { get; set; }
    public System.DateTime? PublishedDateTime { get; set; }

}


public class HeaderTypeVerb1Dto
{
    public Int32? Value__ { get; set; }

}


public class HeaderTypeSourceDto
{
    public Int32? Value__ { get; set; }

}


public class DetailedFaultResponseTypeDto
{
    public System.String? mRID { get; set; }
    public Boolean? Success { get; set; }
    public StandardFaultDto[]? StandardFault { get; set; }

}


public class StandardFaultDto
{
    public EventLog1Dto? EventLog { get; set; }

}


public class EventLog1Dto
{
    public System.String? DetailedMessageText { get; set; }
    public System.String? MessageText { get; set; }
    public System.String? ResultCode { get; set; }
    public System.String? Severity { get; set; }
    public System.String? StackTrace { get; set; }

}



