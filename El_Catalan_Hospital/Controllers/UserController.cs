using AutoMapper;
using El_Catalan_Hospital.API.Dtos;
using El_Catalan_Hospital.API.Repository.Contract;
using El_Catalan_Hospital.models.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace El_Catalan_Hospital.API.Controllers
{

    public class UserController : BaseController
    {
        private readonly IGenericRepositoryUser<AppUser> userRepository;
        private readonly IMapper mapper;

        public UserController(
           IGenericRepositoryUser<AppUser> userRepository,
            IMapper mapper
            )
        {
           this.userRepository = userRepository;
            this.mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(string id)
        {

            var user = await userRepository.GetAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<AppUser, UserDto>(user));
        }



        [HttpPatch("{id}")]
        public async Task<ActionResult<UserToReturnDto>> UpdateUser(string id, UserToReturnDto updatedUserDto)
        {
            if (id is null)
                return BadRequest(new { Message = "Invalid user ID", StatusCode = "400" });

            var existingUser = await userRepository.GetAsync(id);
            if (existingUser == null)
                return NotFound(new { Message = "User not found", StatusCode = "404" });

            existingUser.DisplayName = updatedUserDto.DisplayName;
            existingUser.PhoneNumber= updatedUserDto.PhoneNumber;
            existingUser.Gender = updatedUserDto.Gender;
            existingUser.City = updatedUserDto.City;
            existingUser.Street = updatedUserDto.Street;
            existingUser.Building_Number = updatedUserDto.Building_Number;
            existingUser.BirthDate = updatedUserDto.BirthDate;

            await userRepository.SaveChanges();
           
            var updatedDto = mapper.Map<AppUser, UserToReturnDto>(existingUser);
            return updatedDto;
        }



    
}
}
