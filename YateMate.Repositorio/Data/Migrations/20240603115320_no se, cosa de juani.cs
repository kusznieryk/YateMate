using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YateMate.Repositorio.Data.Migrations
{
    /// <inheritdoc />
    public partial class nosecosadejuani : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aceptada",
                table: "Ofertas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aceptada",
                table: "Ofertas");
        }
    }
}
