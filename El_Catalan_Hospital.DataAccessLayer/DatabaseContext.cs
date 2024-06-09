using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using El_Catalan_Hospital.models.Entities;


namespace El_Catalan_Hospital.DataAccessLayer
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Receptionist> Receptionist { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<WorkingSchedule> WorkingSchedule { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
