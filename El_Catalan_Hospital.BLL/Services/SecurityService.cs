using El_Catalan_Hospital.BLL.Services.Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.BLL.BusinessLoginLayer.Contract
{
    public class SecurityService : ISecurityService
    {
        private readonly IConfiguration _configuration;

        public SecurityService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void SecureToken(List<Claim> claims, out JwtSecurityToken token, out string tokenString)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]);
            var symmetricSecurityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["JWT:Duration"])),
                signingCredentials: credentials
            );

            tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        }
    }


}