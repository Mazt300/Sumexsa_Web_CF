using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Migrations
{
    public partial class Correccion_relBancos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PV");

            migrationBuilder.CreateTable(
                name: "BancoInternacional",
                schema: "PV",
                columns: table => new
                {
                    IdBancoInternacional = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BancoInternacional", x => x.IdBancoInternacional);
                });

            migrationBuilder.CreateTable(
                name: "BancoP_BancoI",
                schema: "PV",
                columns: table => new
                {
                    Id_BancoP_BancoI = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBancoP = table.Column<int>(type: "int", nullable: false),
                    IdBancoI = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BancoP_BancoI", x => x.Id_BancoP_BancoI);
                });

            migrationBuilder.CreateTable(
                name: "BancoP_ClienteE",
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
                    table.PrimaryKey("PK_BancoP_ClienteE", x => x.IdBancoP_ClienteE);
                });

            migrationBuilder.CreateTable(
                name: "BancoProveedor",
                schema: "PV",
                columns: table => new
                {
                    IdBanco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BancoProveedor", x => x.IdBanco);
                });

            migrationBuilder.CreateTable(
                name: "PersonaContacto",
                schema: "PV",
                columns: table => new
                {
                    IdPersonaContacto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaContacto", x => x.IdPersonaContacto);
                });

            migrationBuilder.CreateTable(
                name: "ClienteImportador",
                schema: "PV",
                columns: table => new
                {
                    Idclienteimportador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruc_Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonaContactoIdPersonaContacto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteImportador", x => x.Idclienteimportador);
                    table.ForeignKey(
                        name: "FK_ClienteImportador_PersonaContacto_PersonaContactoIdPersonaContacto",
                        column: x => x.PersonaContactoIdPersonaContacto,
                        principalSchema: "PV",
                        principalTable: "PersonaContacto",
                        principalColumn: "IdPersonaContacto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClienteProveedor",
                schema: "PV",
                columns: table => new
                {
                    IdClienteProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonaContactoIdPersonaContacto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteProveedor", x => x.IdClienteProveedor);
                    table.ForeignKey(
                        name: "FK_ClienteProveedor_PersonaContacto_PersonaContactoIdPersonaContacto",
                        column: x => x.PersonaContactoIdPersonaContacto,
                        principalSchema: "PV",
                        principalTable: "PersonaContacto",
                        principalColumn: "IdPersonaContacto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteImportador_PersonaContactoIdPersonaContacto",
                schema: "PV",
                table: "ClienteImportador",
                column: "PersonaContactoIdPersonaContacto");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteProveedor_PersonaContactoIdPersonaContacto",
                schema: "PV",
                table: "ClienteProveedor",
                column: "PersonaContactoIdPersonaContacto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BancoInternacional",
                schema: "PV");

            migrationBuilder.DropTable(
                name: "BancoP_BancoI",
                schema: "PV");

            migrationBuilder.DropTable(
                name: "BancoP_ClienteE",
                schema: "PV");

            migrationBuilder.DropTable(
                name: "BancoProveedor",
                schema: "PV");

            migrationBuilder.DropTable(
                name: "ClienteImportador",
                schema: "PV");

            migrationBuilder.DropTable(
                name: "ClienteProveedor",
                schema: "PV");

            migrationBuilder.DropTable(
                name: "PersonaContacto",
                schema: "PV");
        }
    }
}
