using El_Catalan_Hospital.DataAccessLayer.Repository.Contract;
using El_Catalan_Hospital.models.Entities;
using Microsoft.EntityFrameworkCore;

namespace El_Catalan_Hospital.DataAccessLayer.Repository
{
    public class PatientRepo:IPatientRepo
    {
        private readonly DatabaseContext db;
        public PatientRepo(DatabaseContext _databaseContext)
        {
            db = _databaseContext;

        }
        //-----------------------------------------------------
        public async Task<Patient> AddAsync(Patient patient)
        {
            await db.Patient.AddAsync(patient);
            await db.SaveChangesAsync();
            return patient;
        }
        //-----------------------------------------------------
        public async Task<Patient> DeleteAsync(int id)
        {
            var patient = await db.Patient.FindAsync(id);
            if (patient != null)
            {
                db.Patient.Remove(patient);
                await db.SaveChangesAsync();
            }
            return patient;
        }
        //-----------------------------------------------------
        public IEnumerable<Patient> GetAll()
        {
            return db.Patient.Include(p => p.AppUser).ToList();
        }
        //-----------------------------------------------------
        public Patient GetPatientByID(int id)
        {
            return db.Patient.Include(p => p.AppUser).FirstOrDefault(p => p.Id == id);
        }
        //-----------------------------------------------------
        public async Task<Patient> UpdateAsync(Patient patient, int id)
        {
            var existingPatient = db.Patient.Include(a => a.AppUser).FirstOrDefault(a => a.Id == id);

            if (existingPatient != null)
            {
                // Update properties here, National ID and Email should NOT be edited
                //existingPatient.AppUser.User_National_ID = patient.AppUser.User_National_ID;
                //existingPatient.AppUser.Email = patient.AppUser.Email;
                existingPatient.AppUser.Gender = patient.AppUser.Gender;
                existingPatient.AppUser.City = patient.AppUser.City;
                existingPatient.AppUser.Street = patient.AppUser.Street;
                existingPatient.AppUser.Building_Number = patient.AppUser.Building_Number;
                existingPatient.AppUser.BirthDate = patient.AppUser.BirthDate;
                existingPatient.AppUser.PhoneNumber = patient.AppUser.PhoneNumber;
                existingPatient.AppUser.FullName = patient.AppUser.FullName;

                await db.SaveChangesAsync();
            }
            return existingPatient;
        }
        //-----------------------------------------------------
        public IEnumerable<Doctor> GetAllDoctorsBySpecialization(int id)
        {
            var doctors = db.Doctor.Where(s => s.SpecializationId == id).Include(a => a.AppUser).ToList();
            return doctors;
        }
        //-----------------------------------------------------
        public Patient GetPatientByUserId(string userId)
        {
            var patient = db.Patient.Include(a => a.AppUser).FirstOrDefault(a => a.AppUserId == userId);
            if (patient == null) { return null; }

            return patient;
        }
        //-----------------------------------------------------
        public IEnumerable<Doctor> GetDoctorByName(string name)
        {
            var doctors = db.Doctor
                .Include(d => d.AppUser)
                .Where(d => d.AppUser.FullName.Contains(name))
                .ToList();

            return doctors;
        }
        //-----------------------------------------------------
        public IEnumerable<WorkingSchedule> GetWorkingSchedulesForDoctors(IEnumerable<int> doctorIds)
        {
            var workingSchedules = db.WorkingSchedule
                .Where(ws => doctorIds.Contains(ws.Doctor_ID))
                .ToList();

            return workingSchedules;
        }
        //-----------------------------------------------------
        public async Task<bool> IsDoctorAvailable(int doctorId, DateTime appointmentDate)
        {
            var dayOfWeek = appointmentDate.DayOfWeek;
            var time = TimeOnly.FromDateTime(appointmentDate);
            var workingSchedule = await db.WorkingSchedule
                .Where(ws => ws.Doctor_ID == doctorId && ws.Working_Schedule_Day == dayOfWeek)
                .FirstOrDefaultAsync(ws => ws.Working_Schedule_Start_Time <= time && ws.Working_Schedule_End_Time >= time);
            return workingSchedule != null;
        }
        //-----------------------------------------------------
        public async Task<bool> IsTimeSlotBooked(int doctorId, DateTime appointmentDate)
        {
            var appointmentExists = await db.Appointment
                .AnyAsync(a => a.DoctorId == doctorId && a.Appointment_Date == appointmentDate);
            return appointmentExists;
        }
        //-----------------------------------------------------
        public async Task<bool> IsPatientAvailable(int patientId, DateTime appointmentDate)
        {
            var appointmentExists = await db.Appointment
                .AnyAsync(a => a.PatientId == patientId && a.Appointment_Date == appointmentDate);
            return appointmentExists;
        }
        //-----------------------------------------------------
        public async Task<Appointment> MakeAnAppointment(Appointment appointment)
        {
            appointment.Status = Status.Pending;
            db.Appointment.Add(appointment);
            await db.SaveChangesAsync();
            return appointment;
        }
        //-----------------------------------------------------
        public async Task<IEnumerable<Appointment>> GetPatientFutureAppointmentsAsync(int patientId)
        {
           return await db.Appointment.Include(a => a.Doctor).ThenInclude(d => d.AppUser).Include(a => a.Patient).ThenInclude(p => p.AppUser)
                .Where(a => a.PatientId == patientId && a.Status == Status.Pending && a.Appointment_Date > DateTime.Now).ToListAsync();
        }
        //-----------------------------------------------------
    }
}
