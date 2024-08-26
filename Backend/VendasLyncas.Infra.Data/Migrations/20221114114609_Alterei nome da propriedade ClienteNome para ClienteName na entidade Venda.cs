using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendasLyncas.Infra.Data.Migrations
{
    public partial class AltereinomedapropriedadeClienteNomeparaClienteNamenaentidadeVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClienteNome",
                table: "Venda",
                newName: "ClienteName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClienteName",
                table: "Venda",
                newName: "ClienteNome");
        }
    }
}
