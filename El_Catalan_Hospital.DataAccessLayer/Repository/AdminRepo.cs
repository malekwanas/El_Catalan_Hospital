using El_Catalan_Hospital.DataAccessLayer.Repository.Contract;
using El_Catalan_Hospital.models.Entities;
using Microsoft.EntityFrameworkCore;

namespace El_Catalan_Hospital.DataAccessLayer.Repository
{
    public class AdminRepo : IAdminRepo
    {
        private readonly DatabaseContext db;
        public AdminRepo(DatabaseContext context)
        {
            db = context;
        }
        //----------------------------------------------------------------
        public async Task<Admin> GetAdminByIdAsync(int id)
        {
            return await db.Admin.Include(d => d.AppUser).SingleOrDefaultAsync(a => a.Id == id);
        }
        //-------------------------------------------------------------------ADMINS CRUD-------------------------------------------------------------
        public IEnumerable<Admin> GetAllAdmins()
        {
            var admins = db.Admin.Include(a => a.AppUser).ToList();
            return admins;
        }
        //-----------------------------------------------
        public Admin GetAdminById(int id)
        {
            var Admin = db.Admin.Include(a => a.AppUser).FirstOrDefault(a => a.Id == id);
            if (Admin == null) { return null; }

            return Admin;
        }
        //-----------------------------------------------
        public Admin UpdateAdmin(Admin updatedAdmin, int id)
        {
            Admin existingAdmin = db.Admin.Include(a => a.AppUser).FirstOrDefault(a => a.Id == id);
            if (existingAdmin == null) { return null; }

            // Update properties here, National ID and Email should NOT be edited
            //existingAdmin.AppUser.User_National_ID = updatedAdmin.AppUser.User_National_ID;
            //existingAdmin.AppUser.Email = updatedAdmin.AppUser.Email;
            existingAdmin.AppUser.Gender = updatedAdmin.AppUser.Gender;
            existingAdmin.AppUser.City = updatedAdmin.AppUser.City;
            existingAdmin.AppUser.Street = updatedAdmin.AppUser.Street;
            existingAdmin.AppUser.Building_Number = updatedAdmin.AppUser.Building_Number;
            existingAdmin.AppUser.BirthDate = updatedAdmin.AppUser.BirthDate;
            existingAdmin.AppUser.PhoneNumber = updatedAdmin.AppUser.PhoneNumber;
            existingAdmin.AppUser.FullName = updatedAdmin.AppUser.FullName;

            db.Admin.Update(existingAdmin);
            db.SaveChanges();

            return existingAdmin;
        }
        //---------------------------------------------
        public Admin GetAdminByUserId(string userId)
        {
            var Admin = db.Admin.Include(a => a.AppUser).FirstOrDefault(a => a.AppUserId == userId);
            if (Admin == null) { return null; }

            return Admin;
        }
        //-----------------------------------------------
        public async Task<Admin> AddAsync(Admin adn)
        {
            await db.AddAsync(adn);
            await db.SaveChangesAsync();
            return adn;
        }
        //-----------------------------------------------
        public Admin DeleteAdmin(int id)
        {
            Admin adn = db.Admin.FirstOrDefault(a => a.Id == id);
            if (adn == null) { return null; }

            db.Admin.Remove(adn);
            db.SaveChanges();

            return adn;
        }
        //------------------------------------------------------------------DOCTORS CRUD-------------------------------------------------------------
        public IEnumerable<Doctor> GetAllDoctors()
        {
            var doctors = db.Doctor.Include(a => a.AppUser).ToList();
            return doctors;
        }
        //-----------------------------------------------
        public IEnumerable<Doctor> GetAllDoctorsBySpecialization(int id)
        {
            var doctors = db.Doctor.Where(s=>s.SpecializationId == id).Include(a => a.AppUser).ToList();
            return doctors;
        }
        //-----------------------------------------------
        public Doctor GetDoctorById(int id)
        {
            var Doctor = db.Doctor.Include(a => a.AppUser).FirstOrDefault(a => a.Id == id);
            if (Doctor == null) { return null; }

            return Doctor;
        }
        //-----------------------------------------------
        public Doctor UpdateDoctor(Doctor updatedDoctor, int id)
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

            db.Doctor.Update(existingDoctor);
            db.SaveChanges();

