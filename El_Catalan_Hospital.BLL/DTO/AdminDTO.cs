using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.BLL.DTO
{
    public class AdminDTO
    {
        public int Admin_ID { get; set; }
        public string User_National_ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building_Number { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string Phone { get; set; }
    }
}
