using System.ComponentModel.DataAnnotations;

namespace El_Catalan_Hospital.API.Dtos
{
    public class ReceptionistRegisterDto
    {
        public string AppUserId { get; set; }
        public int Adminid { get; set; }
    }
}
