using El_Catalan_Hospital.models.Entities;
namespace El_Catalan_Hospital.DataAccessLayer.Repository.Contract
{
    public interface IDoctorRepo
    {
        //Doctor retrieve and update himself
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<Doctor> UpdateDoctor(Doctor updatedDoctor, int id);

        //Doctor retrieve and delete Appointments
        Task<IEnumerable<Appointment>> GetDoctorAppointmentsAsync(int doctorId);
        Task<IEnumerable<Appointment>> GetDoctorFutureAppointmentsAsync(int doctorId);
        Task<Appointment> GetAppointmentByIdAsync(int appointmentId);
        Task<bool> CancelAppointmentAsync(int appointmentId);

        //Doctor CRUD Working Schedule
        IEnumerable<WorkingSchedule> GetWorkingSchedules(int DoctorID);
        WorkingSchedule GetWorkingScheduleById(int WorkingScheduleID);
        Task<WorkingSchedule> DeleteWorkingScheduleAsync(int id);
        Task<bool> IsDuplicateOrOverlappingWorkingScheduleAsync(WorkingSchedule ws, int drID);
        Task<WorkingSchedule> AddWorkingScheduleAsync(WorkingSchedule ws, int drID);
     }
}
    