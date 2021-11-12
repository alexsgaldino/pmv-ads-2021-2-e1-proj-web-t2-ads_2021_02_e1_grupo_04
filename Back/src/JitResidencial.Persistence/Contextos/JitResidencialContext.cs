using System;
using JitResidencial.Domain;
using JitResidencial.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JitResidencial.Persistence.Contextos
{
    public class JitResidencialContext 
        : IdentityDbContext<User, 
                            Role, 
                            int, 
                            IdentityUserClaim<int>, 
                            UserRole, 
                            IdentityUserLogin<int>, 
                            IdentityRoleClaim<int>, 
                            IdentityUserToken<int>>
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole => 
                {
                    userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                    userRole.HasOne(ur => ur.Role)
                            .WithMany(r => r.UserRoles)
                            .HasForeignKey(ur => ur.RoleId)
                            .IsRequired();
                            
                    userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
                } 

            );
        }
    }
}