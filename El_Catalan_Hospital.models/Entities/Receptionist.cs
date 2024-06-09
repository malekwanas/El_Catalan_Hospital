using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.models.Entities
{
    public class Receptionist : UserClass
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Receptionist_ID { get; set; }

        [ForeignKey("Admin")]
        public string Admin_ID { get; set; }
        public Admin Admin { get; set; }
    }
}
