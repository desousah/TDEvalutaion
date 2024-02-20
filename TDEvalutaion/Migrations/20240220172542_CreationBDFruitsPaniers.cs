using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TDEvalutaion.Migrations
{
    public partial class CreationBDFruitsPaniers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fruit",
                columns: table => new
                {
                    idfruit = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomfruit = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    poidsfruit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fruit", x => x.idfruit);
                });

            migrationBuilder.CreateTable(
                name: "panier",
                columns: table => new
                {
                    idpanier = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idfruit = table.Column<int>(type: "integer", nullable: false),
                    quantitepanier = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_panier", x => x.idpanier);
                    table.ForeignKey(
                        name: "fk_pan_frt",
                        column: x => x.idfruit,
                        principalTable: "fruit",
                        principalColumn: "idfruit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_panier_idfruit",
                table: "panier",
                column: "idfruit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "panier");

            migrationBuilder.DropTable(
                name: "fruit");
        }
    }
}
