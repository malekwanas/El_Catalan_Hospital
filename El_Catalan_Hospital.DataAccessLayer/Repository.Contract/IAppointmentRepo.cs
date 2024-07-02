using El_Catalan_Hospital.models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.DataAccessLayer.Repository.Contract
{
    public interface IAppointmentRepo
    {
        IEnumerable<Appointment> GetAll();
        Appointment GetAppointmentByID(int id);
        Task<Appointment>AddAsync(Appointment appointment);
        Task<Appointment> DeleteAsync(int id);
        Task<Appointment> UpdateAsync(Appointment appointment,int id ); 




    }
}
