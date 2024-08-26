using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendasLyncas.Infra.Data.Migrations
{
    public partial class RelacionandoUsuarioVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Venda_VendaId",
                table: "ItemVenda");

            migrationBuilder.AlterColumn<int>(
                name: "VendaId",
                table: "ItemVenda",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venda_UsuarioId",
                table: "Venda",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Venda_VendaId",
                table: "ItemVenda",
                column: "VendaId",
                principalTable: "Venda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Usuario_UsuarioId",
                table: "Venda",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Venda_VendaId",
                table: "ItemVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Usuario_UsuarioId",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_UsuarioId",
                table: "Venda");

            migrationBuilder.AlterColumn<int>(
                name: "VendaId",
                table: "ItemVenda",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Venda_VendaId",
                table: "ItemVenda",
                column: "VendaId",
                principalTable: "Venda",
                principalColumn: "Id");
        }
    }
}
