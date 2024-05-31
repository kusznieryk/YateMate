using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YateMate.Repositorio.Data.Migrations
{
    /// <inheritdoc />
    public partial class SoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstaEliminado",
                table: "Embarcaciones",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EstaEliminado",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaEliminado",
                table: "Embarcaciones");

            migrationBuilder.DropColumn(
                name: "EstaEliminado",
                table: "AspNetUsers");
        }
    }
}
