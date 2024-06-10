using El_Catalan_Hospital.models.Entities.Identity;
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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Doctor_ID { get; set; }

        [ForeignKey("Admin")]
        public int Admin_ID { get; set; }
        public Admin Admin { get; set; }
        public int SpecializationId { get; set; }    //FK from Specialization
        public Specialization Specialization { get; set; }

        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