            return existingDoctor;
        }
        //-----------------------------------------------
        public Doctor DeleteDoctor(int id)
        {
            Doctor dr = db.Doctor.FirstOrDefault(a => a.Id == id);
            if (dr == null) { return null; }

            db.Doctor.Remove(dr);
            db.SaveChanges();

            return dr;
        }
        //-----------------------------------------------
        public Doctor GetDoctorByUserId(string userId)
        {
            var Doctor = db.Doctor.Include(a => a.AppUser).FirstOrDefault(a => a.AppUserId == userId);
            if (Doctor == null) { return null; }

            return Doctor;
        }
        //---------------------------------------------------------------------------RECEPTIONIST-------------------------------------------------------------
        public IEnumerable<Receptionist> GetAllReceptionists()
        {
            return db.Receptionist.Include(a => a.AppUser).ToList();
        }
        //-----------------------------------------------
        public Receptionist GetReceptionistById(int id)
        {
            return db.Receptionist.Include(a => a.AppUser).FirstOrDefault(r=>r.Id == id);
        }
        //-----------------------------------------------
        public Receptionist GetReceptionistByUserId(string userId)
        {
            var Receptionist = db.Receptionist.Include(a => a.AppUser).FirstOrDefault(a => a.AppUserId == userId);
            if (Receptionist == null) { return null; }

            return Receptionist;
        }
        //-----------------------------------------------
        public Receptionist UpdateReceptionist(Receptionist updatedReceptionist, int id)
        {
            Receptionist existingReceptionist = db.Receptionist.Include(a => a.AppUser).FirstOrDefault(a => a.Id == id);

            if (existingReceptionist == null) { return null; }

            // Update properties here, National ID , Email , Admin_ID should NOT be edited
            //existingReceptionist.AppUser.User_National_ID = updatedReceptionist.AppUser.User_National_ID;
            //existingReceptionist.AppUser.Email = updatedReceptionist.AppUser.Email;
            //existingReceptionist.Admin_ID = updatedReceptionist.Admin_ID;
            existingReceptionist.AppUser.Gender = updatedReceptionist.AppUser.Gender;
            existingReceptionist.AppUser.City = updatedReceptionist.AppUser.City;
            existingReceptionist.AppUser.Street = updatedReceptionist.AppUser.Street;
            existingReceptionist.AppUser.Building_Number = updatedReceptionist.AppUser.Building_Number;
            existingReceptionist.AppUser.BirthDate = updatedReceptionist.AppUser.BirthDate;
            existingReceptionist.AppUser.PhoneNumber = updatedReceptionist.AppUser.PhoneNumber;
            existingReceptionist.AppUser.FullName = updatedReceptionist.AppUser.FullName;

            db.Receptionist.Update(existingReceptionist);
            db.SaveChanges();

            return existingReceptionist;
        }
        //-----------------------------------------------
        public Receptionist DeleteReceptionist(int id)
        {
            Receptionist rec = db.Receptionist.FirstOrDefault(a => a.Id == id);
            if (rec == null) { return null; }

            db.Receptionist.Remove(rec);
            db.SaveChanges();

            return rec;
        }
        //---------------------------------------------------------------------------SPECIALIZATION-----------------------------------------------------------
        public IEnumerable<Specialization> GetAllSpecializations()
        {
            var Specializations = db.Specialization.ToList();
            return Specializations;
        }
        //-----------------------------------------------
        public Specialization UpdateSpecialization(Specialization updatedSpecialization, int id)
        {
            Specialization existingSpecialization = db.Specialization.FirstOrDefault(a => a.Id== id);
            if (existingSpecialization == null) { return null; }

            // Update properties here
            existingSpecialization.Specialization_Name = updatedSpecialization.Specialization_Name;
            existingSpecialization.Specialization_Description = updatedSpecialization.Specialization_Description;
        
            db.Specialization.Update(existingSpecialization);
            db.SaveChanges();

            return existingSpecialization;
        }
        //-----------------------------------------------
        public Specialization AddSpecialization(Specialization spec)
        {
            db.Specialization.Add(spec);
            db.SaveChanges();

            return spec;
        }
        //-----------------------------------------------
        public Specialization DeleteSpecialization(int id)
        {
            Specialization spec = db.Specialization.FirstOrDefault(a => a.Id == id);
            if (spec == null) { return null; }

            db.Specialization.Remove(spec);
            db.SaveChanges();

            return spec;
        }
       
    }
}
