using El_Catalan_Hospital.BLL.Services.Contract;
using El_Catalan_Hospital.models.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager)
        {
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.DisplayName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("UserId", user.Id.ToString())
            };

            var userRoles = await userManager.GetRolesAsync(user);

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));

                // Adding specific claims for each role
                if (userRole.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    authClaims.Add(new Claim("IsAdmin", "true"));
                }
                else if (userRole.Equals("doctor", StringComparison.OrdinalIgnoreCase))
                {
                    authClaims.Add(new Claim("IsDoctor", "true"));
                }
                else if (userRole.Equals("receptionist", StringComparison.OrdinalIgnoreCase))
                {
                    authClaims.Add(new Claim("IsReceptionist", "true"));
                }
                else if (userRole.Equals("patient", StringComparison.OrdinalIgnoreCase))
                {
                    authClaims.Add(new Claim("IsPatient", "true"));
                }
            }

            // Adding false claims for roles not assigned
            if (!userRoles.Contains("admin"))
            {
                authClaims.Add(new Claim("IsAdmin", "false"));
            }
            if (!userRoles.Contains("doctor"))
            {
                authClaims.Add(new Claim("IsDoctor", "false"));
            }
            if (!userRoles.Contains("receptionist"))
            {
                authClaims.Add(new Claim("IsReceptionist", "false"));
            }
            if (!userRoles.Contains("patient"))
            {
                authClaims.Add(new Claim("IsPatient", "false"));
            }

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

            var token = new JwtSecurityToken(
                audience: _configuration["JWT:ValidAudience"],
                issuer: _configuration["JWT:ValidIssuer"],
                expires: DateTime.UtcNow.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
