namespace El_Catalan_Hospital.BLL.DTO
{
    public class CreateAppointmentDTO
    {
        public DateTime Appointment_Date { get; set; } //Day, Month, Year, Time
        public int DoctorId { get; set; }    //FK from Doctor's table
    }
}
