using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.BLL.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace El_Catalan_Hospital.API.Controllers
{
    [Authorize(Roles = "doctor")]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService doctorService;
        public DoctorController(IDoctorService _doctorService)
        {
            doctorService = _doctorService;
        }
        //-------------------------------------------------------
        private int GetDoctorIdFromToken()
        {
            var drID = User.Claims.FirstOrDefault(d => d.Type == "Id")?.Value;
            if (drID == null) { return 0; }

            if (int.TryParse(drID, out int doctorId)) { return doctorId; }
            return 0;
        }
        //-------------------------------------------------------
        [HttpGet("GetDoctorById")]
        public async Task<IActionResult> GetDoctorProfileByHisId()
        {
            var DoctorID = GetDoctorIdFromToken();
            if (DoctorID == 0) { return BadRequest("Invalid doctor ID."); }

            var Doctor = await doctorService.DisplayDoctorProfileAsync(DoctorID);
            if (Doctor == null) { return NotFound("Doctor not found."); }
            return Ok(Doctor);
        }
        //-------------------------------------------------------
        [HttpPut("UpdateDoctorFromProfile/{id}")]
        public async Task<IActionResult> UpdateDoctorData(DoctorDto doc,int id)
        {
            if (doc == null || id <= 0) { return BadRequest("Invalid doctor data or ID."); }

            var tokenID = GetDoctorIdFromToken();
            if(tokenID != id) { return BadRequest("Logged in doctor can only update his information"); }

            var updatedDoctor = await doctorService.UpdateDoctorInformation(doc, id);
            if (updatedDoctor == null) { return NotFound("Doctor not found."); }

            return Ok(updatedDoctor);
        }
        //-------------------------------------------------------
        [HttpGet("GetALLAppointments")]
        public async Task<IActionResult> GetDoctorAppointments()
        {
            var doctorId = GetDoctorIdFromToken();
            if (doctorId == 0) { return BadRequest("Invalid doctor ID."); }

            var appointments = await doctorService.GetDoctorAppointmentsAsync(doctorId);
            if (appointments == null || !appointments.Any()) { return NotFound("No appointments found."); }
            return Ok(appointments);
        }

        //-------------------------------------------------------
        [HttpGet("GetAllFutureAppointments")]
        public async Task<IActionResult> GetDoctorFutureAppointments()
        {
            var doctorId = GetDoctorIdFromToken();
            if (doctorId == 0) { return BadRequest("Invalid doctor ID."); }

            var FutureAppointments = await doctorService.GetDoctorFutureAppointmentsAsync(doctorId);
            if (FutureAppointments == null || !FutureAppointments.Any()) { return NotFound("No future appointments found."); }
            return Ok(FutureAppointments);
        }
        //-------------------------------------------------------
        [HttpDelete("DeleteOneAppointment/{appointmentId}")]
        public async Task<IActionResult> DeleteOneAppointment(int appointmentId)
        {
            if (appointmentId <= 0) { return BadRequest("Invalid appointment ID."); }

            var doctorId = GetDoctorIdFromToken();
            if (doctorId == 0) { return Unauthorized("Invalid doctor ID."); }

            var result = await doctorService.CancelAppointmentAsync(appointmentId);
            if (!result) { return NotFound("Appointment not found or could not be canceled."); }

            return Ok("Appointment canceled successfully.");
        }
        //-------------------------------------------------------
        [HttpGet("GetDoctorWorkingSchedule")]
        public IActionResult GetDoctorWorkingSchedule() 
        {
            var doctorId = GetDoctorIdFromToken();
            if (doctorId == 0) { return Unauthorized("Invalid doctor ID."); }

            var result = doctorService.GetWorkingSchedule(doctorId);
            if (result.Count() < 1) { return NotFound("No working schedule has been set for you yet."); }

            return Ok(result);
        }
        //-------------------------------------------------------
        [HttpDelete("DeleteWorkingSchedule/{id}")]
        public async Task<IActionResult> DeleteOneWorkingSchedule(int id)
        {
            var result = await doctorService.DeleteWorkScheduleAsync(id);
            if (result != null) { return Ok(new { message = "Working Schedule deleted successfully.", data = result }); }
            else { return NotFound("Working schedule with the provided ID couldn't be found or deleted."); }
        }
        //-------------------------------------------------------
        [HttpPost("AddWorkingSchedule")]
        public async Task<IActionResult> AddWorkingSchedule(WorkingScheduleDTO workingScheduleDTO)
        {
            if (workingScheduleDTO == null) { return BadRequest("The workingScheduleDTO field is required."); }

            var doctorId = GetDoctorIdFromToken();
            if (doctorId == 0) { return Unauthorized("Invalid doctor ID."); }

            var (isSuccess, addedSchedule, error) = await doctorService.AddWorkingScheduleAsync(workingScheduleDTO, doctorId);
            if (!isSuccess) { return BadRequest(error); }

            return Ok(new { message = "Working Schedule added successfully.", data = addedSchedule });
        }
        //-------------------------------------------------------
    }
}
