using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EPharma.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nome = table.Column<string>(type: "varchar(80)", nullable: false),
                    cpf_cnpj = table.Column<string>(type: "varchar(20)", nullable: false),
                    rg = table.Column<string>(type: "varchar(20)", nullable: true),
                    data_nascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    email = table.Column<string>(type: "varchar(50)", nullable: false),
                    tipo_cliente = table.Column<int>(type: "int", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    data_inicio_vigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_fim_vigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isPj = table.Column<bool>(type: "bit", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planos_ClienteId",
                table: "Planos",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
