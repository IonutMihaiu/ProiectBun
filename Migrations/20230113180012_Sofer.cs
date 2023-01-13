using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectBun.Migrations
{
    public partial class Sofer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sofer",
                table: "Utilaj");

            migrationBuilder.AddColumn<int>(
                name: "SoferID",
                table: "Utilaj",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sofer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoferFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoferLastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sofer", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utilaj_SoferID",
                table: "Utilaj",
                column: "SoferID");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilaj_Sofer_SoferID",
                table: "Utilaj",
                column: "SoferID",
                principalTable: "Sofer",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilaj_Sofer_SoferID",
                table: "Utilaj");

            migrationBuilder.DropTable(
                name: "Sofer");

            migrationBuilder.DropIndex(
                name: "IX_Utilaj_SoferID",
                table: "Utilaj");

            migrationBuilder.DropColumn(
                name: "SoferID",
                table: "Utilaj");

            migrationBuilder.AddColumn<string>(
                name: "Sofer",
                table: "Utilaj",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
