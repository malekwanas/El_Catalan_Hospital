using AutoMapper;
using Azure;
using El_Catalan_Hospital.API.Dtos;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.BLL.Errors;
using El_Catalan_Hospital.BLL.Responses;
using El_Catalan_Hospital.BLL.Services.Contract;
using El_Catalan_Hospital.DataAccessLayer.Repository;
using El_Catalan_Hospital.DataAccessLayer.Repository.Contract;
using El_Catalan_Hospital.models.Entities;
using El_Catalan_Hospital.models.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static El_Catalan_Hospital.BLL.Errors.ErrorMsg;
using Response = El_Catalan_Hospital.BLL.Responses.Response;


namespace El_Catalan_Hospital.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly GenericRepository<Patient> _patientRepository;
        private readonly ISecurityService _securityService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        //private readonly IAdminRepo _adminRepo;
        private readonly IAdminRepo _adminRepo;


        public AuthService(
            UserManager<AppUser> userManager,
            ISecurityService securityService,
            IMapper mapper,
            RoleManager<IdentityRole> roleManager,
            GenericRepository<Patient> patientRepository,
               IAdminRepo adminRepo
           )
        {
            _userManager = userManager;
            _securityService = securityService;
            _mapper = mapper;
            _roleManager = roleManager;
            _patientRepository = patientRepository;
            //_adminRepo = adminRepo;
            _adminRepo = adminRepo;


        }

        public async Task<Response> RegisterPatientAsync(RegisterDto model, int? receptionistId)
        {
            try
            {
                if (model == null)
                {
                    throw new NullReferenceException(ErrorMsg.NullModel);
                }

                if (model.Password != model.ConfirmPassword)
                {
                    return new Response
                    {
                        Message = Msg.ConfirmPasswordNotMatch,
                        isSucceeded = false,
                    };
                }

                var user = _mapper.Map<AppUser>(model);

                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    return new Response
                    {
                        Message = "Registration failed",
                        isSucceeded = false,
                        Errors = result.Errors.Select(e => e.Description)
                    };
                }

                if (!await _roleManager.RoleExistsAsync("patient"))
                {
                    var role = new IdentityRole("patient");
                    var roleResult = await _roleManager.CreateAsync(role);
                    if (!roleResult.Succeeded)
                    {
                        return new Response
                        {
                            Message = "Role creation failed",
                            isSucceeded = false,
                            Errors = roleResult.Errors.Select(e => e.Description)
                        };
                    }
                }

                var roleAssignResult = await _userManager.AddToRoleAsync(user, "patient");
                if (!roleAssignResult.Succeeded)
                {
                    return new Response
                    {
                        Message = "Adding patient role failed",
                        isSucceeded = false,
                        Errors = roleAssignResult.Errors.Select(e => e.Description)
                    };
                }

                var patientDto = new PatientRegisterDto { AppUserId = user.Id, ReceptionistID = receptionistId };
                var patient = _mapper.Map<Patient>(patientDto);
                await _patientRepository.AddAsync(patient);

                return new Response
                {
                    Message = "Registered successfully",
                    isSucceeded = true,
                };


            }

            catch (Exception ex)
            {
                return new Response
                {
                    Message = ex.Message,
                    isSucceeded = false,
                    Errors = new[] { ex.InnerException?.Message ?? ex.Message }
                };
            }
        }



        public async Task<Response> LoginUserAsync(LoginDto model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return new Response { Message = ErrorMsg.NoUserEmail, isSucceeded = false };
                }

                var result = await _userManager.CheckPasswordAsync(user, model.Password);
                if (!result)
                {
                    return new Response { Message = ErrorMsg.InvalidPassword, isSucceeded = false };
                }

                var claims = new List<Claim>
            {
                new Claim("Email", model.Email),
                new Claim("UserId", user.Id),
                new Claim("UserName", user.UserName)
            };

                var userRoles = await _userManager.GetRolesAsync(user);
                var admin = _adminRepo.GetAdminByUserId(user.Id);
                var receptionist = _adminRepo.GetReceptionistByUserId(user.Id);
                var doctor = _adminRepo.GetDoctorByUserId(user.Id);

                foreach (var role in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                    if (role == "patient")
                    {
                        claims.Add(new Claim("IsPatient", "true"));
                    }
                    else if (role == "admin")
                    {
                        claims.Add(new Claim("Id", admin.Id.ToString()));
                    }
                    else if (role == "receptionist")
                    {
                        claims.Add(new Claim("Id", receptionist.Id.ToString()));
                    }
                    else if (role == "doctor")
                    {
                        claims.Add(new Claim("Id", doctor.Id.ToString()));
                    }
                }

                _securityService.SecureToken(claims, out JwtSecurityToken token, out string tokenString);
                return new Response
                {
                    Message = tokenString,
                    isSucceeded = true,
                    ExpireDate = token.ValidTo
                };
            }
            catch (Exception ex)
            {
                return new Response { Message = ex.Message, isSucceeded = false };
            }
        }
    }
    }
