using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JitResidencial.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CEP = table.Column<string>(type: "TEXT", nullable: true),
                    Rua = table.Column<string>(type: "TEXT", nullable: true),
                    Numero = table.Column<string>(type: "TEXT", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Bairro = table.Column<string>(type: "TEXT", nullable: true),
                    Cidade = table.Column<string>(type: "TEXT", nullable: true),
                    UF = table.Column<string>(type: "TEXT", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodigoBarras = table.Column<string>(type: "TEXT", nullable: true),
                    NomeProduto = table.Column<string>(type: "TEXT", nullable: true),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    Volume = table.Column<string>(type: "TEXT", nullable: true),
                    DataValidade = table.Column<string>(type: "TEXT", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UnidadeMedidaId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    MovimentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    EstoqueId = table.Column<int>(type: "INTEGER", nullable: false),
                    ListaPrecoId = table.Column<int>(type: "INTEGER", nullable: false),
                    FornecedorId = table.Column<int>(type: "INTEGER", nullable: false),
                    EnderecoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estoques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataMovimento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EstoqueDisponivel = table.Column<int>(type: "INTEGER", nullable: false),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estoques_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListasPrecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrecoUnitario = table.Column<int>(type: "INTEGER", nullable: false),
                    FornecedorId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListasPrecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListasPrecos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataMovimento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    QuantidadeEntrada = table.Column<int>(type: "INTEGER", nullable: false),
                    QuantidadeSaida = table.Column<int>(type: "INTEGER", nullable: false),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesMedidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataInclusao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Unidade = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesMedidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnidadesMedidas_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrimeiroNome = table.Column<string>(type: "TEXT", nullable: true),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Senha = table.Column<string>(type: "TEXT", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GrupoId = table.Column<int>(type: "INTEGER", nullable: false),
                    EnderecoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CNPJ = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    NomeFantasia = table.Column<string>(type: "TEXT", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ListaPrecoId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecedores_ListasPrecos_ListaPrecoId",
                        column: x => x.ListaPrecoId,
                        principalTable: "ListasPrecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fornecedores_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeGrupo = table.Column<string>(type: "TEXT", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grupos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_ProdutoId",
                table: "Categorias",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_ProdutoId",
                table: "Estoques",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_ListaPrecoId",
                table: "Fornecedores",
                column: "ListaPrecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_ProdutoId",
                table: "Fornecedores",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_UsuarioId",
                table: "Grupos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ListasPrecos_ProdutoId",
                table: "ListasPrecos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentos_ProdutoId",
                table: "Movimentos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_EnderecoId",
                table: "Produtos",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesMedidas_ProdutoId",
                table: "UnidadesMedidas",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EnderecoId",
                table: "Usuarios",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ProdutoId",
                table: "Usuarios",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Estoques");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Movimentos");

            migrationBuilder.DropTable(
                name: "UnidadesMedidas");

            migrationBuilder.DropTable(
                name: "ListasPrecos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
