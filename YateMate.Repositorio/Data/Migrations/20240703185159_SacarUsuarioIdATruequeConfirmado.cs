using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YateMate.Repositorio.Data.Migrations
{
    /// <inheritdoc />
    public partial class SacarUsuarioIdATruequeConfirmado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TruequesConfirmados");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "TruequesConfirmados",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
