using El_Catalan_Hospital.models.Entities;

namespace El_Catalan_Hospital.DataAccessLayer.Repository.Contract
{
    public interface IAdminRepo
    {
        Task<Admin> GetAdminByIdAsync(int id);

        //Admins CRUD
        IEnumerable<Admin> GetAllAdmins();
        Admin GetAdminById(int id);
        Admin UpdateAdmin(Admin updatedAdmin, int id);
        Admin DeleteAdmin(int id);
        Task<Admin> AddAsync(Admin adn);
        Admin GetAdminByUserId(string userId);


        //Doctors CRUD
        IEnumerable<Doctor> GetAllDoctors();
        IEnumerable<Doctor> GetAllDoctorsBySpecialization(int id);
        Doctor GetDoctorById(int id);
        Doctor UpdateDoctor(Doctor updatedDoctor, int id);
        Doctor DeleteDoctor(int id);
        Doctor GetDoctorByUserId(string userId);

        //Receptionist CRUD
        IEnumerable<Receptionist> GetAllReceptionists();
        Receptionist GetReceptionistById(int id);
        Receptionist UpdateReceptionist(Receptionist updatedReceptionist, int id);
        Receptionist DeleteReceptionist(int id);

        Receptionist GetReceptionistByUserId(string userId);



        //Specializations CRUD
        IEnumerable<Specialization> GetAllSpecializations();

        Specialization UpdateSpecialization(Specialization updatedSpecialization, int id);
        Specialization AddSpecialization(Specialization spec);
        Specialization DeleteSpecialization(int id);

    }
}
