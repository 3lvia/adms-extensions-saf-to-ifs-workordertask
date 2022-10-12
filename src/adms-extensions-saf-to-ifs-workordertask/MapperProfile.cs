using System.Linq;

using AutoMapper;

using MaintenanceOrdersOutBound;
using Model;

namespace SafToSesamAPI
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {        
            CreateMaintenanceOrdersMapping(); 
        }


      
        private void CreateMaintenanceOrdersMapping()
        {
            CreateMap<MaintenanceOrdersInBound.MaintenanceOrdersEventMessageType, IFSWorkOrderBody>()
                .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Header.MessageID));
               

            //CreateMap<MaintenanceOrders.Envelope, EnvelopeDto>();
            //CreateMap<MaintenanceOrders.EnvelopeBody, EnvelopeBodyDto>();
            //CreateMap<MaintenanceOrders.MaintenanceOrdersEventMessageType, MaintenanceOrdersEventMessageTypeDto>();

            //CreateMap<MaintenanceOrders.Envelope, EnvelopeDto>();
            //CreateMap<MaintenanceOrders.EnvelopeBody, EnvelopeBodyDto>();
            //CreateMap<MaintenanceOrders.MaintenanceOrdersEventMessageType, MaintenanceOrdersEventMessageTypeDto>();


            //CreateMap<MaintenanceOrders.HeaderType, HeaderTypeDto>();


            ////CreateMap<MaintenanceOrders.HeaderTypeVerb, HeaderTypeVerbDto>();
            //CreateMap<MaintenanceOrders.ReplayDetectionType, ReplayDetectionTypeDto>();
            //CreateMap<MaintenanceOrders.UserType, UserTypeDto>();
            //CreateMap<MaintenanceOrders.MessageProperty, MessagePropertyDto>();
            //CreateMap<MaintenanceOrders.MaintenanceOrdersType, MaintenanceOrdersTypeDto>();
            //CreateMap<MaintenanceOrders.MaintenanceOrdersTypeMaintenanceOrders, MaintenanceOrdersTypeMaintenanceOrdersDto>();
            //CreateMap<MaintenanceOrders.Organisation, OrganisationDto>();
            //CreateMap<MaintenanceOrders.Work, WorkDto>();
            //CreateMap<MaintenanceOrders.WorkNames, WorkNamesDto>();
            //CreateMap<MaintenanceOrders.WorkPriority, WorkPriorityDto>();
            //CreateMap<MaintenanceOrders.Equipment, EquipmentDto>();
            //CreateMap<MaintenanceOrders.EquipmentNames, EquipmentNamesDto>();
            //CreateMap<MaintenanceOrders.WorkTimeSchedule, WorkTimeScheduleDto>();
            //CreateMap<MaintenanceOrders.WorkTimeScheduleScheduleInterval, WorkTimeScheduleScheduleIntervalDto>();
            //CreateMap<MaintenanceOrders.WorkLocation, WorkLocationDto>();
            //CreateMap<MaintenanceOrders.WorkLocationCoordinateSystem, WorkLocationCoordinateSystemDto>();
            //CreateMap<MaintenanceOrders.WorkLocationPositionPoints, WorkLocationPositionPointsDto>();
            //CreateMap<MaintenanceOrders.WorkTask, WorkTaskDto>();
            ////CreateMap<MaintenanceOrders.CrewType, CrewTypeDto>();
            ////CreateMap<MaintenanceOrders.DeviceType, DeviceTypeDto>();
            //CreateMap<MaintenanceOrders.Crew, CrewDto>();
            //CreateMap<MaintenanceOrders.Status, StatusDto>();
            //CreateMap<MaintenanceOrders.CrewMember, CrewMemberDto>();
            //CreateMap<MaintenanceOrders.CrewMemberPerson, CrewMemberPersonDto>();
            //CreateMap<MaintenanceOrders.TelephoneNumber, TelephoneNumberDto>();
            //CreateMap<MaintenanceOrders.ElectronicAddress, ElectronicAddressDto>();
            //CreateMap<MaintenanceOrders.CrewNames, CrewNamesDto>();
            //CreateMap<MaintenanceOrders.CrewNamesNameType, CrewNamesNameTypeDto>();
            //CreateMap<MaintenanceOrders.CrewNamesNameTypeNameTypeAuthority, CrewNamesNameTypeNameTypeAuthorityDto>();
            //CreateMap<MaintenanceOrders.WorkAsset, WorkAssetDto>();
            //CreateMap<MaintenanceOrders.WorkTaskNames, WorkTaskNamesDto>();
            //CreateMap<MaintenanceOrders.Asset, AssetDto>();
            //CreateMap<MaintenanceOrders.AssetNames, AssetNamesDto>();
            //CreateMap<MaintenanceOrders.MaintenanceOrdersResponseMessageType, MaintenanceOrdersResponseMessageTypeDto>();
            //CreateMap<MaintenanceOrders.HeaderType1, HeaderType1Dto>();
            ////CreateMap<MaintenanceOrders.HeaderTypeVerb1, HeaderTypeVerb1Dto>();
            ////CreateMap<MaintenanceOrders.HeaderTypeSource, HeaderTypeSourceDto>();
            //CreateMap<MaintenanceOrders.DetailedFaultResponseType, DetailedFaultResponseTypeDto>();
            //CreateMap<MaintenanceOrders.StandardFault, SesamResponseServices.SesamDomainObjects.StandardFaultDto>();
            //CreateMap<MaintenanceOrders.EventLog1, EventLog1Dto>();



        }

     



   
    
    }

}
