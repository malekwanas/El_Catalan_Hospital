using AutoMapper;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.models.Entities;

namespace El_Catalan_Hospital.BLL.MappingProfiles
{
    public class PatientProfile:Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientDTO>()
               .ForMember(destination => destination.Email, opt => opt.MapFrom(src => src.AppUser.Email))
               .ForMember(destination => destination.User_National_ID, opt => opt.MapFrom(src => src.AppUser.User_National_ID))
               .ForMember(destination => destination.Gender, opt => opt.MapFrom(src => src.AppUser.Gender))
               .ForMember(destination => destination.FullName, opt => opt.MapFrom(src => src.AppUser.FullName))
               .ForMember(destination => destination.City, opt => opt.MapFrom(src => src.AppUser.City))
               .ForMember(destination => destination.BirthDate, opt => opt.MapFrom(src => src.AppUser.BirthDate))
               .ForMember(destination => destination.Building_Number, opt => opt.MapFrom(src => src.AppUser.Building_Number))
               .ForMember(destination => destination.Street, opt => opt.MapFrom(src => src.AppUser.Street))
               .ForMember(destination => destination.ReceptionistID, opt => opt.MapFrom(src => src.ReceptionistID))
               .ForMember(destination => destination.Patient_ID, opt => opt.MapFrom(src => src.Id))
               .ForMember(destination => destination.Phone, opt => opt.MapFrom(src => src.AppUser.PhoneNumber))
               .ReverseMap();
        }


    }
}

