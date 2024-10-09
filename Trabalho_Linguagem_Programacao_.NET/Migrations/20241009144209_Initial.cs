using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trabalho_Linguagem_Programacao_.NET.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    celular = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    categoria = table.Column<int>(type: "int", nullable: false),
                    preco = table.Column<float>(type: "real", nullable: false),
                    qtde_estoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    produtoID = table.Column<int>(type: "int", nullable: false),
                    celular = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecedores_Produtos_produtoID",
                        column: x => x.produtoID,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clienteID = table.Column<int>(type: "int", nullable: false),
                    produtoID = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_clienteID",
                        column: x => x.clienteID,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Produtos_produtoID",
                        column: x => x.produtoID,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    produtoID = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    clienteID = table.Column<int>(type: "int", nullable: true),
                    fornecedorID = table.Column<int>(type: "int", nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Clientes_clienteID",
                        column: x => x.clienteID,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Fornecedores_fornecedorID",
                        column: x => x.fornecedorID,
                        principalTable: "Fornecedores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Produtos_produtoID",
                        column: x => x.produtoID,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_produtoID",
                table: "Fornecedores",
                column: "produtoID");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_clienteID",
                table: "Movimentacoes",
                column: "clienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_fornecedorID",
                table: "Movimentacoes",
                column: "fornecedorID");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_produtoID",
                table: "Movimentacoes",
                column: "produtoID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_clienteID",
                table: "Pedidos",
                column: "clienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_produtoID",
                table: "Pedidos",
                column: "produtoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacoes");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
