using AutoMapper;
using El_Catalan_Hospital.API.Dtos;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.BLL.Errors;
using El_Catalan_Hospital.BLL.Services.Contract;
using El_Catalan_Hospital.DataAccessLayer.Repository.Contract;
using El_Catalan_Hospital.models.Entities.Identity;
using El_Catalan_Hospital.models.Entities;
using Microsoft.AspNetCore.Identity;
using static El_Catalan_Hospital.BLL.Errors.ErrorMsg;
using El_Catalan_Hospital.BLL.Responses;
using El_Catalan_Hospital.DataAccessLayer.Repository;

namespace El_Catalan_Hospital.BLL.Services
{
    public class ReceptionistService : IReceptionistService
    {
        private readonly IReceptionistRepo receptionistRepo;
        private readonly IMapper mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly GenericRepository<Patient> _patientRepository;
    
        public ReceptionistService(IReceptionistRepo _receptionistRepo,IMapper _mapper, RoleManager<IdentityRole> roleManager, GenericRepository<Patient> patientRepository, UserManager<AppUser> userManager)/*IPatientRepo _patientRepo*/
        {
            receptionistRepo = _receptionistRepo;
            mapper = _mapper;
            _roleManager = roleManager;
            _patientRepository = patientRepository;
            _userManager = userManager;
        }
        //------------------------------------------------------------------------------------------------------
        public async Task<ReceptionistDto> DisplayReceptionistProfileAsync(int id)
        {
            var rec = await receptionistRepo.GetReceptionistByIdAsync(id);
            if (rec == null) { return null; }

            var recDTO = mapper.Map<ReceptionistDto>(rec);
            return recDTO;
        }
        //-------------------------------------------------------------
        public async Task<ReceptionistDto> UpdateReceptionistInformation(ReceptionistDto recDTO, int id)
        {
            // Map ReceptionistDto to Receptionist entity
            var ReceptionistEntity = mapper.Map<Receptionist>(recDTO);

            var updatedReceptionist = await receptionistRepo.UpdateReceptionist(ReceptionistEntity, id);
            var updatedReceptionistDTO = mapper.Map<ReceptionistDto>(updatedReceptionist);
            return updatedReceptionistDTO;
        }
        //------------------------------------------------------------------------------------------------------
        public IEnumerable<PatientDTO> GetAllPatient()
        {
            var patients = receptionistRepo.GetAllPatients();
            var patientDTOList= mapper.Map<IEnumerable<PatientDTO>>(patients);
            return patientDTOList;

        }
        //------------------------------------------------------------------------------------------------------
        public async Task<Response> RegisterPatientAsync(RegisterDto model, int receptionistId)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model), ErrorMsg.NullModel);
                }

                if (model.Password != model.ConfirmPassword)
                {
                    return new Response
                    {
                        Message = Msg.ConfirmPasswordNotMatch,
                        isSucceeded = false,
                    };
                }

                var user = mapper.Map<AppUser>(model);

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
                var patient = mapper.Map<Patient>(patientDto);
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
    }
    //------------------------------------------------------------------------------------------------------
}
