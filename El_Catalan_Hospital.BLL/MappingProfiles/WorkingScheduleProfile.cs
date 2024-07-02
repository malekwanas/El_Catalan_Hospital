using AutoMapper;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.models.Entities;

namespace El_Catalan_Hospital.BLL.MappingProfiles
{
    public class WorkingScheduleProfile : Profile
    {
        public WorkingScheduleProfile() 
        {
            CreateMap<WorkingSchedule, WorkingScheduleDTO>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Working_Schedule_Start_Time, opt => opt.MapFrom(src => src.Working_Schedule_Start_Time.ToString()))
               .ForMember(dest => dest.Working_Schedule_End_Time, opt => opt.MapFrom(src => src.Working_Schedule_End_Time.ToString()))
               .ForMember(dest => dest.Working_Schedule_Day, opt => opt.MapFrom(src => src.Working_Schedule_Day))
               .ForMember(dest => dest.Doctor_ID, opt => opt.MapFrom(src => src.Doctor_ID))
               .ReverseMap();

        }
    }
}
