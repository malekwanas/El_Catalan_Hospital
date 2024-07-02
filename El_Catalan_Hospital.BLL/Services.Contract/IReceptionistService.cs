using El_Catalan_Hospital.API.Dtos;
using El_Catalan_Hospital.BLL.DTO;
using El_Catalan_Hospital.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.BLL.Services.Contract
{
    public interface IReceptionistService
    {
        Task<ReceptionistDto> DisplayReceptionistProfileAsync(int id);
        Task<ReceptionistDto> UpdateReceptionistInformation(ReceptionistDto recDTO, int id);
        IEnumerable<PatientDTO> GetAllPatient();
        Task<Response> RegisterPatientAsync(RegisterDto model, int receptionistId);
    }
}
