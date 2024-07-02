using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.BLL.Services;
using El_Catalan_Hospital.BLL.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace El_Catalan_Hospital.API.Controllers
{
    [Authorize(Roles ="patient")]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService patientService;
        private readonly IAppointmentService appointmentService;

        public PatientController(IPatientService _patientService,IAppointmentService _appointmentService)
        {
            patientService = _patientService;
            appointmentService = _appointmentService;
        }
        //-----------------------------------------------------------------------------------------------
        private int GetPatientIdFromToken()
        {
            var PatientID = User.Claims.FirstOrDefault(d => d.Type == "Id")?.Value;
            if (PatientID == null) { return 0; }

            if (int.TryParse(PatientID, out int PId)) { return PId; }
            return 0;
        }
        //-----------------------------------------------------------------------------------------------
        [HttpGet("GetPatientById")]
        public IActionResult GetPatientProfileByHisId()
        {
            var PatientID = GetPatientIdFromToken();
            if (PatientID == 0) { return BadRequest("Invalid Patient ID."); }

            var patient =  patientService.DisplayPatientProfile(PatientID);
            if (patient == null) { return NotFound("Patient not found."); }
            return Ok(patient);
        }
        //-----------------------------------------------------------------------------------------------
        [HttpPut("UpdatedPatient/{id}")]
        public async Task<IActionResult> PutPatient(int id, PatientDTO patientDTO)
        {


            var updatedPatient = await patientService.UpdateAsync(patientDTO, id);
            if (updatedPatient == null) { return NotFound("Cant find updated patient."); }

            return Ok();
        }
        //-----------------------------------------------------------------------------------------------
        //[HttpPost("AddAppointment")]
        //public async Task<ActionResult<AppointmentDTO>> PostAppointment(AppointmentDTO appointmentDTO)
        //{
        //    var createdAppointment = await appointmentService.AddAsync(appointmentDTO);
        //    return Ok(createdAppointment);
        //}
        //-----------------------------------------------------------------------------------------------
        [HttpPost("MakeAppointment")]
        public async Task<IActionResult> MakeAppointment([FromBody] CreateAppointmentDTO appointmentDTO)
        {
            var PatientID = GetPatientIdFromToken();
            if (PatientID == 0) { return BadRequest("Invalid Patient ID."); }

            var (isSuccess, appointment, error) = await patientService.MakeAnAppointmentAsync(appointmentDTO, PatientID);
            if (!isSuccess) { return BadRequest(error); }

            return Ok(appointment);
        }
        //-----------------------------------------------------------------------------------------------
        [HttpGet("GetAllDoctorsByTheirSpecialization/{id}")]
        public IActionResult GetAllDoctorsBySpecialization(int id)
        {
            var doctors = patientService.GetAllDoctorsBySpec(id);
            if (doctors == null || !doctors.Any()) { return NotFound("No doctors in this specialization"); }
            return Ok(doctors);
        }
        //-----------------------------------------------------------------------------------------------
        [HttpGet("GetAllDoctorsByTheirName/{name}")]
        public IActionResult GetDoctorByHisName(string name)
        {
            var doctors = patientService.GetDoctorsByFullName(name);
            if (doctors == null || !doctors.Any()) { return NotFound("No doctors found with this name"); }
            return Ok(doctors);
        }
        //-----------------------------------------------------------------------------------------------
        [HttpGet("GetFutureAppointmentsForPatient")]
        public async Task<IActionResult> GetPatientFutureAppointments()
        {
            var patientId = GetPatientIdFromToken();
            if (patientId == 0) { return BadRequest("Invalid Patient ID."); }

            var FutureAppointments = await patientService.GetPatientFutureAppointmentsAsync(patientId);
            if (FutureAppointments == null || !FutureAppointments.Any()) { return NotFound("No future appointments found."); }
            return Ok(FutureAppointments);
        }
        //-----------------------------------------------------------------------------------------------
    }

}

