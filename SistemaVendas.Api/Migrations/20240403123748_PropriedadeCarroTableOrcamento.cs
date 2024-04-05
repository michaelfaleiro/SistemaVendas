using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVendas.Api.Migrations
{
    /// <inheritdoc />
    public partial class PropriedadeCarroTableOrcamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Carro",
                table: "Orcamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Chassi",
                table: "Orcamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "Orcamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carro",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "Chassi",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "Orcamentos");
        }
    }
}
