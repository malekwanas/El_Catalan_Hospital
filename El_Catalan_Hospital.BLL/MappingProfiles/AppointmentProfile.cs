using AutoMapper;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.models.Entities;

namespace El_Catalan_Hospital.BLL.MappingProfiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, AppointmentDTO>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.AppUser.FullName))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.AppUser.FullName))
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Appointment_Date, opt => opt.MapFrom(src => src.Appointment_Date))
                .ReverseMap();
        }
    }
}
