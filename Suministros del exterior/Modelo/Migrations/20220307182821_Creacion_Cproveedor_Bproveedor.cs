using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Migrations
{
    public partial class Creacion_Cproveedor_Bproveedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BancoProveedor",
                schema: "PV",
                columns: table => new
                {
                    IdBanco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoBanco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cuenta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Modena = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Swift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BancoProveedor", x => x.IdBanco);
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
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BancoIdBanco = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BancoInternacional", x => x.IdBancoInternacional);
                    table.ForeignKey(
                        name: "FK_BancoInternacional_BancoProveedor_BancoIdBanco",
                        column: x => x.BancoIdBanco,
                        principalSchema: "PV",
                        principalTable: "BancoProveedor",
                        principalColumn: "IdBanco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BancoInternacional_BancoIdBanco",
                schema: "PV",
                table: "BancoInternacional",
                column: "BancoIdBanco");

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
                name: "ClienteProveedor",
                schema: "PV");

            migrationBuilder.DropTable(
                name: "BancoProveedor",
                schema: "PV");
        }
    }
}
