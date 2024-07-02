using El_Catalan_Hospital.DataAccessLayer.Repository.Contract;
using El_Catalan_Hospital.models.Entities;
using Microsoft.EntityFrameworkCore;


namespace El_Catalan_Hospital.DataAccessLayer.Repository
{

    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly DatabaseContext db;

        public AppointmentRepo(DatabaseContext _databaseContext)
        {
            db = _databaseContext;
        }
      
        public async Task<Appointment> AddAsync(Appointment appointment)
        {
            db.Appointment.Add(appointment);
            await db.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment> DeleteAsync(int id)
        {
            var appointment = await db.Appointment.FindAsync(id);
            if (appointment != null)
            {
                db.Appointment.Remove(appointment);
                await db.SaveChangesAsync();
            }
            return appointment;
        }

        public IEnumerable<Appointment> GetAll()
        {
            var appointments = db.Appointment.ToList();
            return appointments;
        }

        public Appointment GetAppointmentByID(int id)
        {
            return db.Appointment .Include(a => a.Doctor).Include(a => a.Patient).FirstOrDefault(a => a.Id == id);
        }

        public async Task<Appointment> UpdateAsync(Appointment appointment, int id)
        {
            var existingAppointment = await db.Appointment.FindAsync(id);
            if (existingAppointment != null)
            {
                existingAppointment.Status = appointment.Status;
                existingAppointment.Appointment_Date = appointment.Appointment_Date;
                existingAppointment.DoctorId = appointment.DoctorId;
                existingAppointment.PatientId = appointment.PatientId;

                await db.SaveChangesAsync();
            }
            return existingAppointment;
        }
    }
}
