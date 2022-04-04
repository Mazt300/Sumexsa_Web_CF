using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Migrations
{
    public partial class cambios_foreigkey_relbancos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BancoP_BancoI",
                schema: "PV",
                table: "BancoP_BancoI");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BancoP_BancoI",
                schema: "PV",
                table: "BancoP_BancoI",
                columns: new[] { "IdBancoP", "IdBancoI", "Id_BancoP_BancoI" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BancoP_BancoI",
                schema: "PV",
                table: "BancoP_BancoI");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BancoP_BancoI",
                schema: "PV",
                table: "BancoP_BancoI",
                columns: new[] { "IdBancoP", "IdBancoI" });
        }
    }
}
