using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.models.Entities
{
    public class WorkingSchedule : BaseEntity
    {
        public TimeOnly Working_Schedule_Start_Time { get; set; }
        public TimeOnly Working_Schedule_End_Time { get; set; }
        public DayOfWeek Working_Schedule_Day { get; set; }  //Day ONLY

        [ForeignKey("Doctor")]
        public int Doctor_ID { get; set; }
        public Doctor Doctor { get; set; }
    }
}
