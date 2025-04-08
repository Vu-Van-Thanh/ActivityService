
using ActivityService.Core.Domain.Entities;
using ActivityService.Core.DTO;
using AutoMapper;


namespace ActivityService.Core.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ActivityFld, ActivityFldDTO>();
            CreateMap<ActivityFldDTO, ActivityFld>();
            CreateMap<Activity, ActivityDTO>();
            CreateMap<ActivityDTO, Activity>();
            CreateMap<ActivityRequest, ActivityRequestDTO>();
            CreateMap<ActivityRequestDTO, ActivityRequest>();
            CreateMap<Attendance, AttendanceDTO>();
            CreateMap<AttendanceDTO, Attendance>();

        }
    }
}
