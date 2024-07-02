using El_Catalan_Hospital.models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.DataAccessLayer.Repository.Contract
{
    public interface IReceptionistRepo
    {
        Task<Receptionist> GetReceptionistByIdAsync(int id);
        Task<Receptionist> UpdateReceptionist(Receptionist updatedReceptionist, int id);
        IEnumerable<Patient> GetAllPatients();
        void RegisterPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void AddAppointment(Appointment appointment);
        void RemoveAppointment(int Id);

    }
}
