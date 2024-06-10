using El_Catalan_Hospital.BLL.Services.Contract;
using El_Catalan_Hospital.models.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

            bool isAdmin = false, isDoctor = false, isReceptionist = false, isPatient = false;

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));

                switch (userRole.ToLower())
                {
                    case "admin":
                        isAdmin = true;
                        break;
                    case "doctor":
                        isDoctor = true;
                        break;
                    case "receptionist":
                        isReceptionist = true;
                        break;
                    case "patient":
                        isPatient = true;
                        break;
                }
            }

            authClaims.Add(new Claim("IsAdmin", isAdmin.ToString().ToLower()));
            authClaims.Add(new Claim("IsDoctor", isDoctor.ToString().ToLower()));
            authClaims.Add(new Claim("IsReceptionist", isReceptionist.ToString().ToLower()));
            authClaims.Add(new Claim("IsPatient", isPatient.ToString().ToLower()));

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

            var token = new JwtSecurityToken(

                audience: _configuration["JWT:ValidAudiance"],
                issuer: _configuration["JWT:ValidIssuer"],
                expires: DateTime.UtcNow.AddDays(1),
                claims: authClaims,

                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
                );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
