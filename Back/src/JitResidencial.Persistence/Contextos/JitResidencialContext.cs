using JitResidencial.Domain;
using Microsoft.EntityFrameworkCore;

namespace JitResidencial.Persistence.Contextos
{
    public class JitResidencialContext : DbContext
    {
        public JitResidencialContext(DbContextOptions<JitResidencialContext> options)
        : base(options) { }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<ListaPreco> ListasPrecos { get; set; }
        public DbSet<Movimento> Movimentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<UnidadeMedida> UnidadesMedidas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}