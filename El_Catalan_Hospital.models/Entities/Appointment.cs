using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.models.Entities
{
    public enum Status { Pending, Approved, Canceled , Missed }
    public class Appointment
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short Appointment_ID { get; set; }
        public Status Status { get; set; }
        public TimeOnly Working_Schedule_Time { get; set; }
        public DateOnly Working_Schedule_Date { get; set; } //Day,Month,Year
        public string DoctorId { get; set; }    //FK from Doctor's table
        public Doctor Doctor { get; set; }
        public string PatientId { get; set; }   //FK from Patient's table
        public Patient Patient { get; set; }

    }
}
