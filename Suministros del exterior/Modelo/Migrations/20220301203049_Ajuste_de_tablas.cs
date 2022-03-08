using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Migrations
{
    public partial class Ajuste_de_tablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteImportadorIdclienteimportador",
                schema: "PV",
                table: "PersonaContacto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonaContacto_ClienteImportadorIdclienteimportador",
                schema: "PV",
                table: "PersonaContacto",
                column: "ClienteImportadorIdclienteimportador");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaContacto_ClienteImportador_ClienteImportadorIdclienteimportador",
                schema: "PV",
                table: "PersonaContacto",
                column: "ClienteImportadorIdclienteimportador",
                principalSchema: "PV",
                principalTable: "ClienteImportador",
                principalColumn: "Idclienteimportador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonaContacto_ClienteImportador_ClienteImportadorIdclienteimportador",
                schema: "PV",
                table: "PersonaContacto");

            migrationBuilder.DropIndex(
                name: "IX_PersonaContacto_ClienteImportadorIdclienteimportador",
                schema: "PV",
                table: "PersonaContacto");

            migrationBuilder.DropColumn(
                name: "ClienteImportadorIdclienteimportador",
                schema: "PV",
                table: "PersonaContacto");
        }
    }
}
