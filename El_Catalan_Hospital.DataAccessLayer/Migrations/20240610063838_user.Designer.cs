﻿// <auto-generated />
using System;
using El_Catalan_Hospital.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace El_Catalan_Hospital.DataAccessLayer.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240610063838_user")]
    partial class user
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdminSpecialization", b =>
                {
                    b.Property<int>("AdminsAdmin_ID")
                        .HasColumnType("int");

                    b.Property<int>("SpecializationsSpecialization_ID")
                        .HasColumnType("int");

                    b.HasKey("AdminsAdmin_ID", "SpecializationsSpecialization_ID");

                    b.HasIndex("SpecializationsSpecialization_ID");

                    b.ToTable("AdminSpecialization");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Admin", b =>
                {
                    b.Property<int>("Admin_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Admin_ID"));

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Admin_ID");

                    b.HasIndex("AppUserId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Appointment", b =>
                {
                    b.Property<int>("Appointment_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Appointment_ID"));

                    b.Property<DateTime>("Appointment_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Appointment_ID");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Doctor", b =>
                {
                    b.Property<int>("Doctor_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Doctor_ID"));

                    b.Property<int>("Admin_ID")
                        .HasColumnType("int");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("SpecializationId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Doctor_ID");

                    b.HasIndex("Admin_ID");

                    b.HasIndex("AppUserId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Building_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_National_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("User_National_ID")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Patient", b =>
                {
                    b.Property<int>("Patient_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Patient_ID"));

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int?>("ReceptionistID")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Patient_ID");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ReceptionistID");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Receptionist", b =>
                {
                    b.Property<int>("Receptionist_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Receptionist_ID"));

                    b.Property<int>("Admin_ID")
                        .HasColumnType("int");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Receptionist_ID");

                    b.HasIndex("Admin_ID");

                    b.HasIndex("AppUserId");

                    b.ToTable("Receptionist");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Specialization", b =>
                {
                    b.Property<int>("Specialization_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Specialization_ID"));

                    b.Property<string>("Specialization_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Specialization_ID");

                    b.ToTable("Specialization");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.WorkingSchedule", b =>
                {
                    b.Property<int>("Working_Schedule_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Working_Schedule_ID"));

                    b.Property<int>("Doctor_ID")
                        .HasColumnType("int");

                    b.Property<int>("Working_Schedule_Day")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("Working_Schedule_End_Time")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("Working_Schedule_Start_Time")
                        .HasColumnType("time");

                    b.HasKey("Working_Schedule_ID");

                    b.HasIndex("Doctor_ID");

                    b.ToTable("WorkingSchedule");
                });

            modelBuilder.Entity("AdminSpecialization", b =>
                {
                    b.HasOne("El_Catalan_Hospital.models.Entities.Admin", null)
                        .WithMany()
                        .HasForeignKey("AdminsAdmin_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("El_Catalan_Hospital.models.Entities.Specialization", null)
                        .WithMany()
                        .HasForeignKey("SpecializationsSpecialization_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Admin", b =>
                {
                    b.HasOne("El_Catalan_Hospital.models.Entities.Identity.User", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Appointment", b =>
                {
                    b.HasOne("El_Catalan_Hospital.models.Entities.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("El_Catalan_Hospital.models.Entities.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Doctor", b =>
                {
                    b.HasOne("El_Catalan_Hospital.models.Entities.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("Admin_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("El_Catalan_Hospital.models.Entities.Identity.User", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("El_Catalan_Hospital.models.Entities.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("AppUser");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Patient", b =>
                {
                    b.HasOne("El_Catalan_Hospital.models.Entities.Identity.User", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("El_Catalan_Hospital.models.Entities.Receptionist", "Receptionist")
                        .WithMany()
                        .HasForeignKey("ReceptionistID");

                    b.Navigation("AppUser");

                    b.Navigation("Receptionist");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Receptionist", b =>
                {
                    b.HasOne("El_Catalan_Hospital.models.Entities.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("Admin_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("El_Catalan_Hospital.models.Entities.Identity.User", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.WorkingSchedule", b =>
                {
                    b.HasOne("El_Catalan_Hospital.models.Entities.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("Doctor_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });
#pragma warning restore 612, 618
        }
    }
}
