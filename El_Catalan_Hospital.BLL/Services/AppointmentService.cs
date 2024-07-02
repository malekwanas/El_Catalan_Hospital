using AutoMapper;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.BLL.Services.Contract;
using El_Catalan_Hospital.DataAccessLayer.Repository;
using El_Catalan_Hospital.DataAccessLayer.Repository.Contract;
using El_Catalan_Hospital.models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.BLL.Services
{
    public class AppointmentService : IAppointmentService
    {
        
        private readonly IAppointmentRepo appointmentRepo;
        private readonly IMapper mapper;

        public AppointmentService(IAppointmentRepo _appointmentRepo,IMapper _mapper )
        {
            
            appointmentRepo = _appointmentRepo;
            mapper = _mapper;
        }
        public IEnumerable<AppointmentDTO> GetAllAppointments()
        {
            var appointments = appointmentRepo.GetAll();
            var appointmentDto = mapper.Map<IEnumerable<AppointmentDTO>>(appointments);
            return appointmentDto;
        }
        public async Task<Appointment> AddAsync(AppointmentDTO appointmentDTO)
        {
            var appointment = mapper.Map<Appointment>(appointmentDTO);
            var createdAppointment = await appointmentRepo.AddAsync(appointment);
            return createdAppointment;
        }

        public async Task<AppointmentDTO> DeleteAsync(int id)
        {
            var deletedAppointment = await appointmentRepo.DeleteAsync(id);
            return mapper.Map<AppointmentDTO>(deletedAppointment);
        }

        public IEnumerable<AppointmentDTO> GetAll()
        {
            var appointments = appointmentRepo.GetAll();
            return appointments.Select(a => mapper.Map<AppointmentDTO>(a));
        }

        public AppointmentDTO GetAppointmentByID(int id)
        {
            var appointment = appointmentRepo.GetAppointmentByID(id);
            return mapper.Map<AppointmentDTO>(appointment);
        }

        public async Task<AppointmentDTO> UpdateAsync(AppointmentDTO appointmentDTO, int id)
        {
            var appointment = mapper.Map<Appointment>(appointmentDTO);
            var updatedAppointment = await appointmentRepo.UpdateAsync(appointment, id);
            return mapper.Map<AppointmentDTO>(updatedAppointment);
        }
    }
}
