using AutoMapper;
using El_Catalan_Hospital.DataAccessLayer.Repository.Contract;
using El_Catalan_Hospital.models;
using El_Catalan_Hospital.models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Catalan_Hospital.DataAccessLayer.Repository
{
    public class AdminRepo : IAdminRepo
    {
        private readonly DatabaseContext db;

        public AdminRepo(DatabaseContext context)
        {
            db = context;
        }
        //-----------------------------------------------
        public IEnumerable<Admin> GetAll()
        {
            var admins = db.Admin.Include(a => a.AppUser).ToList();
            return admins;
        }
        //-----------------------------------------------

    }
}
