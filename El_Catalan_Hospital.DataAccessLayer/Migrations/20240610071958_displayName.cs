using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace El_Catalan_Hospital.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class displayName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "AppUser");
        }
    }
}
