using AutoMapper;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.BLL.Services.Contract;
using El_Catalan_Hospital.DataAccessLayer.Repository.Contract;
using El_Catalan_Hospital.models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepo adminRepo;
        private readonly IMapper _mapper;
        public AdminService(IAdminRepo _adminRepo, IMapper mapper) 
        {
            adminRepo = _adminRepo;
            _mapper = mapper;
        }

        public IEnumerable<AdminDTO> GetAllAdmins()
        {
            var admins= adminRepo.GetAll();
            var adminDTOList = _mapper.Map<IEnumerable<AdminDTO>>(admins);
            return adminDTOList;
        }
    }
}
