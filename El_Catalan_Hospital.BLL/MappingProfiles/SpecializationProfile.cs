using AutoMapper;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.models.Entities;

namespace El_Catalan_Hospital.BLL.MappingProfiles
{
    public class SpecializationProfile : Profile
    {
        public SpecializationProfile()
        {
            CreateMap<Specialization, SpecializationDTO>()
                .ForMember(destination => destination.Specialization_ID, opt => opt.MapFrom(src => src.Id))
                .ForMember(destination => destination.Specialization_Name, opt => opt.MapFrom(src => src.Specialization_Name))
                .ForMember(destination => destination.Specialization_Description, opt => opt.MapFrom(src => src.Specialization_Description))
                .ReverseMap();
        }
    }
}
