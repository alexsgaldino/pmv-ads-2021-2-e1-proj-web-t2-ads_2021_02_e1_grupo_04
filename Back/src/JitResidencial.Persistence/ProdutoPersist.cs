using System;
using System.Linq;
using System.Threading.Tasks;
using JitResidencial.Domain;
using Microsoft.EntityFrameworkCore;
using JitResidencial.Persistence.Contratos;
using JitResidencial.Persistence.Contextos;

namespace JitResidencial.Persistence
{
    public class ProdutoPersist : IProdutoPersist
    {
        private readonly JitResidencialContext _context;
        public ProdutoPersist(JitResidencialContext context)
        {
            _context = context;

        }
        public async Task<Produto[]> GetAllProdutosAsync()
        {
            IQueryable<Produto> query = _context.Produtos
                .Include(p => p.UnidadesMedidas)
                .Include(p => p.Categorias)
                .Include(p => p.Movimentos)
                .Include(p => p.Estoques)
                .Include(p => p.ListasPrecos)
                .Include(p => p.Fornecedores);

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Produto[]> GetAllProdutosByCodigoBarraAsync(string codigoBarras)
        {
            IQueryable<Produto> query = _context.Produtos
                .Include(p => p.UnidadesMedidas)
                .Include(p => p.Categorias)
                .Include(p => p.Movimentos)
                .Include(p => p.Estoques)
                .Include(p => p.ListasPrecos)
                .Include(p => p.Fornecedores);

            query = query.AsNoTracking().OrderBy(p => p.CodigoBarras)
                    .Where(p => p.CodigoBarras
                        .ToLower()
                        .Contains(codigoBarras.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Produto[]> GetAllProdutosByNomeProdutoAsync(string nomeProduto)
        {
            IQueryable<Produto> query = _context.Produtos
                .Include(p => p.UnidadesMedidas)
                .Include(p => p.Categorias)
                .Include(p => p.Movimentos)
                .Include(p => p.Estoques)
                .Include(p => p.ListasPrecos)
                .Include(p => p.Fornecedores);

            query = query.AsNoTracking().OrderBy(p => p.NomeProduto)
                    .Where(p => p.NomeProduto
                        .ToLower()
                        .Contains(nomeProduto.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Produto> GetProdutoByIdAsync(int produtoId)
        {
            IQueryable<Produto> query = _context.Produtos
                .Include(p => p.UnidadesMedidas)
                .Include(p => p.Categorias)
                .Include(p => p.Movimentos)
                .Include(p => p.Estoques)
                .Include(p => p.ListasPrecos)
                .Include(p => p.Fornecedores);

            query = query.AsNoTracking().OrderBy(p => p.Id)
                    .Where(p => p.Id == produtoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}