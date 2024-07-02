using AutoMapper;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.BLL.Services.Contract;
using El_Catalan_Hospital.DataAccessLayer.Repository;
using El_Catalan_Hospital.DataAccessLayer.Repository.Contract;
using El_Catalan_Hospital.models.Entities;

namespace El_Catalan_Hospital.BLL.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo doctorRepo;
        private readonly IMapper mapper;

        public DoctorService(IDoctorRepo _doctorRepo, IMapper _mapper)
        {
            doctorRepo = _doctorRepo;
            mapper = _mapper;
        }
        //-------------------------------------------------------------
        public async Task<DoctorDto> DisplayDoctorProfileAsync(int id)
        {
            var dr = await doctorRepo.GetDoctorByIdAsync(id);
            if (dr == null) { return null; }

            var drDTO = mapper.Map<DoctorDto>(dr);
            return drDTO;
        }
        //-------------------------------------------------------------
        public async Task<DoctorDto> UpdateDoctorInformation(DoctorDto doctorDTO, int id)
        {
            // Map DoctorDto to Doctor entity
            var DoctorEntity = mapper.Map<Doctor>(doctorDTO);

            var updatedDoctor = await doctorRepo.UpdateDoctor(DoctorEntity, id);
            var updatedDoctorDTO = mapper.Map<DoctorDto>(updatedDoctor);
            return updatedDoctorDTO;
        }
        //-------------------------------------------------------------
        public async Task<IEnumerable<AppointmentDTO>> GetDoctorAppointmentsAsync(int doctorId)
        {
            var appointments = await doctorRepo.GetDoctorAppointmentsAsync(doctorId);
            var appointmentsDTO = mapper.Map<IEnumerable<AppointmentDTO>>(appointments);
            return appointmentsDTO;
        }

        //-------------------------------------------------------------
        public async Task<IEnumerable<AppointmentDTO>> GetDoctorFutureAppointmentsAsync(int doctorId)
        {
            var FutureAppointments = await doctorRepo.GetDoctorFutureAppointmentsAsync(doctorId);
            return mapper.Map<IEnumerable<AppointmentDTO>>(FutureAppointments);
        }
        //-------------------------------------------------------------
        public async Task<bool> CancelAppointmentAsync(int appointmentId)
        {
            try
            {
                var result = await doctorRepo.CancelAppointmentAsync(appointmentId);
                return result;
            }
            catch (Exception ex) { return false; }
        }
        //-------------------------------------------------------------
        public IEnumerable<WorkingScheduleDTO> GetWorkingSchedule(int id)
        {
            var DoctorWorkingSchedule = doctorRepo.GetWorkingSchedules(id);
            return mapper.Map<IEnumerable<WorkingScheduleDTO>>(DoctorWorkingSchedule);
        }
        //-------------------------------------------------------------
        public async Task<WorkingScheduleDTO> DeleteWorkScheduleAsync(int id)
        {
            var deletedWorkingSchedule = await doctorRepo.DeleteWorkingScheduleAsync(id);
            return mapper.Map<WorkingScheduleDTO>(deletedWorkingSchedule);
        }
        //-------------------------------------------------------------
        public async Task<(bool isSuccess, WorkingScheduleDTO addedSchedule, string error)> AddWorkingScheduleAsync(WorkingScheduleDTO workScheduleDTO, int drID)
        {
            var workingScheduleEntity = new WorkingSchedule
            {
                Working_Schedule_Start_Time = TimeOnly.Parse(workScheduleDTO.Working_Schedule_Start_Time),
                Working_Schedule_End_Time = TimeOnly.Parse(workScheduleDTO.Working_Schedule_End_Time),
                Working_Schedule_Day = workScheduleDTO.Working_Schedule_Day,
                Doctor_ID = drID
            };

            var isDuplicateOrOverlapping = await doctorRepo.IsDuplicateOrOverlappingWorkingScheduleAsync(workingScheduleEntity, drID);
            if (isDuplicateOrOverlapping)
            {
                return (false, null, "A working schedule with the same start and end time or overlapping times on the same day already exists.");
            }

            var addedWorkingSchedule = await doctorRepo.AddWorkingScheduleAsync(workingScheduleEntity, drID);
            var addedWorkingScheduleDTO = mapper.Map<WorkingScheduleDTO>(addedWorkingSchedule);
            return (true, addedWorkingScheduleDTO, null);
        }

        //-------------------------------------------------------------
    }
}
