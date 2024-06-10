using El_Catalan_Hospital.API.Dtos;
using El_Catalan_Hospital.BLL.Services.Contract;
using El_Catalan_Hospital.models.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace El_Catalan_Hospital.API.Controllers
{
   
    public class AccountController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthService _authService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAuthService authService, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
            _roleManager = roleManager;
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
                PhoneNumber = Model.Phone
       
            };

            if (!await _roleManager.RoleExistsAsync("patient"))
            {
                var role = new IdentityRole();
                role.Name = "patient";
                await _roleManager.CreateAsync(role);
            }

            var result = await _userManager.CreateAsync(user, Model.Password);


            if (!result.Succeeded)
            {
                return BadRequest(440);
            }
            await _userManager.AddToRoleAsync(user, "patient");

            var token = await _authService.CreateTokenAsync(user, _userManager);

            return Ok(token);
        }

    }
}

