using AutoMapper;
using El_Catalan_Hospital.API.Dtos;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.BLL.MappingProfiles
{
    public class ReceptionistProfile : Profile
    {
        public ReceptionistProfile()
        {
            CreateMap<ReceptionistRegisterDto,Receptionist>().ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.AppUserId))
                .ForMember(dest => dest.Admin_ID, opt => opt.MapFrom(src => src.Adminid)).ReverseMap();


            CreateMap<Receptionist, ReceptionistDto>()
               .ForMember(dest => dest.User_National_ID, opt => opt.MapFrom(src => src.AppUser.User_National_ID))
               .ForMember(dest => dest.Admin_ID, opt => opt.MapFrom(src => src.Admin_ID))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.AppUser.Email))
               .ForMember(destination => destination.FullName, opt => opt.MapFrom(src => src.AppUser.FullName))
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.AppUser.Gender))
               .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.AppUser.City))
               .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.AppUser.Street))
               .ForMember(dest => dest.Building_Number, opt => opt.MapFrom(src => src.AppUser.Building_Number))
               .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.AppUser.BirthDate))
               .ForMember(dest => dest.Receptionist_ID, opt => opt.MapFrom(src => src.Id))
               .ReverseMap();

        }
    }
}
