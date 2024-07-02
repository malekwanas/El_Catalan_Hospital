using El_Catalan_Hospital.API.Dtos;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.BLL.Errors;
using El_Catalan_Hospital.BLL.Responses;
using El_Catalan_Hospital.BLL.Services.Contract;
using Microsoft.AspNetCore.Mvc;
namespace El_Catalan_Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionistController : ControllerBase
    {
        private readonly IReceptionistService receptionistService;
        private readonly IAppointmentService appointmentService;

        public ReceptionistController(IReceptionistService _receptionistService, IAppointmentService _appointmentService)
        {
            receptionistService = _receptionistService;
            appointmentService = _appointmentService;
        }
        //------------------------------------------------------------------------------------------------------------
        private int GetReceptionistIDFromToken()
        {
            var recID = User.Claims.FirstOrDefault(d => d.Type == "Id")?.Value;
            if (recID == null) { return 0; }

            if (int.TryParse(recID, out int recId)) { return recId; }
            return 0;
        }
        //------------------------------------------------------------------------------------------------------------
        [HttpGet("GetReceptionistById")]
        public async Task<IActionResult> GetReceptionistProfileByHisId()
        {
            var ReceptionistID = GetReceptionistIdFromToken();
            if (ReceptionistID == 0) { return BadRequest("Invalid Receptionist ID."); }

            var Receptionist = await receptionistService.DisplayReceptionistProfileAsync(ReceptionistID);
            if (Receptionist == null) { return NotFound("Receptionist not found."); }
            return Ok(Receptionist);
        }
        //------------------------------------------------------------------------------------------------------------
        [HttpPut("UpdateReceptionistFromProfile/{id}")]
        public async Task<IActionResult> UpdateReceptionistData(ReceptionistDto rec, int id)
        {
            if (rec == null || id <= 0) { return BadRequest("Invalid receptionist data or ID."); }

            var tokenID = GetReceptionistIdFromToken();
            if (tokenID != id) { return BadRequest("Logged in receptionist can only update his information"); }

            var updatedReceptionist = await receptionistService.UpdateReceptionistInformation(rec, id);
            if (updatedReceptionist == null) { return NotFound("receptionist not found."); }

            return Ok(updatedReceptionist);
        }
        //------------------------------------------------------------------------------------------------------------
        [HttpGet("GetAllPatients")]
        public IActionResult GetAllPatients()
        {
            var patients = receptionistService.GetAllPatient();
            if (patients == null || patients.Count() <= 1) { return NotFound("no patient."); }
            return Ok(patients);
        }
        //------------------------------------------------------------------------------------------------------------
        [HttpGet("GetAllAppointment")]
        public IActionResult GetAllAppointment()
        {
            var Appointments = appointmentService.GetAllAppointments();
            if (Appointments == null || Appointments.Count() < 1)
            {
                return NotFound("No appointments.");
            }
            return Ok(Appointments);

        }
        //------------------------------------------------------------------------------------------------------------
        [HttpGet("GetAppointment/{id}")]
        public ActionResult<AppointmentDTO> GetAppointment(int id)
        {
            var appointment = appointmentService.GetAppointmentByID(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }
        //------------------------------------------------------------------------------------------------------------
        private int GetReceptionistIdFromToken()
        {
            var receptionistId = User.Claims.FirstOrDefault(d => d.Type == "Id")?.Value;
            if (receptionistId == null) { return 0; }

            if (int.TryParse(receptionistId, out int ReceptionitstId)) { return ReceptionitstId; }
            return 0;
        }
        //------------------------------------------------------------------------------------------------------------
        [HttpPost("RegisterPatient")]
        public async Task<ActionResult> RegisterAsync(RegisterDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new Response
                    {
                        Message = ErrorMsg.InvalidProperties,
                        isSucceeded = false,
                        Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                    });
                }
                 var ReceptionistId = GetReceptionistIdFromToken();

                var result = await receptionistService.RegisterPatientAsync(model, ReceptionistId);

                if (result.isSucceeded)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response
                {
                    Message = ErrorMsg.GeneralErrorMsg,
                    isSucceeded = false,
                    Errors = new[] { ex.Message }
                });
            }
        }
        //------------------------------------------------------------------------------------------------------------
    }
}
