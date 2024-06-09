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
    [Migration("20240609090502_first")]
    partial class first
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
                    b.Property<string>("AdminsAdmin_ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SpecializationsSpecialization_ID")
                        .HasColumnType("int");

                    b.HasKey("AdminsAdmin_ID", "SpecializationsSpecialization_ID");

                    b.HasIndex("SpecializationsSpecialization_ID");

                    b.ToTable("AdminSpecialization");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Admin", b =>
                {
                    b.Property<string>("Admin_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Building_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_National_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Admin_ID");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Appointment", b =>
                {
                    b.Property<short>("Appointment_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Appointment_ID"));

                    b.Property<DateTime>("Appointment_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DoctorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PatientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Patient_ID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Appointment_ID");

                    b.HasIndex("DoctorId");

                    b.HasIndex("Patient_ID");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Doctor", b =>
                {
                    b.Property<string>("Doctor_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Admin_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Building_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecializationId")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_National_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Doctor_ID");

                    b.HasIndex("Admin_ID");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Patient", b =>
                {
                    b.Property<int>("Patient_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Patient_ID"));

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Building_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Receptionist_ID")
                        .HasColumnType("int");

                    b.Property<int>("Receptionist_ID1")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_National_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Patient_ID");

                    b.HasIndex("Receptionist_ID1");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Receptionist", b =>
                {
                    b.Property<int>("Receptionist_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Receptionist_ID"));

                    b.Property<string>("Admin_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Building_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_National_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Receptionist_ID");

                    b.HasIndex("Admin_ID");

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

                    b.Property<string>("Doctor_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Appointment", b =>
                {
                    b.HasOne("El_Catalan_Hospital.models.Entities.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("El_Catalan_Hospital.models.Entities.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("Patient_ID")
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

                    b.HasOne("El_Catalan_Hospital.models.Entities.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Patient", b =>
                {
                    b.HasOne("El_Catalan_Hospital.models.Entities.Receptionist", "Receptionist")
                        .WithMany()
                        .HasForeignKey("Receptionist_ID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receptionist");
                });

            modelBuilder.Entity("El_Catalan_Hospital.models.Entities.Receptionist", b =>
                {
                    b.HasOne("El_Catalan_Hospital.models.Entities.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("Admin_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
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