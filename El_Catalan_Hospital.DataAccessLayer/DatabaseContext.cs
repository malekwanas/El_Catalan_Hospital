using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using El_Catalan_Hospital.models.Entities;
using El_Catalan_Hospital.models.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace El_Catalan_Hospital.DataAccessLayer
{
    public class DatabaseContext : IdentityDbContext<AppUser>
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Receptionist> Receptionist { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<WorkingSchedule> WorkingSchedule { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<WorkingSchedule>()
    .Property(w => w.Working_Schedule_Start_Time)
     .HasColumnType("time(0)"); // This ensures no seconds and milliseconds are stored

            modelBuilder.Entity<WorkingSchedule>()
                .Property(w => w.Working_Schedule_End_Time)
                .HasColumnType("time(0)");

            modelBuilder.Entity<Appointment>()
            .Property(a => a.Appointment_Date)
            .HasColumnType("datetime2(0)"); // This ensures no seconds and milliseconds are stored
            base.OnModelCreating(modelBuilder); }
        public DatabaseContext( DbContextOptions<DatabaseContext> options ) : base(options){ }
    }
}
