using El_Catalan_Hospital.models.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.BLL.Services.Contract
{
    public interface IAuthService
    {
        public Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager);
    }
}
