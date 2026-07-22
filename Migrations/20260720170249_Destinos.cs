using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoFinanceiro.Migrations
{
    /// <inheritdoc />
    public partial class Destinos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_entradas",
                table: "entradas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_despesas",
                table: "despesas");

            migrationBuilder.RenameTable(
                name: "entradas",
                newName: "Entradas");

            migrationBuilder.RenameTable(
                name: "despesas",
                newName: "Despesas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entradas",
                table: "Entradas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Despesas",
                table: "Despesas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Guardadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Guardou = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Destino = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardadas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guardadas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entradas",
                table: "Entradas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Despesas",
                table: "Despesas");

            migrationBuilder.RenameTable(
                name: "Entradas",
                newName: "entradas");

            migrationBuilder.RenameTable(
                name: "Despesas",
                newName: "despesas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_entradas",
                table: "entradas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_despesas",
                table: "despesas",
                column: "Id");
        }
    }
}
