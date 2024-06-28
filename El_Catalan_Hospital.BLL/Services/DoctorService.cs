using AutoMapper;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.BLL.Services.Contract;
using El_Catalan_Hospital.DataAccessLayer.Repository.Contract;

namespace El_Catalan_Hospital.BLL.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo doctorRepo;
        private readonly IMapper mapper;

        public DoctorService(IDoctorRepo _doctorRepo, IMapper _mapper)
        {
            doctorRepo = _doctorRepo;
            mapper = _mapper;
        }

        //-------------------------------------------------------------
        public async Task<DoctorDto> DisplayDoctorProfileAsync(int id)
        {
            var dr = await doctorRepo.GetDoctorByIdAsync(id);
            if (dr == null) { return null; }

            var drDTO = mapper.Map<DoctorDto>(dr);
            return drDTO;
        }
        //-------------------------------------------------------------
    }
}
