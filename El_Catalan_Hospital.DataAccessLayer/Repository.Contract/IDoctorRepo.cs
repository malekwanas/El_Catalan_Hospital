using El_Catalan_Hospital.models.Entities;
namespace El_Catalan_Hospital.DataAccessLayer.Repository.Contract
{
    public interface IDoctorRepo
    {
        //Doctor retrieve and update himself
        Task<Doctor> GetDoctorByIdAsync(int id);
        //bool UpdateDoctor (Doctor dr);

        //Doctor retrieve and delete Appointments
        //IEnumerable<Appointment> GetDoctorAppointments(int id);
        //bool DeleteAppointment(int AppointmentID);

        //Doctor retrieve and update Working Schedule
        //IEnumerable<WorkingSchedule> GetWorkingSchedules();
        //bool UpdateWorkingSchedule (WorkingSchedule ws);
    }
}
    