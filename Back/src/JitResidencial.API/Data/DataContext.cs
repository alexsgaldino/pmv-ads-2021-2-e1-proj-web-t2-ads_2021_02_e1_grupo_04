using JIT_Residencial.Domain;
using Microsoft.EntityFrameworkCore;

namespace JitResidencial.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        public DbSet<Produto> Produtos { get; set; }
    }
}