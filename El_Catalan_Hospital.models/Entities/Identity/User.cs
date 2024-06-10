using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace El_Catalan_Hospital.models.Entities.Identity
{
    public enum Gender { Male, Female }

    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(User_National_ID), IsUnique = true)]
    public class AppUser : IdentityUser
    {
        [Required]
        public string User_National_ID { get; set; }

        [Required]
        [EmailAddress]
        public override string Email { get; set; } // Override to apply attributes

        public string? DisplayName { get; set; }
        public Gender? Gender { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Building_Number { get; set; }
        public DateOnly? BirthDate { get; set; }
       
    }
}
