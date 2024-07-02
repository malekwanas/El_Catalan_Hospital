using El_Catalan_Hospital.models.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.BLL.DTO
{
    public class AdminDto
    {
        public int Admin_ID { get; set; }
        public string User_National_ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender? Gender { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building_Number { get; set; }
        public string? BirthDate { get; set; }
        public string Phone { get; set; }
        public string UserId { get; set; }
    }
}
