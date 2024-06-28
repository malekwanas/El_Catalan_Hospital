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
        [HttpGet("Hello")]
        public IActionResult SayHello()
        {
            return Ok("Hello");
        }
    }
}
