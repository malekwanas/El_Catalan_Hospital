using El_Catalan_Hospital.DataAccessLayer.Repository.Contract;
using El_Catalan_Hospital.models.Entities;
using Microsoft.EntityFrameworkCore;


namespace El_Catalan_Hospital.DataAccessLayer.Repository
{
    public class ReceptionistRepo : IReceptionistRepo
    {
        private readonly DatabaseContext db;
        public ReceptionistRepo(DatabaseContext _context)
        {
                db= _context;
        }
        void IReceptionistRepo.AddAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }
        //--------------------------------------
        public async Task<Receptionist> GetReceptionistByIdAsync(int id)
        {
            return await db.Receptionist.Include(d => d.AppUser).SingleOrDefaultAsync(d => d.Id == id);
        }
        //--------------------------------------
        public async Task<Receptionist> UpdateReceptionist(Receptionist updatedReceptionist, int id)
        {
            Receptionist existingReceptionist = db.Receptionist.Include(a => a.AppUser).FirstOrDefault(a => a.Id == id);
            if (existingReceptionist == null) { return null; }

            // Update properties here, National ID and Email should NOT be edited
            //existingReceptionist.AppUser.User_National_ID = updatedReceptionist.AppUser.User_National_ID;
            //existingReceptionist.AppUser.Email = updatedReceptionist.AppUser.Email;
            existingReceptionist.AppUser.Gender = updatedReceptionist.AppUser.Gender;
            existingReceptionist.AppUser.City = updatedReceptionist.AppUser.City;
            existingReceptionist.AppUser.Street = updatedReceptionist.AppUser.Street;
            existingReceptionist.AppUser.Building_Number = updatedReceptionist.AppUser.Building_Number;
            existingReceptionist.AppUser.BirthDate = updatedReceptionist.AppUser.BirthDate;
            existingReceptionist.AppUser.PhoneNumber = updatedReceptionist.AppUser.PhoneNumber;
            existingReceptionist.AppUser.FullName = updatedReceptionist.AppUser.FullName;
            existingReceptionist.Admin_ID = updatedReceptionist.Admin_ID;

            db.Receptionist.Update(existingReceptionist);
            db.SaveChanges();

            return existingReceptionist;
        }
        //--------------------------------------
        IEnumerable<Patient> IReceptionistRepo.GetAllPatients()
        {
            var patinets=db.Patient.Include(a => a.AppUser).ToList();
            return patinets;
        }

        void IReceptionistRepo.RegisterPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        void IReceptionistRepo.RemoveAppointment(int Id)
        {
            throw new NotImplementedException();
        }

        void IReceptionistRepo.UpdatePatient(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
