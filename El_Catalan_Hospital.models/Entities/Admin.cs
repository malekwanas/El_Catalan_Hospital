using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.models.Entities
{
    public class Admin
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]   //ID is National ID
        public string Admin_ID { get; set; }
        public string Admin_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public List<Specialization> Specializations { get; set; }
    }
}
