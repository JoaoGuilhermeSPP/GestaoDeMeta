using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoFinanceiro.Migrations
{
    /// <inheritdoc />
    public partial class idestino : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destino",
                table: "Guardadas");

            migrationBuilder.AlterColumn<decimal>(
                name: "Guardou",
                table: "Guardadas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AddColumn<int>(
                name: "DestinosId",
                table: "Guardadas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdDestino",
                table: "Guardadas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Entradas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<decimal>(
                name: "valor",
                table: "Destinos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MetaTotal",
                table: "Destinos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Despesas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.CreateIndex(
                name: "IX_Guardadas_DestinosId",
                table: "Guardadas",
                column: "DestinosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guardadas_Destinos_DestinosId",
                table: "Guardadas",
                column: "DestinosId",
                principalTable: "Destinos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guardadas_Destinos_DestinosId",
                table: "Guardadas");

            migrationBuilder.DropIndex(
                name: "IX_Guardadas_DestinosId",
                table: "Guardadas");

            migrationBuilder.DropColumn(
                name: "DestinosId",
                table: "Guardadas");

            migrationBuilder.DropColumn(
                name: "IdDestino",
                table: "Guardadas");

            migrationBuilder.AlterColumn<decimal>(
                name: "Guardou",
                table: "Guardadas",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Destino",
                table: "Guardadas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Entradas",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "valor",
                table: "Destinos",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MetaTotal",
                table: "Destinos",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Despesas",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
