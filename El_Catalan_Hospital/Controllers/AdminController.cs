using El_Catalan_Hospital.BLL;
using El_Catalan_Hospital.BLL.Services.Contract;
using El_Catalan_Hospital.models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace El_Catalan_Hospital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;
        public AdminController(IAdminService _adminService)
        {
            adminService = _adminService;
        }
        //------------------------------------------------------------------
        [HttpGet("GetAllAdmins")]
        public IActionResult GetAllAdmins()
        {
            var admins = adminService.GetAllAdmins();
            return Ok(admins);
        }
        //------------------------------------------------------------------
    }
}
