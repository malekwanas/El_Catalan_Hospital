using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.models.Entities
{
    public enum Status { Pending, Visited, Canceled , Missed }
    public class Appointment: BaseEntity
    { 
        public Status Status { get; set; }
        public DateTime Appointment_Date { get; set; } //Day,Month,Year,Time
        public int DoctorId { get; set; }    //FK from Doctor's table
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }   //FK from Patient's table
        public Patient Patient { get; set; }
    }
}
