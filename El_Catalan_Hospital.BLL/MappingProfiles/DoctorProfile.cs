using AutoMapper;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.models.Entities;

namespace El_Catalan_Hospital.BLL.MappingProfiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<DoctorRegisterDto, Doctor>().ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.AppUserId))
                .ForMember(dest => dest.Admin_ID, opt => opt.MapFrom(src => src.Admin_ID))
                .ForMember(dest => dest.SpecializationId, opt => opt.MapFrom(src => src.SpecializationId))
                .ReverseMap();

            CreateMap<Doctor, DoctorDto>()
               .ForMember(destination => destination.Email, opt => opt.MapFrom(src => src.AppUser.Email))
               .ForMember(destination => destination.User_National_ID, opt => opt.MapFrom(src => src.AppUser.User_National_ID))
               .ForMember(destination => destination.Gender, opt => opt.MapFrom(src => src.AppUser.Gender))
               .ForMember(destination => destination.FullName, opt => opt.MapFrom(src => src.AppUser.FullName))
               .ForMember(destination => destination.City, opt => opt.MapFrom(src => src.AppUser.City))
               .ForMember(destination => destination.BirthDate, opt => opt.MapFrom(src => src.AppUser.BirthDate))
               .ForMember(destination => destination.Building_Number, opt => opt.MapFrom(src => src.AppUser.Building_Number))
               .ForMember(destination => destination.Street, opt => opt.MapFrom(src => src.AppUser.Street))
               .ForMember(destination => destination.Doctor_ID, opt => opt.MapFrom(src => src.Id))
               .ReverseMap();
        }        
    }
}
