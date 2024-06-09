using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.models.Entities
{
    public class Specialization
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Specialization_ID { get; set; }
        public string Specialization_Name { get; set; }
        public string Specialization_Description { get; set; }
        public List<Admin> Admins { get; set; } //M-M with Admins

    }
}
