using El_Catalan_Hospital.BLL.DTO;

namespace El_Catalan_Hospital.BLL.Services.Contract
{
    public interface IDoctorService
    {
        Task<DoctorDto> DisplayDoctorProfileAsync(int id);
    }
}
