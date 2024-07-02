using El_Catalan_Hospital.models.Entities;
using El_Catalan_Hospital.models.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.BLL.DTO
{
    public class DoctorRegisterDto
    {
        public int Admin_ID { get; set; }
        public string AppUserId { get; set; }

        public int SpecializationId { get; set; }
    }

}
