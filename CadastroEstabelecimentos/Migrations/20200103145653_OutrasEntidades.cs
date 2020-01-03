using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroEstabelecimentos.Migrations
{
    public partial class OutrasEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estabelecimento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RazaoSocial = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Agencia = table.Column<string>(nullable: true),
                    Conta = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estabelecimento_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimento_CategoriaId",
                table: "Estabelecimento",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estabelecimento");
        }
    }
}
