using El_Catalan_Hospital.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.BLL.Services.Contract
{
    public interface IAdminService
    {
       IEnumerable<AdminDTO> GetAllAdmins();
    }
}
