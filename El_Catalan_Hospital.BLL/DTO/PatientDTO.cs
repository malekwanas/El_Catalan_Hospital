using El_Catalan_Hospital.models.Entities.Identity;

namespace El_Catalan_Hospital.BLL.DTO
{
    public class PatientDTO
    {
        public int Patient_ID { get; set; }
        public int ReceptionistID { get; set; }
        public string User_National_ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building_Number { get; set; }
        public string? BirthDate { get; set; }
        public string Phone { get; set; }
        public string UserId { get; set; }
    }
}
