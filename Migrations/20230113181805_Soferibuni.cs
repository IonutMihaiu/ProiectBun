using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectBun.Migrations
{
    public partial class Soferibuni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoferFirstName",
                table: "Sofer");

            migrationBuilder.RenameColumn(
                name: "SoferLastName",
                table: "Sofer",
                newName: "SoferName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SoferName",
                table: "Sofer",
                newName: "SoferLastName");

            migrationBuilder.AddColumn<string>(
                name: "SoferFirstName",
                table: "Sofer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
