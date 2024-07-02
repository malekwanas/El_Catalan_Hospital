using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.BLL.Services.Contract
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentDTO> GetAllAppointments();
        Task<Appointment> AddAsync(AppointmentDTO appointmentDTO);
        Task<AppointmentDTO> DeleteAsync(int id);
        IEnumerable<AppointmentDTO> GetAll();
        AppointmentDTO GetAppointmentByID(int id);
        Task<AppointmentDTO> UpdateAsync(AppointmentDTO appointmentDTO, int id);

    }
}
