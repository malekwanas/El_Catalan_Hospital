using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.models.Entities
{
    public class Doctor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Doctor_ID { get; set; }
        public string Doctor_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }

        [ForeignKey("Admin")]
        public string Admin_ID { get; set; }
        public Admin Admin { get; set; }
        public string SpecializationId { get; set; }    //FK from Specialization
        public Specialization Specialization { get; set; }
    }
}
