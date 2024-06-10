using System.ComponentModel.DataAnnotations;

namespace El_Catalan_Hospital.API.Dtos
{
    public class LoginDto
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
