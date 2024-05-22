using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YateMate.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class Ofertas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BienId = table.Column<int>(type: "INTEGER", nullable: true),
                    PublicacionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ofertas_Bienes_BienId",
                        column: x => x.BienId,
                        principalTable: "Bienes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ofertas_Publicaciones_PublicacionId",
                        column: x => x.PublicacionId,
                        principalTable: "Publicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_BienId",
                table: "Ofertas",
                column: "BienId");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_PublicacionId",
                table: "Ofertas",
                column: "PublicacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ofertas");
        }
    }
}
