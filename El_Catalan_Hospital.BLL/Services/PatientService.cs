using AutoMapper;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.BLL.Services.Contract;
using El_Catalan_Hospital.DataAccessLayer.Repository;
using El_Catalan_Hospital.DataAccessLayer.Repository.Contract;
using El_Catalan_Hospital.models.Entities;


namespace El_Catalan_Hospital.BLL.Services
{
        public class PatientService : IPatientService
        {
            private readonly IPatientRepo _patientRepo;
            private readonly IMapper _mapper;
            private readonly AppointmentRepo appointmentRepo;

        public PatientService(IPatientRepo patientRepo, IMapper mapper)
        {
                _patientRepo = patientRepo;
                _mapper = mapper;
                //_appointmentRepo = appointmentRepo;
        }
        //-----------------------------------------------------------------
        public async Task<PatientDTO> AddAsync(PatientDTO patientDTO)
        {
            var patient = _mapper.Map<Patient>(patientDTO);
            var createdPatient = await _patientRepo.AddAsync(patient);
            var mappingBack = _mapper.Map<PatientDTO>(createdPatient);
            return mappingBack;
        }
        //-----------------------------------------------------------------
        public async Task<PatientDTO> DeleteAsync(int id)
        {
            var deletedPatient = await _patientRepo.DeleteAsync(id);
            return _mapper.Map<PatientDTO>(deletedPatient);
        }
        //-----------------------------------------------------------------
        public IEnumerable<PatientDTO> GetAll()
        {
            var patients = _patientRepo.GetAll();
            return patients.Select(p => _mapper.Map<PatientDTO>(p));
        }
        //-----------------------------------------------------------------
        public PatientDTO GetPatientByID(int id)
        {
            var patient = _patientRepo.GetPatientByID(id);
            return _mapper.Map<PatientDTO>(patient);
        }
        //-----------------------------------------------------------------
        public PatientDTO DisplayPatientProfile(int id)
        {
            var patient = _patientRepo.GetPatientByID(id);
            if (patient == null) { return null; }

            var PDTO = _mapper.Map<PatientDTO>(patient);
            return PDTO;
        }
        //-----------------------------------------------------------------
        public async Task<PatientDTO> UpdateAsync(PatientDTO patientDTO, int id)
        {
            var PatientEntity = _mapper.Map<Patient>(patientDTO);
            var updatedPatient = await _patientRepo.UpdateAsync(PatientEntity, id);
            var updatedPatientDTO = _mapper.Map<PatientDTO>(updatedPatient);
            return updatedPatientDTO;
        }
        //-----------------------------------------------------------------
        public IEnumerable<DoctorDto> GetAllDoctorsBySpec(int spec_id)
        {
            var doctorsList = _patientRepo.GetAllDoctorsBySpecialization(spec_id);
            var doctorIds = doctorsList.Select(d => d.Id).ToList();
            var workingSchedules = _patientRepo.GetWorkingSchedulesForDoctors(doctorIds);

            var doctorsListDTO = _mapper.Map<IEnumerable<DoctorDto>>(doctorsList);
            var workingSchedulesDTO = _mapper.Map<IEnumerable<WorkingScheduleDTO>>(workingSchedules);

            foreach (var doctorDto in doctorsListDTO)
            {
                doctorDto.WorkingSchedules = workingSchedulesDTO
                    .Where(ws => ws.Doctor_ID == doctorDto.Doctor_ID)
                    .ToList();
            }

            return doctorsListDTO;
        }
        //-----------------------------------------------------------------
        //public async Task<AppointmentDTO> RegisterAppointment(int patientId, AppointmentDTO appointmentDTO)
        //{
        //    var patient = _patientRepo.GetPatientByID(patientId);
        //    if (patient == null) { throw new KeyNotFoundException("Patient not found."); }

        //    var appointment = _mapper.Map<Appointment>(appointmentDTO);
        //    appointment.PatientId = patientId;

        //    var createdAppointment = await appointmentRepo.AddAsync(appointment);
        //    return _mapper.Map<AppointmentDTO>(createdAppointment);
        //}
        //-----------------------------------------------------------------
        public async Task<(bool isSuccess, AppointmentDTO appointment, string error)> MakeAnAppointmentAsync(CreateAppointmentDTO appointmentDTO, int patientId)
        {
            var appointmentEntity = _mapper.Map<Appointment>(appointmentDTO);
            appointmentEntity.PatientId = patientId;
            appointmentEntity.Status = Status.Pending;

            var isDoctorAvailable = await _patientRepo.IsDoctorAvailable(appointmentEntity.DoctorId, appointmentEntity.Appointment_Date);
            if (!isDoctorAvailable)
            {
                return (false, null, "Doctor is not available at the requested time.");
            }

            var isTimeSlotBooked = await _patientRepo.IsTimeSlotBooked(appointmentEntity.DoctorId, appointmentEntity.Appointment_Date);
            if (isTimeSlotBooked)
            {
                return (false, null, "Time slot is already booked.");
            }

            var isPatientAvailable = await _patientRepo.IsPatientAvailable(appointmentEntity.PatientId, appointmentEntity.Appointment_Date);
            if (isPatientAvailable)
            {
                return (false, null, "Patient already has an appointment at the requested time.");
            }

            var createdAppointment = await _patientRepo.MakeAnAppointment(appointmentEntity);
            var createdAppointmentDTO = _mapper.Map<AppointmentDTO>(createdAppointment);
            return (true, createdAppointmentDTO, null);
        }
        //-----------------------------------------------------------------
        public IEnumerable<DoctorDto> GetDoctorsByFullName(string fullName)
        {
            var doctorsList = _patientRepo.GetDoctorByName(fullName);
            var doctorIds = doctorsList.Select(d => d.Id).ToList();
            var workingSchedules = _patientRepo.GetWorkingSchedulesForDoctors(doctorIds);

            var doctorsListDTO = _mapper.Map<IEnumerable<DoctorDto>>(doctorsList);
            var workingSchedulesDTO = _mapper.Map<IEnumerable<WorkingScheduleDTO>>(workingSchedules);

            foreach (var doctorDto in doctorsListDTO)
            {
                doctorDto.WorkingSchedules = workingSchedulesDTO
                    .Where(ws => ws.Doctor_ID == doctorDto.Doctor_ID)
                    .ToList();
            }

            return doctorsListDTO;
        }
        //-----------------------------------------------------------------
        public async Task<IEnumerable<AppointmentDTO>> GetPatientFutureAppointmentsAsync(int patientId)
        {
            var FutureAppointments = await _patientRepo.GetPatientFutureAppointmentsAsync(patientId);
            return _mapper.Map<IEnumerable<AppointmentDTO>>(FutureAppointments);
        }
        //-----------------------------------------------------------------
    }

}
