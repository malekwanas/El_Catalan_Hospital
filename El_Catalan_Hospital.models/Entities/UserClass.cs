using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace El_Catalan_Hospital.models.Entities
{
    public enum Gender { Male, Female }
    public class UserClass
    {

        [Required]
        public string User_National_ID { get; set; }     //Add unique constraint

        [Required]
        [RegularExpression(@"[a-z A-Z 0-9 _-]+@[a-z A-Z]+.[a-z  A-Z]{2,4}", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }               //Add unique constraint

        [Required]
        public string Password { get; set; }
        public Gender? Gender { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Building_Number { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        public string? Phone { get; set; }
    }
}
