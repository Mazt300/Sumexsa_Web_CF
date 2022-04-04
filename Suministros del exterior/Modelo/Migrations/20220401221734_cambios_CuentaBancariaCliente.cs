using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Migrations
{
    public partial class cambios_CuentaBancariaCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BancoP_ClienteE",
                schema: "PV");

            migrationBuilder.CreateTable(
                name: "CuentaBancariaCliente",
                schema: "PV",
                columns: table => new
                {
                    IdBancoP_ClienteE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cuenta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Moneda = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Swift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdBanco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentaBancariaCliente", x => x.IdBancoP_ClienteE);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuentaBancariaCliente",
                schema: "PV");

            migrationBuilder.CreateTable(
                name: "BancoP_ClienteE",
                schema: "PV",
                columns: table => new
                {
                    IdBancoP_ClienteE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cuenta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdBanco = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    Moneda = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Swift = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BancoP_ClienteE", x => x.IdBancoP_ClienteE);
                });
        }
    }
}
