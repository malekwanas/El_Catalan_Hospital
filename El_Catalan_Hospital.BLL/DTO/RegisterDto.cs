using El_Catalan_Hospital.models.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace El_Catalan_Hospital.API.Dtos
{

    public class EnumValidationAttribute : ValidationAttribute
    {
        private readonly Type _enumType;

        public EnumValidationAttribute(Type enumType)
        {
            _enumType = enumType;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (value is string stringValue)
            {
                return Enum.TryParse(_enumType, stringValue, true, out _);
            }

            return Enum.IsDefined(_enumType, value);
        }
    }

    public class RegisterDto


    {
        [Required]
        public string User_National_ID { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"
,
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, one special character, and be at least 8 characters long.")]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }


        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]

        [EnumValidation(typeof(Gender), ErrorMessage = "Invalid gender value.")]
        public Gender Gender { get; set; }


        [Required]
        public DateTime BirthDate { get; set; }


       

}
}
