using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Migrations
{
    public partial class modificacion_tablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                schema: "PV",
                table: "ClienteImportador",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PersonaContactoIdPersonaContacto",
                schema: "PV",
                table: "ClienteImportador",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClienteImportador_PersonaContactoIdPersonaContacto",
                schema: "PV",
                table: "ClienteImportador",
                column: "PersonaContactoIdPersonaContacto");

            migrationBuilder.AddForeignKey(
                name: "FK_ClienteImportador_PersonaContacto_PersonaContactoIdPersonaContacto",
                schema: "PV",
                table: "ClienteImportador",
                column: "PersonaContactoIdPersonaContacto",
                principalSchema: "PV",
                principalTable: "PersonaContacto",
                principalColumn: "IdPersonaContacto",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClienteImportador_PersonaContacto_PersonaContactoIdPersonaContacto",
                schema: "PV",
                table: "ClienteImportador");

            migrationBuilder.DropIndex(
                name: "IX_ClienteImportador_PersonaContactoIdPersonaContacto",
                schema: "PV",
                table: "ClienteImportador");

            migrationBuilder.DropColumn(
                name: "PersonaContactoIdPersonaContacto",
                schema: "PV",
                table: "ClienteImportador");

            migrationBuilder.AddColumn<int>(
                name: "ClienteImportadorIdclienteimportador",
                schema: "PV",
                table: "PersonaContacto",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                schema: "PV",
                table: "ClienteImportador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
