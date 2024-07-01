using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YateMate.Repositorio.Data.Migrations
{
    /// <inheritdoc />
    public partial class Agregoenumtamaño : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetrosCubicos",
                table: "Amarras");

            migrationBuilder.AddColumn<string>(
                name: "Tamanio",
                table: "Amarras",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tamanio",
                table: "Amarras");

            migrationBuilder.AddColumn<double>(
                name: "MetrosCubicos",
                table: "Amarras",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
