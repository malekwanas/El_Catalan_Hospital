using El_Catalan_Hospital.models.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace El_Catalan_Hospital.API.Dtos
{
    public class UserToReturnDto
    {

        public string? DisplayName { get; set; }
        public Gender? Gender { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Building_Number { get; set; }

    
        public DateOnly? BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
