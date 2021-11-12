using System;
using System.Linq;
using System.Threading.Tasks;
using JitResidencial.Domain;
using JitResidencial.Persistence.Contextos;
using JitResidencial.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace JitResidencial.Persistence
{
    public class CategoriaPersist : GlobalPersist, ICategoriaPersist
    {
        private readonly JitResidencialContext _context;
        public CategoriaPersist(JitResidencialContext context) : base(context)
        {
            _context = context;

        }

        public async Task<Categoria[]> GetAllCategoriasAsync()
        {
            IQueryable<Categoria> query = _context.Categorias;

            query = query.AsNoTracking().OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Categoria[]> GetAllCategoriasByNomeAsync(string nome)
        {
              IQueryable<Categoria> query = _context.Categorias;

            query = query.AsNoTracking().OrderBy(c => c.Nome)
                    .Where(c => c.Nome
                        .ToLower()
                        .Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Categoria> GetCategoriaByIdAsync(int categoriaId)
        {
            IQueryable<Categoria> query = _context.Categorias;

            query = query.AsNoTracking().OrderBy(c => c.Id)
                    .Where(c => c.Id == categoriaId);

            return await query.FirstOrDefaultAsync();
        }

    }
}