using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendasLyncas.Infra.Data.Migrations
{
    public partial class AdicionandoopçãodonomedoClientenaEntidadeVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClienteNome",
                table: "Venda",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteNome",
                table: "Venda");
        }
    }
}
