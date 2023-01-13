using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectBun.Migrations
{
    public partial class UtilajCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UtilajCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilajID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilajCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UtilajCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UtilajCategory_Utilaj_UtilajID",
                        column: x => x.UtilajID,
                        principalTable: "Utilaj",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UtilajCategory_CategoryID",
                table: "UtilajCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_UtilajCategory_UtilajID",
                table: "UtilajCategory",
                column: "UtilajID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UtilajCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
