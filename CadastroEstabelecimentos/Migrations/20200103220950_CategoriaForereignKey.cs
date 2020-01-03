using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroEstabelecimentos.Migrations
{
    public partial class CategoriaForereignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estabelecimento_Categoria_CategoriaId",
                table: "Estabelecimento");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Estabelecimento",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Estabelecimento_Categoria_CategoriaId",
                table: "Estabelecimento",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estabelecimento_Categoria_CategoriaId",
                table: "Estabelecimento");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Estabelecimento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Estabelecimento_Categoria_CategoriaId",
                table: "Estabelecimento",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
