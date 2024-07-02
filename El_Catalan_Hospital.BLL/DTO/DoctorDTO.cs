using El_Catalan_Hospital.models.Entities.Identity;

namespace El_Catalan_Hospital.BLL.DTO
{
    public class DoctorDto
    {
        public int Doctor_ID { get; set; }
        public int Admin_ID { get; set; }
        public int SpecializationId { get; set; }
        public string User_National_ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender? Gender { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building_Number { get; set; }
        public string? BirthDate { get; set; }
        public string Phone { get; set; }
        public ICollection<WorkingScheduleDTO> WorkingSchedules { get; set; } // Added working schedules
    }
}
