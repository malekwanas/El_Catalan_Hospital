using El_Catalan_Hospital.API.Dtos;
using El_Catalan_Hospital.API.Repository.Contract;
using El_Catalan_Hospital.BLL.Services.Contract;
using El_Catalan_Hospital.models.Entities;
using El_Catalan_Hospital.models.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace El_Catalan_Hospital.API.Controllers
{
   
    public class AccountController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthService _authService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IGenericRepository<Patient> _patientRepository;
        private readonly IGenericRepository<Admin> _adminRepository;

        private readonly IGenericRepository<Doctor> _doctorRepository;
        private readonly IGenericRepository<Receptionist> _receptionistRepository;

        public AccountController(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,
            IAuthService authService, RoleManager<IdentityRole> roleManager,
            IGenericRepository<Patient> patientRepository,
            IGenericRepository<Admin> adminRepository,
            IGenericRepository<Doctor> doctorRepository,
              IGenericRepository<Receptionist> receptionistRepository


            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
            _roleManager = roleManager;
            _patientRepository = patientRepository;
            _adminRepository = adminRepository;
            _doctorRepository = doctorRepository;
            _receptionistRepository = receptionistRepository;
        }


        [HttpPost("Login")]

        public async Task<ActionResult<UserDto>> Login(LoginDto Model)
        {
            var user = await _userManager.FindByEmailAsync(Model.Email);
            if (user is null)
            {
                return Unauthorized();
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, Model.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            var token = await _authService.CreateTokenAsync(user, _userManager);

            return Ok(new UserDto
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = token
            });
        }


        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto Model)
        {
            var user = new AppUser()
            {
                DisplayName = Model.DisplayName,
                Email = Model.Email,
                UserName = Model.DisplayName,
                PhoneNumber = Model.PhoneNumber,
                User_National_ID = Model.User_National_ID,
       
            };
          
            var patient = new Patient()
            {
               
                UserId = user.Id,
                
                 ReceptionistID = Model.ReceptionistID

            };
            

            if (!await _roleManager.RoleExistsAsync("patient"))
            {
                var role = new IdentityRole();
                role.Name = "patient";
                await _roleManager.CreateAsync(role);
            }
            await _patientRepository.AddAsync(patient);

            var result = await _userManager.CreateAsync(user, Model.Password);
            


            if (!result.Succeeded)
            {
                return BadRequest(440);
            }
            await _userManager.AddToRoleAsync(user, "patient");


            return Ok("Registered");
        }



        //admin
        [HttpPost("RegisterAdmin")]
        public async Task<ActionResult<UserDto>> RegisterAdmin(RegisterDto Model)
        {
            var user = new AppUser()
            {
                DisplayName = Model.DisplayName,
                Email = Model.Email,
                UserName = Model.DisplayName,
                PhoneNumber = Model.PhoneNumber,
                User_National_ID = Model.User_National_ID,


            };
            var admin = new Admin()
            {
                AppUser = user,
                UserId = user.Id,
                
                
            };


            if (!await _roleManager.RoleExistsAsync("admin"))
            {
                var role = new IdentityRole();
                role.Name = "admin";
                await _roleManager.CreateAsync(role);
            }
            await _adminRepository.AddAsync(admin);

            var result = await _userManager.CreateAsync(user, Model.Password);



            if (!result.Succeeded)
            {
                return BadRequest(440);
            }
            await _userManager.AddToRoleAsync(user, "admin");

           

            return Ok("Registered");
        }

        

        [HttpPost("RegisterDoctor/{specializationId}")]
        public async Task<ActionResult<UserDto>> RegisterDoctor(int specializationId,RegisterDoctorDto Model)
        {
            var user = new AppUser()
            {
                DisplayName = Model.DisplayName,
                Email = Model.Email,
                UserName = Model.DisplayName,
                PhoneNumber = Model.PhoneNumber,
                User_National_ID = Model.User_National_ID,

            };
            var doctor = new Doctor()
            {
                AppUser = user,
                UserId = user.Id,
                SpecializationId= specializationId,
                Admin_ID = Model.Adminid,
                

            };


            if (!await _roleManager.RoleExistsAsync("doctor"))
            {
                var role = new IdentityRole();
                role.Name = "doctor";
                await _roleManager.CreateAsync(role);
            }
            await _doctorRepository.AddAsync(doctor);

            var result = await _userManager.CreateAsync(user, Model.Password);



            if (!result.Succeeded)
            {
                return BadRequest(440);
            }
            await _userManager.AddToRoleAsync(user, "doctor");

           

            return Ok("Registered");
        }



        [HttpPost("RegisterReceptionist")]
        public async Task<ActionResult<UserDto>> RegisterReceptionist (RegisterDoctorDto Model)
        {
            var user = new AppUser()
            {
                DisplayName = Model.DisplayName,
                Email = Model.Email,
                UserName = Model.DisplayName,
                PhoneNumber = Model.PhoneNumber,
                User_National_ID = Model.User_National_ID,

            };
            var receptionist = new Receptionist()
            {
                AppUser = user,
                UserId = user.Id,
                Admin_ID = Model.Adminid,


            };


            if (!await _roleManager.RoleExistsAsync("receptionist"))
            {
                var role = new IdentityRole();
                role.Name = "receptionist";
                await _roleManager.CreateAsync(role);
            }
            await _receptionistRepository.AddAsync(receptionist);

            var result = await _userManager.CreateAsync(user, Model.Password);



            if (!result.Succeeded)
            {
                return BadRequest(440);
            }
            await _userManager.AddToRoleAsync(user, "receptionist");



            return Ok("Registered");
        }









    }








}

