using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YateMate.Migrations
{
    /// <inheritdoc />
    public partial class masdatosregistro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 9,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genero",
                table: "AspNetUsers");
        }
    }
}
