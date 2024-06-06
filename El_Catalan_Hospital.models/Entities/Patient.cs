using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.models.Entities
{
    public enum Gender { Male,Female }
    public class Patient
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Patient_ID { get; set; }
        public string Patient_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string ReceptionistId { get; set; }  //FK from Receptionist class
        public Receptionist Receptionist { get; set; }

    }
}
