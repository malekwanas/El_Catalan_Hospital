using El_Catalan_Hospital.BLL.DTO;

namespace El_Catalan_Hospital.BLL.Services.Contract
{
    public interface IDoctorService
    {
        Task<DoctorDto> DisplayDoctorProfileAsync(int id);
        Task<DoctorDto> UpdateDoctorInformation(DoctorDto doctorDTO, int id);
        Task<IEnumerable<AppointmentDTO>> GetDoctorAppointmentsAsync(int doctorId);
        Task<IEnumerable<AppointmentDTO>> GetDoctorFutureAppointmentsAsync(int doctorId);
        Task<bool> CancelAppointmentAsync(int appointmentId);
        IEnumerable<WorkingScheduleDTO> GetWorkingSchedule(int id);
        Task<WorkingScheduleDTO> DeleteWorkScheduleAsync(int id);
        Task<(bool isSuccess, WorkingScheduleDTO addedSchedule, string error)> AddWorkingScheduleAsync(WorkingScheduleDTO workScheduleDTO, int drID);
    }
}
