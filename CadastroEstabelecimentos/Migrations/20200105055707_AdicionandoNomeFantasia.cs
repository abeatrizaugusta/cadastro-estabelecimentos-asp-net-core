using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroEstabelecimentos.Migrations
{
    public partial class AdicionandoNomeFantasia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeFantasia",
                table: "Estabelecimento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeFantasia",
                table: "Estabelecimento");
        }
    }
}
