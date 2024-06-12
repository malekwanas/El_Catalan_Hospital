using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using El_Catalan_Hospital.models;
using El_Catalan_Hospital.models.Entities;

namespace El_Catalan_Hospital.DataAccessLayer.Repository.Contract
{
    public interface IAdminRepo
    {
        IEnumerable<Admin> GetAll();      
        //Admin GetAdminById(int id);
        //void Add(Admin adn);
        //void Update(Admin adn);
        //void Delete(int id);
    }
}
