using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace El_Catalan_Hospital.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Admin_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User_National_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Building_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Admin_ID);
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    Specialization_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specialization_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization_Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.Specialization_ID);
                });

            migrationBuilder.CreateTable(
                name: "Receptionist",
                columns: table => new
                {
                    Receptionist_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admin_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User_National_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Building_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionist", x => x.Receptionist_ID);
                    table.ForeignKey(
                        name: "FK_Receptionist_Admin_Admin_ID",
                        column: x => x.Admin_ID,
                        principalTable: "Admin",
                        principalColumn: "Admin_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminSpecialization",
                columns: table => new
                {
                    AdminsAdmin_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SpecializationsSpecialization_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminSpecialization", x => new { x.AdminsAdmin_ID, x.SpecializationsSpecialization_ID });
                    table.ForeignKey(
                        name: "FK_AdminSpecialization_Admin_AdminsAdmin_ID",
                        column: x => x.AdminsAdmin_ID,
                        principalTable: "Admin",
                        principalColumn: "Admin_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminSpecialization_Specialization_SpecializationsSpecialization_ID",
                        column: x => x.SpecializationsSpecialization_ID,
                        principalTable: "Specialization",
                        principalColumn: "Specialization_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Doctor_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Admin_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SpecializationId = table.Column<int>(type: "int", nullable: false),
                    User_National_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Building_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Doctor_ID);
                    table.ForeignKey(
                        name: "FK_Doctor_Admin_Admin_ID",
                        column: x => x.Admin_ID,
                        principalTable: "Admin",
                        principalColumn: "Admin_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctor_Specialization_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specialization",
                        principalColumn: "Specialization_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Patient_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Receptionist_ID = table.Column<int>(type: "int", nullable: true),
                    Receptionist_ID1 = table.Column<int>(type: "int", nullable: false),
                    User_National_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Building_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Patient_ID);
                    table.ForeignKey(
                        name: "FK_Patient_Receptionist_Receptionist_ID1",
                        column: x => x.Receptionist_ID1,
                        principalTable: "Receptionist",
                        principalColumn: "Receptionist_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingSchedule",
                columns: table => new
                {
                    Working_Schedule_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Working_Schedule_Start_Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Working_Schedule_End_Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    Working_Schedule_Day = table.Column<int>(type: "int", nullable: false),
                    Doctor_ID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingSchedule", x => x.Working_Schedule_ID);
                    table.ForeignKey(
                        name: "FK_WorkingSchedule_Doctor_Doctor_ID",
                        column: x => x.Doctor_ID,
                        principalTable: "Doctor",
                        principalColumn: "Doctor_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Appointment_ID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Appointment_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patient_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Appointment_ID);
                    table.ForeignKey(
                        name: "FK_Appointment_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Doctor_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_Patient_ID",
                        column: x => x.Patient_ID,
                        principalTable: "Patient",
                        principalColumn: "Patient_ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminSpecialization_SpecializationsSpecialization_ID",
                table: "AdminSpecialization",
                column: "SpecializationsSpecialization_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorId",
                table: "Appointment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Patient_ID",
                table: "Appointment",
                column: "Patient_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Admin_ID",
                table: "Doctor",
                column: "Admin_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_SpecializationId",
                table: "Doctor",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Receptionist_ID1",
                table: "Patient",
                column: "Receptionist_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_Receptionist_Admin_ID",
                table: "Receptionist",
                column: "Admin_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSchedule_Doctor_ID",
                table: "WorkingSchedule",
                column: "Doctor_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminSpecialization");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "WorkingSchedule");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Receptionist");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "Admin");
        }
    }
}
