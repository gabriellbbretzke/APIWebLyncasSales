using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendasLyncas.Infra.Data.Migrations
{
    public partial class RemovinovamenteonomedoClientedaEntidadeVendapoisnãofuncionou : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteName",
                table: "Venda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClienteName",
                table: "Venda",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
