using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Migrations
{
    public partial class correcion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idCliente",
                schema: "PV",
                table: "PersonaContacto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idCliente",
                schema: "PV",
                table: "PersonaContacto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
