using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace El_Catalan_Hospital.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Receptionist_Email",
                table: "Receptionist");

            migrationBuilder.DropIndex(
                name: "IX_Receptionist_User_National_ID",
                table: "Receptionist");

            migrationBuilder.DropIndex(
                name: "IX_Patient_Email",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_User_National_ID",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_Email",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_User_National_ID",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Admin_Email",
                table: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Admin_User_National_ID",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "Building_Number",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "User_National_ID",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Building_Number",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "User_National_ID",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Building_Number",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "User_National_ID",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Building_Number",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "User_National_ID",
                table: "Admin");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Receptionist",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Patient",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Doctor",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Admin",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Receptionist",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Doctor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Admin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_National_ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Building_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receptionist_AppUserId",
                table: "Receptionist",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_AppUserId",
                table: "Patient",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_AppUserId",
                table: "Doctor",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_AppUserId",
                table: "Admin",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_User_National_ID",
                table: "User",
                column: "User_National_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_User_AppUserId",
                table: "Admin",
                column: "AppUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_User_AppUserId",
                table: "Doctor",
                column: "AppUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_User_AppUserId",
                table: "Patient",
                column: "AppUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Receptionist_User_AppUserId",
                table: "Receptionist",
                column: "AppUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_User_AppUserId",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_User_AppUserId",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_User_AppUserId",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Receptionist_User_AppUserId",
                table: "Receptionist");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Receptionist_AppUserId",
                table: "Receptionist");

            migrationBuilder.DropIndex(
                name: "IX_Patient_AppUserId",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_AppUserId",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Admin_AppUserId",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Admin");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Receptionist",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Patient",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Doctor",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Admin",
                newName: "Password");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Receptionist",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Building_Number",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Receptionist",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Receptionist",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_National_ID",
                table: "Receptionist",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Patient",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Building_Number",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Patient",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Patient",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_National_ID",
                table: "Patient",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Doctor",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Building_Number",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Doctor",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Doctor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_National_ID",
                table: "Doctor",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Admin",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Building_Number",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Admin",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Admin",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_National_ID",
                table: "Admin",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Receptionist_Email",
                table: "Receptionist",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receptionist_User_National_ID",
                table: "Receptionist",
                column: "User_National_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Email",
                table: "Patient",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_User_National_ID",
                table: "Patient",
                column: "User_National_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Email",
                table: "Doctor",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_User_National_ID",
                table: "Doctor",
                column: "User_National_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Email",
                table: "Admin",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admin_User_National_ID",
                table: "Admin",
                column: "User_National_ID",
                unique: true);
        }
    }
}
