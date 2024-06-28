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
    }
}
