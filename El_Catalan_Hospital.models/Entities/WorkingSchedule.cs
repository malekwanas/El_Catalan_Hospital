using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.models.Entities
{
    public class WorkingSchedule
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Working_Schedule_ID { get; set; }
        public TimeOnly Working_Schedule_Time { get; set; }
        public DateOnly Working_Schedule_Date { get; set; } //Day,Month,Year

        [ForeignKey("Doctor")]
        public string Doctor_ID { get; set; }
        public Doctor Doctor { get; set; }

    }
}
