using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectBun.Migrations
{
    public partial class Marca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarcaID",
                table: "Utilaj",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utilaj_MarcaID",
                table: "Utilaj",
                column: "MarcaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilaj_Marca_MarcaID",
                table: "Utilaj",
                column: "MarcaID",
                principalTable: "Marca",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilaj_Marca_MarcaID",
                table: "Utilaj");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropIndex(
                name: "IX_Utilaj_MarcaID",
                table: "Utilaj");

            migrationBuilder.DropColumn(
                name: "MarcaID",
                table: "Utilaj");
        }
    }
}
