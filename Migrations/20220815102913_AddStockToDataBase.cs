using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Migrations
{
    public partial class AddStockToDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocklist",
                columns: table => new
                {
                    MSPEREF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    position = table.Column<int>(type: "int", nullable: false),
                    Classe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Constructeur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fournisseur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    REFEXTERNE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UNITE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRICE = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocklist", x => x.MSPEREF);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocklist");
        }
    }
}
