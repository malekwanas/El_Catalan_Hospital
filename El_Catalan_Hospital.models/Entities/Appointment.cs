namespace El_Catalan_Hospital.models.Entities
{
    public enum Status { Pending, Visited, Canceled , Missed }
    public class Appointment: BaseEntity
    { 
        public Status Status { get; set; }
        public DateTime Appointment_Date { get; set; } //Day,Month,Year,Time
        public int DoctorId { get; set; }    //FK from Doctor's table
        public Doctor? Doctor { get; set; }
        public int PatientId { get; set; }   //FK from Patient's table
        public Patient? Patient { get; set; }
    }
}
