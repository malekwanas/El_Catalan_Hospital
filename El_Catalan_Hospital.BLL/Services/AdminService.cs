using AutoMapper;
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
using static El_Catalan_Hospital.BLL.Errors.ErrorMsg;

namespace El_Catalan_Hospital.BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepo adminRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IGenericRepository<Receptionist> _receptionistRepo;
        private readonly IGenericRepository<Doctor> _doctorRepo;

        public AdminService(IAdminRepo _adminRepo, IMapper mapper, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager , IGenericRepository<Receptionist> receptionistRepo, IGenericRepository<Doctor> doctorRepo) 
        {
            adminRepo = _adminRepo;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _receptionistRepo = receptionistRepo;
            _doctorRepo = doctorRepo;
        }
        //---------------------------------------------------------------
        public async Task<AdminDto> DisplayAdminProfileAsync(int id)
        {
            var adn = await adminRepo.GetAdminByIdAsync(id);
            if (adn == null) { return null; }

            var adnDTO = _mapper.Map<AdminDto>(adn);
            return adnDTO;
        }
        //---------------------------------------------------------------------ADMINS CRUD-----------------------------------------
        public IEnumerable<AdminDto> GetAllAdmins()
        {
            var admins= adminRepo.GetAllAdmins();
            var adminDTOList = _mapper.Map<IEnumerable<AdminDto>>(admins);
            return adminDTOList;
        }
        //---------------------------------------------------------------------
        public AdminDto GetSpecificAdmin(int id)
        {
            var admin = adminRepo.GetAdminById(id);
            var adminDTO = _mapper.Map<AdminDto>(admin);
            return adminDTO;
        }
        //---------------------------------------------------------------------
        public AdminDto UpdateAdminInformation(AdminDto adminDTO, int id)
        {
            // Map AdminDTO to Admin entity
            var adminEntity = _mapper.Map<Admin>(adminDTO);
            var updatedAdmin = adminRepo.UpdateAdmin(adminEntity, id);
            var updatedAdminDTO = _mapper.Map<AdminDto>(updatedAdmin);
            return updatedAdminDTO;
        }
        //---------------------------------------------------------------------
        public AdminDto DeleteAdminById(int id)
        {
            var adn = adminRepo.DeleteAdmin(id);
            var adnDTO = _mapper.Map<AdminDto>(adn);
            return adnDTO;
        }
        //---------------------------------------------------------------------
        public async Task<AdminDto> AddAsynchronous(AdminDto adnDTO)
        {
            var AdminEntity = _mapper.Map<Admin>(adnDTO);
            var addedAdmin = await adminRepo.AddAsync(AdminEntity);
            var addedAdminDTO = _mapper.Map<AdminDto>(addedAdmin);
            return addedAdminDTO;
        }
        public AdminDto GetAdminByUserId(string userId)
        {
            var admin = adminRepo.GetAdminByUserId(userId);
            var adminDTO = _mapper.Map<AdminDto>(admin);
            return adminDTO;

        }
        //---------------------------------------------------------------------DOCTORS CRUD---------------------------------------------
        public IEnumerable<DoctorDto> GetAllDoctors()
        {
            var doctors = adminRepo.GetAllDoctors();
            var DoctorsDTOList = _mapper.Map<IEnumerable<DoctorDto>>(doctors);
            return DoctorsDTOList;
        }
        //---------------------------------------------------------------------
        public IEnumerable<DoctorDto> GetAllDoctorsBySpec(int spec_id)
        {
            var doctors = adminRepo.GetAllDoctorsBySpecialization(spec_id);
            var DoctorsDTOList = _mapper.Map<IEnumerable<DoctorDto>>(doctors);
            return DoctorsDTOList;
        }
        //---------------------------------------------------------------------
        public DoctorDto GetSpecificDoctor(int id)
        {
            var doctor = adminRepo.GetDoctorById(id);
            var doctorDTO = _mapper.Map<DoctorDto>(doctor);
            return doctorDTO;
        }
        //---------------------------------------------------------------------
        public DoctorDto UpdateDoctorInformation(DoctorDto doctorDTO, int id)
        {
            // Map DoctorDTO to Doctor entity
            var DoctorEntity = _mapper.Map<Doctor>(doctorDTO);
            var updatedDoctor = adminRepo.UpdateDoctor(DoctorEntity, id);
            var updatedDoctorDTO = _mapper.Map<DoctorDto>(updatedDoctor);
            return updatedDoctorDTO;
        }
        //---------------------------------------------------------------------
        public DoctorDto DeleteDoctorById(int id)
        {
            var dr = adminRepo.DeleteDoctor(id);
            var drDTO = _mapper.Map<DoctorDto>(dr);
            return drDTO;
        }

        public DoctorDto GetDoctorByUserId(string userId)
        {
            var doctor = adminRepo.GetDoctorByUserId(userId);
            var doctorDto = _mapper.Map<DoctorDto>(doctor);
            return doctorDto;

        }
        //----------------------------------------------------------------------Receptionist CRUD-----------------------------------------------
        public IEnumerable<ReceptionistDto> GetAllReceptionists()
        {
            var receptionists = adminRepo.GetAllReceptionists();
            var receptionistsDTO = _mapper.Map<IEnumerable<ReceptionistDto>>(receptionists);
            return receptionistsDTO;
        }
        //---------------------------------------------------------------------
        public ReceptionistDto GetSpecificReceptionist(int id)
        {
            var receptionist = adminRepo.GetReceptionistById(id);
            var receptionistDTO = _mapper.Map<ReceptionistDto>(receptionist);
            return receptionistDTO;
        }
        //---------------------------------------------------------------------
        public ReceptionistDto UpdateReceptionistInformation(ReceptionistDto receptionistDTO, int id)
        {
            // Map ReceptionistDTO to Receptionist entity
            var ReceptionistEntity = _mapper.Map<Receptionist>(receptionistDTO);
            var updatedReceptionist = adminRepo.UpdateReceptionist(ReceptionistEntity, id);
            var updatedReceptionistDTO = _mapper.Map<ReceptionistDto>(updatedReceptionist);
            return updatedReceptionistDTO;
        }
        //---------------------------------------------------------------------
        public ReceptionistDto DeleteReceptionistById(int id)
        {
            var Receptionist = adminRepo.DeleteReceptionist(id);
            var ReceptionistDTO = _mapper.Map<ReceptionistDto>(Receptionist);
            return ReceptionistDTO;
        }

        public ReceptionistDto GetReceptionistByUserId(string userId)
        {
            var receptionist = adminRepo.GetReceptionistByUserId(userId);
            var receptionistDto = _mapper.Map<ReceptionistDto>(receptionist);
            return receptionistDto;

        }
        //---------------------------------------------------------------------
        //---------------------------------------------------------------------Specializations CRUD-----------------------------------------------
        public IEnumerable<SpecializationDTO> GetAllSpecializations()
        {
            IEnumerable<Specialization> Specializations = adminRepo.GetAllSpecializations();
            var SpecializationsDTO = _mapper.Map<IEnumerable<SpecializationDTO>>(Specializations);
            return SpecializationsDTO;
        }
        //---------------------------------------------------------------------
        public SpecializationDTO UpdateSpecializationInformation(SpecializationDTO specializationDTO, int id)
        {
            var SpecializationEntity = _mapper.Map<Specialization>(specializationDTO);
            var updatedSpecialization = adminRepo.UpdateSpecialization(SpecializationEntity, id);
            var updatedSpecializationDTO = _mapper.Map<SpecializationDTO>(updatedSpecialization);
            return updatedSpecializationDTO;
        }
        //---------------------------------------------------------------------
        public SpecializationDTO AddSpecialization(SpecializationDTO specializationDTO)
        {
            var specializationEntity = _mapper.Map<Specialization>(specializationDTO);
            var addedSpecialization = adminRepo.AddSpecialization(specializationEntity);
            var addedSpecializationDTO = _mapper.Map<SpecializationDTO>(addedSpecialization);
            return addedSpecializationDTO;
        }
        //---------------------------------------------------------------------
        public SpecializationDTO DeleteSpecializationById(int id)
        {
            var spec = adminRepo.DeleteSpecialization(id);
            var specDTO = _mapper.Map<SpecializationDTO>(spec);
            return specDTO;
        }
        //--------------------------------------------------------------------- Register Admin Async -----------------------//
        public async Task<Response> RegisterAdminAsync(RegisterDto model)
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

                var existingUser = await _userManager.FindByEmailAsync(model.Email);
                if (existingUser != null)
                {
                    return new Response
                    {
                        Message = "User already exists",
                        isSucceeded = false,
                        Errors = new[] { "User with this email already exists." }
                    };
                }

                var user = _mapper.Map<AppUser>(model);
                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    return new Response
                    {
                        Message = "Admin registration failed",
                        isSucceeded = false,
                        Errors = result.Errors.Select(e => e.Description)
                    };
                }

                if (!await _roleManager.RoleExistsAsync("admin"))
                {
                    var role = new IdentityRole("admin");
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

                var roleAssignResult = await _userManager.AddToRoleAsync(user, "admin");
                if (!roleAssignResult.Succeeded)
                {
                    return new Response
                    {
                        Message = "Adding admin role failed",
                        isSucceeded = false,
                        Errors = roleAssignResult.Errors.Select(e => e.Description)
                    };
                }

                var adminDto = new AdminRegisterDto { AppUserId = user.Id };
                var admin = _mapper.Map<Admin>(adminDto);
                await adminRepo.AddAsync(admin);

                return new Response
                {
                    Message = "Admin registered successfully",
                    isSucceeded = true
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

        //-------------------------------------- register receptionist---------------------
        public async Task<Response> RegisterReceptionistAsync(RegisterDto model, int AdminId)
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

                if (!await _roleManager.RoleExistsAsync("receptionist"))
                {
                    var role = new IdentityRole("receptionist");
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

                var roleAssignResult = await _userManager.AddToRoleAsync(user, "receptionist");
                if (!roleAssignResult.Succeeded)
                {
                    return new Response
                    {
                        Message = "Adding receptionist role failed",
                        isSucceeded = false,
                        Errors = roleAssignResult.Errors.Select(e => e.Description)
                    };
                }

                var receptionistDto = new ReceptionistRegisterDto { AppUserId = user.Id, Adminid = AdminId };
                var receptionist = _mapper.Map<Receptionist>(receptionistDto);
                await _receptionistRepo.AddAsync(receptionist);

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

        //-------------------------------------- Register Doctor----------------------
        public async Task<Response> RegisterDoctorAsync(RegisterDto model, int AdminId , int specializationId)
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

                if (!await _roleManager.RoleExistsAsync("doctor"))
                {
                    var role = new IdentityRole("doctor");
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

                var roleAssignResult = await _userManager.AddToRoleAsync(user, "doctor");
                if (!roleAssignResult.Succeeded)
                {
                    return new Response
                    {
                        Message = "Adding doctor role failed",
                        isSucceeded = false,
                        Errors = roleAssignResult.Errors.Select(e => e.Description)
                    };
                }

                var doctorDto = new DoctorRegisterDto { AppUserId = user.Id, Admin_ID = AdminId , SpecializationId = specializationId };
                var doctor = _mapper.Map<Doctor>(doctorDto);
                await _doctorRepo.AddAsync(doctor);

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

       
    }
}
