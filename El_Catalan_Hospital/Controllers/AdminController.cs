using El_Catalan_Hospital.API.Dtos;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.BLL.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using El_Catalan_Hospital.BLL.Errors;
using El_Catalan_Hospital.BLL.Responses;
using Microsoft.AspNetCore.Authorization;

namespace El_Catalan_Hospital.API.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;
        private readonly ILogger<AccountController> _logger;
       
        public AdminController(IAdminService _adminService , ILogger<AccountController> logger)
        {
            adminService = _adminService;
            _logger = logger;
        }
        //-------------------------------------------------------------------
        private int GetAdminIdFromToken()
        {
            var adnID = User.Claims.FirstOrDefault(d => d.Type == "Id")?.Value;
            if (adnID == null) { return 0; }

            if (int.TryParse(adnID, out int doctorId)) { return doctorId; }
            return 0;
        }
        //--------------------------------------------------------------------
        [HttpGet("GetAdminById")]
        public async Task<IActionResult> GetAdminProfileByHisId()
        {
            var AdminID = GetAdminIdFromToken();
            if (AdminID == 0) { return BadRequest("Invalid Admin ID."); }

            var Admin = await adminService.DisplayAdminProfileAsync(AdminID);
            if (Admin == null) { return NotFound("Admin not found."); }
            return Ok(Admin);
        }
        //--------------------------------------------------------------------
        //Update logged in admin here
        //------------------------------------------------------------------ADMINS----------------------------------------------------------
        [HttpGet("GetAllAdmins")]
        public IActionResult GetAllAdmins()
        {
            var admins = adminService.GetAllAdmins();
            if (admins == null || admins.Count() <= 1) { return NotFound("No admins in the Database except for you."); }
            return Ok(admins);
        }
        //------------------------------------------------------------------
        [HttpGet("GetAdminById/{id}")]
        public IActionResult GetAdminByHisId(int id)
        {
            var admin = adminService.GetSpecificAdmin(id);
            return Ok(admin);
        }
        //------------------------------------------------------------------
        [HttpPut("UpdateAdminInfo/{id}")]
        public IActionResult UpdateAdminData(AdminDto adminDTO, int id)
        {
            if (adminDTO == null || id <= 0) { return BadRequest("Invalid admin data or ID."); }

            var updatedAdmin = adminService.UpdateAdminInformation(adminDTO, id);
            if (updatedAdmin == null) { return NotFound("Admin not found."); }

            return Ok(updatedAdmin);
        }
        //------------------------------------------------------------------
        [HttpDelete("DeleteAdmin/{id}")]
        public IActionResult DeleteAdminData(int id)
        {
            var adminDTO = adminService.GetSpecificAdmin(id);
            if (adminDTO == null || id <= 0) { return BadRequest("Invalid admin data or ID."); }

            var DeleteAdmin = adminService.DeleteAdminById(id);
            return Ok(DeleteAdmin);
        }
        //------------------------------------------------------------------
        
        //------------------------------------------------------------------DOCTORS----------------------------------------------------------
        [HttpGet("GetAllDoctors")]
        public IActionResult GetAllDoctors()
        {
            var doctors = adminService.GetAllDoctors();
            if (doctors == null || doctors.Count() < 1) { return NotFound("No doctors in the Database "); }
            return Ok(doctors);
        }
        //------------------------------------------------------------------
        [HttpGet("GetAllDoctorsByTheirSpecialization/{id}")]
        public IActionResult GetAllDoctorsBySpecialization(int id)
        {
            var doctors = adminService.GetAllDoctorsBySpec(id);
            if (doctors == null || doctors.Count() < 1) { return NotFound("No doctors in this specialization"); }
            return Ok(doctors);
        }
        //------------------------------------------------------------------
        [HttpGet("GetDoctorById/{id}")]
        public IActionResult GetDoctorByHisId(int id)
        {
            var doctor = adminService.GetSpecificDoctor(id);
            if (doctor == null) { return NotFound($"No doctor found with this ID of {id}"); }
            return Ok(doctor);
        }
        //------------------------------------------------------------------
        [HttpPut("UpdateDoctorInfo/{id}")]
        public IActionResult UpdateDoctorData(DoctorDto doctorDTO, int id)
        {
            if (doctorDTO == null || id <= 0) { return BadRequest("Invalid doctor data or ID."); }

            var updatedDoctor = adminService.UpdateDoctorInformation(doctorDTO, id);
            if (updatedDoctor == null) { return NotFound("Doctor not found."); }

            return Ok(updatedDoctor);
        }
        //------------------------------------------------------------------
        [HttpDelete("DeleteDoctor/{id}")]
        public IActionResult DeleteDoctorData(int id)
        {
            var doctorDTO = adminService.GetSpecificDoctor(id);
            if (doctorDTO == null || id <= 0) { return BadRequest("Invalid doctor data or ID."); }

            var DeletedDoctor = adminService.DeleteDoctorById(id);
            return Ok(DeletedDoctor);
        }
        //---------------------------------------------------------------------------Receptionists--------------------------------------------------
        [HttpGet("GetAllReceptionists")]
        public IActionResult GetAllReceptionists()
        {
            var Receptionists = adminService.GetAllReceptionists();
            if (Receptionists == null || Receptionists.Count() < 1) { return NotFound("No Receptionists in the Database."); }
            return Ok(Receptionists);
        }
        //------------------------------------------------------------------
        [HttpGet("GetReceptionistById/{id}")]
        public IActionResult GetReceptionistByHisId(int id)
        {
            var Receptionist = adminService.GetSpecificReceptionist(id);
            if(Receptionist == null) { return NotFound($"No Receptionist was found with the following ID : {id}"); }

            return Ok(Receptionist);
        }
        //------------------------------------------------------------------
        [HttpPut("UpdateReceptionistInfo/{id}")]
        public IActionResult UpdateReceptionistData(ReceptionistDto ReceptionistDTO, int id)
        {
            if (ReceptionistDTO == null || id <= 0) { return BadRequest("Invalid Receptionist data or ID."); }

            var updatedReceptionist = adminService.UpdateReceptionistInformation(ReceptionistDTO, id);
            if (updatedReceptionist == null) { return NotFound("Receptionist not found."); }

            return Ok(updatedReceptionist);
        }
        //------------------------------------------------------------------
        [HttpDelete("DeleteReceptionist/{id}")]
        public IActionResult DeleteReceptionistData(int id)
        {
            var ReceptionistDto = adminService.GetSpecificReceptionist(id);
            if (ReceptionistDto == null || id <= 0) { return BadRequest("Invalid Receptionist data or ID."); }

            adminService.DeleteDoctorById(id);
            return Ok("Receptionist deleted successfully.");
        }
        //---------------------------------------------------------------------------SPECIALIZATION--------------------------------------------------
        [HttpGet("GetAllSpecializations")]
        public IActionResult GetAllSpecializations()
        {
            var specs = adminService.GetAllSpecializations();
            if (specs == null || specs.Count() < 1) { return NotFound("No Specializations in the Database "); }
            return Ok(specs);
        }
        //------------------------------------------------------------------
        [HttpPut("UpdateSpecializationInfo/{id}")]
        public IActionResult UpdateSpecializationData(SpecializationDTO specializationDTO, int id)
        {
            if (specializationDTO == null || id <= 0) { return BadRequest("Invalid specializationDTO data or ID."); }

            var updatedspecialization = adminService.UpdateSpecializationInformation(specializationDTO, id);
            if (updatedspecialization == null) { return NotFound("Specialization not found."); }

            return Ok(updatedspecialization);
        }
        //------------------------------------------------------------------
        [HttpPost("AddSpecialization")]
        public IActionResult AddSpecialization(SpecializationDTO specializationDTO)
        {
            if (specializationDTO == null) { return BadRequest("Invalid specialization data."); }

            var addedSpecialization = adminService.AddSpecialization(specializationDTO);
            return Ok(addedSpecialization);
        }
        //------------------------------------------------------------------
        [HttpDelete("DeleteSpecialization/{id}")]
        public IActionResult DeleteSpecializationData(int id)
        {
            var specializationDTO = adminService.DeleteSpecializationById(id);
            if (specializationDTO == null || id <= 0) { return BadRequest("Invalid Specialization ID."); }

           adminService.DeleteSpecializationById(id);
            return Ok("Specialization deleted successfully");
        }
        //------------------------------------------------------------------ register admin------------------------------//
        [HttpPost("RegisterAdmin")]
        [AllowAnonymous]
        public async Task<ActionResult> RegisterAdmin(RegisterDto model)
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

                var result = await adminService.RegisterAdminAsync(model);

                if (result.isSucceeded) { return Ok(result); }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorMsg.AnErrorOccured);
                return StatusCode(500, new Response
                {
                    Message = ErrorMsg.UnExpectedError,
                    isSucceeded = false,
                    Errors = new[] { ex.Message }
                });
            }
        }
        //----------------------------------------------------- register receptionist --------------------------------------//
        [HttpPost("RegisterReceptionist/{AdminId}")]
        public async Task<ActionResult> RegisterReceptionist(RegisterDto model, int AdminId)
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


                var result = await adminService.RegisterReceptionistAsync(model, AdminId);

                if (result.isSucceeded)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorMsg.AnErrorOccured);
                return StatusCode(500, new Response
                {
                    Message = ErrorMsg.GeneralErrorMsg,
                    isSucceeded = false,
                    Errors = new[] { ex.Message }
                });
            }
        }

        // -------------------------------------------------- register doctor ------------------------------------

        [HttpPost("RegisterDoctor/{AdminId}/{specializationId}")]
        public async Task<ActionResult> RegisterDoctor(RegisterDto model, int AdminId , int specializationId)
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


                var result = await adminService.RegisterDoctorAsync(model, AdminId,specializationId);

                if (result.isSucceeded)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorMsg.AnErrorOccured);
                return StatusCode(500, new Response
                {
                    Message = ErrorMsg.GeneralErrorMsg,
                    isSucceeded = false,
                    Errors = new[] { ex.Message }
                });
            }
        }


    }
}
