using AutoMapper;
using El_Catalan_Hospital.API.Dtos;
using El_Catalan_Hospital.models.Entities.Identity;

namespace El_Catalan_Hospital.API.Helpers
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {

            CreateMap<AppUser, UserDto>();
            CreateMap<AppUser, UserToReturnDto>();
        }
    }
}
