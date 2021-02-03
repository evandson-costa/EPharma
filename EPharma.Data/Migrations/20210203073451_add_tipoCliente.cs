using Microsoft.EntityFrameworkCore.Migrations;

namespace EPharma.Data.Migrations
{
    public partial class add_tipoCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tipo_cliente",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipo_cliente",
                table: "Clientes");
        }
    }
}
