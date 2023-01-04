using AutoMapper;
using MaintenanceOrdersInBoundDomain;
using Model;

namespace SafToSesamAPI
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {        
            CreateMaintenanceOrdersInBoundMapping();
            CreateMaintenanceOrdersOutBoundMapping();
        }


        private void CreateMaintenanceOrdersOutBoundMapping()
        {

            CreateMap<MaintenanceOrdersOutBoundDomain.IFSMaintenanceOrdersInputDto, MaintenanceOrdersOutBound.IFSMaintenanceOrdersInput>();
            CreateMap<MaintenanceOrdersOutBoundDomain.IFSMaintenanceOrdersMessageTypeDto, MaintenanceOrdersOutBound.IFSMaintenanceOrdersMessageType>();
            CreateMap<MaintenanceOrdersOutBoundDomain.HeaderTypeDto, MaintenanceOrdersOutBound.HeaderType>();
            //CreateMap<MaintenanceOrdersOutBoundDomain.HeaderTypeVerbDto, MaintenanceOrdersOutBound.HeaderTypeVerb>();
            CreateMap<MaintenanceOrdersOutBoundDomain.ReplayDetectionTypeDto, MaintenanceOrdersOutBound.ReplayDetectionType>();
            CreateMap<MaintenanceOrdersOutBoundDomain.UserTypeDto, MaintenanceOrdersOutBound.UserType>();
            CreateMap<MaintenanceOrdersOutBoundDomain.MessagePropertyDto, MaintenanceOrdersOutBound.MessageProperty>();
            CreateMap<MaintenanceOrdersOutBoundDomain.IFSMaintenanceOrdersMessageType1Dto, MaintenanceOrdersOutBound.IFSMaintenanceOrdersMessageType1>();
            CreateMap<MaintenanceOrdersOutBoundDomain.WorkDto, MaintenanceOrdersOutBound.Work>();
            CreateMap<MaintenanceOrdersOutBoundDomain.WorkTaskDto, MaintenanceOrdersOutBound.WorkTask>();

        }



        private void CreateMaintenanceOrdersInBoundMapping()
        {
            CreateMap<MaintenanceOrdersInBound.MaintenanceOrdersEventMessageType, WorkOrderIfsDto>()
                .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Header.MessageID));

            CreateMap<MaintenanceOrdersInBound.MaintenanceOrdersEventMessageType, WorkOrderTaskIfsDto>()
                .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Header.MessageID));



            CreateMap<MaintenanceOrdersInBound.MaintenanceOrdersEventMessageType, MaintenanceOrdersDto>()
           .ForMember(dest => dest._id, opt => opt.MapFrom(src => src.Header.MessageID))
           .ForMember(dest => dest.MessageId, opt => opt.MapFrom(src => src.Header.MessageID))
           .ForMember(dest => dest.PublishedDateTime, opt => opt.MapFrom(src => src.Header.Timestamp));

            //CreateMap<MaintenanceOrders.Envelope, EnvelopeDto>();
            //CreateMap<MaintenanceOrders.EnvelopeBody, EnvelopeBodyDto>();
            //CreateMap<MaintenanceOrders.MaintenanceOrdersEventMessageType, MaintenanceOrdersEventMessageTypeDto>();

            //CreateMap<MaintenanceOrders.Envelope, EnvelopeDto>();
            //CreateMap<MaintenanceOrders.EnvelopeBody, EnvelopeBodyDto>();
            //CreateMap<MaintenanceOrders.MaintenanceOrdersEventMessageType, MaintenanceOrdersEventMessageTypeDto>();


            CreateMap<MaintenanceOrdersInBound.HeaderType, HeaderTypeDto>();


            //CreateMap<MaintenanceOrders.HeaderTypeVerb, HeaderTypeVerbDto>();
            CreateMap<MaintenanceOrdersInBound.ReplayDetectionType, ReplayDetectionTypeDto>();
            CreateMap<MaintenanceOrdersInBound.UserType, UserTypeDto>();
            CreateMap<MaintenanceOrdersInBound.MessageProperty, MessagePropertyDto>();
            CreateMap<MaintenanceOrdersInBound.MaintenanceOrdersType, MaintenanceOrdersTypeDto>();
            CreateMap<MaintenanceOrdersInBound.MaintenanceOrdersTypeMaintenanceOrders, MaintenanceOrdersTypeMaintenanceOrdersDto>();
            CreateMap<MaintenanceOrdersInBound.Organisation, OrganisationDto>();
            CreateMap<MaintenanceOrdersInBound.Work, WorkDto>();
            CreateMap<MaintenanceOrdersInBound.WorkNames, WorkNamesDto>();
            CreateMap<MaintenanceOrdersInBound.WorkPriority, WorkPriorityDto>();
            CreateMap<MaintenanceOrdersInBound.Equipment, EquipmentDto>();
            CreateMap<MaintenanceOrdersInBound.EquipmentNames, EquipmentNamesDto>();
            CreateMap<MaintenanceOrdersInBound.WorkTimeSchedule, WorkTimeScheduleDto>();
            CreateMap<MaintenanceOrdersInBound.WorkTimeScheduleScheduleInterval, WorkTimeScheduleScheduleIntervalDto>();
            CreateMap<MaintenanceOrdersInBound.WorkLocation, WorkLocationDto>();
            CreateMap<MaintenanceOrdersInBound.WorkLocationCoordinateSystem, WorkLocationCoordinateSystemDto>();
            CreateMap<MaintenanceOrdersInBound.WorkLocationPositionPoints, WorkLocationPositionPointsDto>();
            CreateMap<MaintenanceOrdersInBound.WorkTask, WorkTaskDto>();
            //CreateMap<MaintenanceOrders.CrewType, CrewTypeDto>();
            //CreateMap<MaintenanceOrders.DeviceType, DeviceTypeDto>();
            CreateMap<MaintenanceOrdersInBound.Crew, CrewDto>();
            CreateMap<MaintenanceOrdersInBound.Status, StatusDto>();
            CreateMap<MaintenanceOrdersInBound.CrewMember, CrewMemberDto>();
            CreateMap<MaintenanceOrdersInBound.CrewMemberPerson, CrewMemberPersonDto>();
            CreateMap<MaintenanceOrdersInBound.TelephoneNumber, TelephoneNumberDto>();
            CreateMap<MaintenanceOrdersInBound.ElectronicAddress, ElectronicAddressDto>();
            CreateMap<MaintenanceOrdersInBound.CrewNames, CrewNamesDto>();
            CreateMap<MaintenanceOrdersInBound.CrewNamesNameType, CrewNamesNameTypeDto>();
            CreateMap<MaintenanceOrdersInBound.CrewNamesNameTypeNameTypeAuthority, CrewNamesNameTypeNameTypeAuthorityDto>();
            CreateMap<MaintenanceOrdersInBound.WorkAsset, WorkAssetDto>();
            CreateMap<MaintenanceOrdersInBound.WorkTaskNames, WorkTaskNamesDto>();
            CreateMap<MaintenanceOrdersInBound.Asset, AssetDto>();
            CreateMap<MaintenanceOrdersInBound.AssetNames, AssetNamesDto>();
            CreateMap<MaintenanceOrdersInBound.MaintenanceOrdersResponseMessageType, MaintenanceOrdersResponseMessageTypeDto>();
            CreateMap<MaintenanceOrdersInBound.HeaderType1, HeaderType1Dto>();
            //CreateMap<MaintenanceOrders.HeaderTypeVerb1, HeaderTypeVerb1Dto>();
            //CreateMap<MaintenanceOrders.HeaderTypeSource, HeaderTypeSourceDto>();
            CreateMap<MaintenanceOrdersInBound.DetailedFaultResponseType, DetailedFaultResponseTypeDto>();
            CreateMap<MaintenanceOrdersInBound.StandardFault, StandardFaultDto>();
            CreateMap<MaintenanceOrdersInBound.EventLog1, EventLog1Dto>();






        }

     



   
    
    }

}
