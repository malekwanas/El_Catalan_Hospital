using AutoMapper;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.models.Entities;

namespace El_Catalan_Hospital.BLL.MappingProfiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<DoctorRegisterDto, Doctor>()
                .ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.AppUserId))
                .ForMember(dest => dest.Admin_ID, opt => opt.MapFrom(src => src.Admin_ID))
                .ForMember(dest => dest.SpecializationId, opt => opt.MapFrom(src => src.SpecializationId))
                .ReverseMap();

            CreateMap<Doctor, DoctorDto>()
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.AppUser.Email))
               .ForMember(dest => dest.User_National_ID, opt => opt.MapFrom(src => src.AppUser.User_National_ID))
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.AppUser.Gender))
               .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.AppUser.FullName))
               .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.AppUser.City))
               .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.AppUser.BirthDate))
               .ForMember(dest => dest.Building_Number, opt => opt.MapFrom(src => src.AppUser.Building_Number))
               .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.AppUser.Street))
               .ForMember(dest => dest.Doctor_ID, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.SpecializationId, opt => opt.MapFrom(src => src.SpecializationId))
               .ForMember(dest => dest.WorkingSchedules, opt => opt.Ignore()) // Ignored for now
               .ReverseMap();
        }        
    }
}
