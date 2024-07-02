using AutoMapper;
using El_Catalan_Hospital.API.Dtos;
using El_Catalan_Hospital.models.Entities;
using El_Catalan_Hospital.models.Entities.Identity;

namespace El_Catalan_Hospital.BLL.MappingProfiles
{
    public class AccountProfile :Profile
    {
        public AccountProfile()
        {
            CreateMap<AppUser, RegisterDto>()
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
               .ReverseMap();
        }
    }
}
