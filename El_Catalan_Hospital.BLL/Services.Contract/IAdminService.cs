using El_Catalan_Hospital.API.Dtos;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.BLL.Responses;

namespace El_Catalan_Hospital.BLL.Services.Contract
{
    public interface IAdminService
    {
        //Logged in Admin profile
        Task<AdminDto> DisplayAdminProfileAsync(int id);

        //Admin Services
        IEnumerable<AdminDto> GetAllAdmins();
        AdminDto GetSpecificAdmin(int id);
        AdminDto GetAdminByUserId(string userId);
        AdminDto UpdateAdminInformation(AdminDto adminDTO, int id);
        AdminDto DeleteAdminById(int id);
        Task<AdminDto> AddAsynchronous(AdminDto adnDTO);

        //Doctor Services
        IEnumerable<DoctorDto> GetAllDoctors();
        IEnumerable<DoctorDto> GetAllDoctorsBySpec(int spec_id);
        DoctorDto GetSpecificDoctor(int id);
        DoctorDto UpdateDoctorInformation(DoctorDto doctorDTO, int id);
        DoctorDto DeleteDoctorById(int id);
        DoctorDto GetDoctorByUserId(string userId);

        //Receptionist Services
        IEnumerable<ReceptionistDto> GetAllReceptionists();
        ReceptionistDto GetSpecificReceptionist(int id);
        ReceptionistDto UpdateReceptionistInformation(ReceptionistDto receptionistDTO, int id);
        ReceptionistDto DeleteReceptionistById(int id);
        ReceptionistDto GetReceptionistByUserId(string userId);

        //Specialization Services
        IEnumerable<SpecializationDTO> GetAllSpecializations();
        SpecializationDTO UpdateSpecializationInformation(SpecializationDTO specializationDTO, int id);
        SpecializationDTO AddSpecialization(SpecializationDTO specializationDTO);
        SpecializationDTO DeleteSpecializationById(int id);


        //Register Admin
        Task<Response> RegisterAdminAsync(RegisterDto model);

        //Register Receptionist
        Task<Response> RegisterReceptionistAsync(RegisterDto model, int AdminId);

        //Register Doctor
        Task<Response> RegisterDoctorAsync(RegisterDto model, int AdminId, int specializationId);

    }
}
