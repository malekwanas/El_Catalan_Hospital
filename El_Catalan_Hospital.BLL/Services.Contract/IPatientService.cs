using El_Catalan_Hospital.BLL.DTO;

namespace El_Catalan_Hospital.BLL.Services.Contract
{
    public interface IPatientService
    {
        Task<PatientDTO> AddAsync(PatientDTO patientDTO);
        Task<PatientDTO> DeleteAsync(int id);
        IEnumerable<PatientDTO> GetAll();
        PatientDTO DisplayPatientProfile(int id);
        Task<PatientDTO> UpdateAsync(PatientDTO patientDTO, int id);
        IEnumerable<DoctorDto> GetAllDoctorsBySpec(int spec_id);
        IEnumerable<DoctorDto> GetDoctorsByFullName(string fullName);
        Task<(bool isSuccess, AppointmentDTO appointment, string error)> MakeAnAppointmentAsync(CreateAppointmentDTO appointmentDTO, int patientId);
        Task<IEnumerable<AppointmentDTO>> GetPatientFutureAppointmentsAsync(int patientId);
    }
}
