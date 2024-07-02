using AutoMapper;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.models.Entities;

namespace El_Catalan_Hospital.BLL.MappingProfiles
{
    public class CreateAppointmentProfile : Profile
    {
        public CreateAppointmentProfile()
        {
            CreateMap<CreateAppointmentDTO, Appointment>()
                .ForMember(dest => dest.Status, opt => opt.Ignore()) // Status is set in the service method
                .ForMember(dest => dest.PatientId, opt => opt.Ignore()); // PatientId is set in the service method
        }
    }
}
