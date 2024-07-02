using AutoMapper;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.BLL.MappingProfiles
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<Patient, PatientRegisterDto>()
                .ForMember(destination => destination.AppUserId, opt => opt.MapFrom(src => src.AppUserId))
                .ForMember(destination => destination.ReceptionistID, opt => opt.MapFrom(src => src.ReceptionistID));

              CreateMap<PatientRegisterDto, Patient>().ForMember(destination => destination.AppUserId, opt => opt.MapFrom(src => src.AppUserId))
                 .ForMember(destination => destination.ReceptionistID, opt => opt.MapFrom(src => src.ReceptionistID));
        }
    }
}
