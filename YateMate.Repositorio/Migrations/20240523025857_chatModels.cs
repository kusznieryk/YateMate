using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YateMate.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class chatModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ofertas_Bienes_BienId",
                table: "Ofertas");

            migrationBuilder.DropIndex(
                name: "IX_Ofertas_BienId",
                table: "Ofertas");

            migrationBuilder.AlterColumn<int>(
                name: "BienId",
                table: "Ofertas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MensajesChats",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FromUserId = table.Column<string>(type: "TEXT", nullable: false),
                    ToUserId = table.Column<string>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensajesChats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MensajesChats_AspNetUsers_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MensajesChats_AspNetUsers_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MensajesChats_FromUserId",
                table: "MensajesChats",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MensajesChats_ToUserId",
                table: "MensajesChats",
                column: "ToUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MensajesChats");

            migrationBuilder.AlterColumn<int>(
                name: "BienId",
                table: "Ofertas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_BienId",
                table: "Ofertas",
                column: "BienId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ofertas_Bienes_BienId",
                table: "Ofertas",
                column: "BienId",
                principalTable: "Bienes",
                principalColumn: "Id");
        }
    }
}
