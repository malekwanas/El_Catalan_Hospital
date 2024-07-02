using El_Catalan_Hospital.models.Entities;

namespace El_Catalan_Hospital.DataAccessLayer.Repository.Contract
{
    public interface IPatientRepo
    {
        Task<Patient> AddAsync(Patient patient);
        Task<Patient> DeleteAsync(int id);
        IEnumerable<Patient> GetAll();
        Patient GetPatientByID(int id);
        Task<Patient> UpdateAsync(Patient patient, int id);
        IEnumerable<Doctor> GetAllDoctorsBySpecialization(int id);
        Patient GetPatientByUserId(string userId);
        IEnumerable<Doctor> GetDoctorByName(string name);
        IEnumerable<WorkingSchedule> GetWorkingSchedulesForDoctors(IEnumerable<int> doctorIds);
        Task<Appointment> MakeAnAppointment(Appointment appointment);
        Task<bool> IsDoctorAvailable(int doctorId, DateTime appointmentDate);
        Task<bool> IsTimeSlotBooked(int doctorId, DateTime appointmentDate);
        Task<bool> IsPatientAvailable(int patientId, DateTime appointmentDate);
        Task<IEnumerable<Appointment>> GetPatientFutureAppointmentsAsync(int patientId);
    }
}
