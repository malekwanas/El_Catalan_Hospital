using El_Catalan_Hospital.API.Dtos;
using El_Catalan_Hospital.BLL.Responses;

namespace El_Catalan_Hospital.BLL.Services.Contract
{
    public interface IAuthService
    {
        Task<Response> RegisterPatientAsync(RegisterDto model);
        Task<Response> LoginUserAsync(LoginDto model);
    }
}
