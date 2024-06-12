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
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Admin, AdminDTO>()
                    .ForMember(destination => destination.Email, opt => opt.MapFrom(src => src.AppUser.Email))
                    .ForMember(destination => destination.City, opt => opt.MapFrom(src => src.AppUser.City))
                    .ForMember(destination => destination.BirthDate, opt => opt.MapFrom(src => src.AppUser.BirthDate))
                    .ForMember(destination => destination.Building_Number, opt => opt.MapFrom(src => src.AppUser.Building_Number))
                    .ForMember(destination => destination.Street, opt => opt.MapFrom(src => src.AppUser.Street))
                    .ForMember(destination => destination.Phone, opt => opt.MapFrom(src => src.AppUser.Phone));
        }
    }
}
