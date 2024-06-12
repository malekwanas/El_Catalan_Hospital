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
    public class Admin 
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]   //ID is National ID
        public int Admin_ID { get; set; }
        public List<Specialization> Specializations { get; set; }   //M-M table
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
