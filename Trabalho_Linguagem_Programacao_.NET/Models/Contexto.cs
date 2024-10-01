using Microsoft.EntityFrameworkCore;
using Trabalho_Linguagem_Programacao_.NET.Models;

namespace Trabalho_Linguagem_Programacao_.NET.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Movimentacao> Movimentacoes { get; set; }

    }
}