using System.ComponentModel.DataAnnotations;

namespace El_Catalan_Hospital.API.Dtos
{
    public class RegisterDoctorDto
    {
        [Required]
        public string User_National_ID { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"
,
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, one special character, and be at least 8 characters long.")]
        public string Password { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public int Specializationid { get; set;}

        public int Adminid { get; set; }


    }
}
