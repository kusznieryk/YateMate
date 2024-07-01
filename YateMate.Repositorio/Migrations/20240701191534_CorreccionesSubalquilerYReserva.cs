using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YateMate.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionesSubalquilerYReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAlquilante",
                table: "Subalquileres");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                table: "Reservas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicio",
                table: "Reservas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_SubalquilerId",
                table: "Reservas",
                column: "SubalquilerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Subalquileres_SubalquilerId",
                table: "Reservas",
                column: "SubalquilerId",
                principalTable: "Subalquileres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Subalquileres_SubalquilerId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_SubalquilerId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "FechaInicio",
                table: "Reservas");

            migrationBuilder.AddColumn<string>(
                name: "IdAlquilante",
                table: "Subalquileres",
                type: "TEXT",
                nullable: true);
        }
    }
}
