using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.BLL.Services.Contract
{
    public interface ISecurityService
    {
        void SecureToken(List<Claim> claim, out JwtSecurityToken token, out string TokenString);
    }
}
