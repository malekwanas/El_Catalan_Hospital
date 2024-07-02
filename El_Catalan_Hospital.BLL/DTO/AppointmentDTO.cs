using El_Catalan_Hospital.models.Entities;

namespace El_Catalan_Hospital.BLL.DTO
{
    public class AppointmentDTO
    {
        public int appointmentId {  get; set; }
        public Status Status { get; set; }
        public DateTime Appointment_Date { get; set; } //Day,Month,Year,Time
        public int DoctorId { get; set; }    //FK from Doctor's table
        public int PatientId { get; set; }   //FK from Patient's table
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
    }
}
