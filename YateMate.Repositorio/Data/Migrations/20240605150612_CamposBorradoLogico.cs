using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YateMate.Repositorio.Data.Migrations
{
    /// <inheritdoc />
    public partial class CamposBorradoLogico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acordado",
                table: "Ofertas");

            migrationBuilder.AddColumn<bool>(
                name: "EstaEliminado",
                table: "Publicaciones",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EstaEliminado",
                table: "Bienes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaEliminado",
                table: "Publicaciones");

            migrationBuilder.DropColumn(
                name: "EstaEliminado",
                table: "Bienes");

            migrationBuilder.AddColumn<bool>(
                name: "Acordado",
                table: "Ofertas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
