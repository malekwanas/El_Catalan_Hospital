using El_Catalan_Hospital.DataAccessLayer.Repository.Contract;
using El_Catalan_Hospital.models.Entities;
using Microsoft.EntityFrameworkCore;

namespace El_Catalan_Hospital.DataAccessLayer.Repository
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly DatabaseContext db;

        public DoctorRepo(DatabaseContext context)
        {
            db = context;
        }
        //--------------------------------------
        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await db.Doctor.Include(d => d.AppUser).SingleOrDefaultAsync(d => d.Id == id);
        }
        //--------------------------------------
        public async Task<Doctor> UpdateDoctor(Doctor updatedDoctor, int id)
        {
            Doctor existingDoctor = db.Doctor.Include(a => a.AppUser).FirstOrDefault(a => a.Id == id);
            if (existingDoctor == null) { return null; }

            // Update properties here, National ID and Email should NOT be edited
            //existingDoctor.AppUser.User_National_ID = updatedDoctor.AppUser.User_National_ID;
            //existingDoctor.AppUser.Email = updatedDoctor.AppUser.Email;
            existingDoctor.AppUser.Gender = updatedDoctor.AppUser.Gender;
            existingDoctor.AppUser.City = updatedDoctor.AppUser.City;
            existingDoctor.AppUser.Street = updatedDoctor.AppUser.Street;
            existingDoctor.AppUser.Building_Number = updatedDoctor.AppUser.Building_Number;
            existingDoctor.AppUser.BirthDate = updatedDoctor.AppUser.BirthDate;
            existingDoctor.AppUser.PhoneNumber = updatedDoctor.AppUser.PhoneNumber;
            existingDoctor.AppUser.FullName = updatedDoctor.AppUser.FullName;
            existingDoctor.SpecializationId = updatedDoctor.SpecializationId;

            db.Doctor.Update(existingDoctor);
            db.SaveChanges();

            return existingDoctor;
        }
        //--------------------------------------
        public async Task<IEnumerable<Appointment>> GetDoctorAppointmentsAsync(int doctorId)
        {
            return await db.Appointment.Include(a => a.Doctor).ThenInclude(d => d.AppUser).Include(a => a.Patient).ThenInclude(p => p.AppUser)
            .Where(a => a.DoctorId == doctorId).ToListAsync();
        }
        //--------------------------------------
        public async Task<IEnumerable<Appointment>> GetDoctorFutureAppointmentsAsync(int doctorId)
        {
           return await db.Appointment.Include(a => a.Doctor).ThenInclude(d => d.AppUser).Include(a => a.Patient).ThenInclude(p => p.AppUser)
          .Where(a => a.DoctorId == doctorId && a.Status == Status.Pending && a.Appointment_Date > DateTime.Now).ToListAsync();
        }
        //--------------------------------------
        public async Task<Appointment> GetAppointmentByIdAsync(int appointmentId)
        {
            return await db.Appointment.SingleOrDefaultAsync(a => a.Id == appointmentId);
        }
        //--------------------------------------
        public async Task<bool> CancelAppointmentAsync(int appointmentId)
        {
            var appointment = await db.Appointment.FindAsync(appointmentId);
            if (appointment != null && appointment.Status == Status.Pending && appointment.Appointment_Date > DateTime.UtcNow)
            {
                appointment.Status = Status.Canceled;
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
        //--------------------------------------
        public IEnumerable<WorkingSchedule> GetWorkingSchedules(int DoctorID)
        {
            return db.WorkingSchedule.Where(w=>w.Doctor_ID == DoctorID).ToList();
        }
        //--------------------------------------
        public WorkingSchedule GetWorkingScheduleById(int WorkingScheduleID)
        {
            return db.WorkingSchedule.SingleOrDefault(w => w.Id == WorkingScheduleID);
        }
        //--------------------------------------
        public async Task<WorkingSchedule> DeleteWorkingScheduleAsync(int id)
        {
            var workingSchedule = await db.WorkingSchedule.FindAsync(id);
            if (workingSchedule != null)
            {
                db.WorkingSchedule.Remove(workingSchedule);
                await db.SaveChangesAsync();
            }
            return workingSchedule;
        }
        //--------------------------------------
        public async Task<bool> IsDuplicateOrOverlappingWorkingScheduleAsync(WorkingSchedule ws, int drID)
        {
            return await db.WorkingSchedule
                .AnyAsync(w => w.Doctor_ID == drID
                    && w.Working_Schedule_Day == ws.Working_Schedule_Day
                    && ((w.Working_Schedule_Start_Time < ws.Working_Schedule_End_Time && w.Working_Schedule_End_Time > ws.Working_Schedule_Start_Time)
                        || (w.Working_Schedule_Start_Time == ws.Working_Schedule_Start_Time && w.Working_Schedule_End_Time == ws.Working_Schedule_End_Time)));
        }

        //--------------------------------------
        public async Task<WorkingSchedule> AddWorkingScheduleAsync(WorkingSchedule ws, int drID)
        {
            ws.Doctor_ID = drID;
            db.WorkingSchedule.Add(ws);
            await db.SaveChangesAsync();
            return ws;
        }
        //--------------------------------------
    }
}
