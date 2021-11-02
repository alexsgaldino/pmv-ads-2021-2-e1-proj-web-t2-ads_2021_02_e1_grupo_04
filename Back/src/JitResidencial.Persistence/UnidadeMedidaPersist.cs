using System;
using System.Linq;
using System.Threading.Tasks;
using JitResidencial.Domain;
using JitResidencial.Persistence.Contextos;
using JitResidencial.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace JitResidencial.Persistence
{
    public class UnidadeMedidaPersist : IUnidadeMedidaPersist 
    {
        private readonly JitResidencialContext _context;
        public UnidadeMedidaPersist (JitResidencialContext context)
        {
            _context = context;

        }
        public async Task<UnidadeMedida[]> GetAllUnidadesMedidasAsync()
        {
            IQueryable<UnidadeMedida> query = _context.UnidadesMedidas;

            query = query.AsNoTracking().OrderBy(un => un.Id);

            return await query.ToArrayAsync();
        }

        public async Task<UnidadeMedida[]> GetAllUnidadesMedidasByNomeAsync(string nome)
        {
            IQueryable<UnidadeMedida> query = _context.UnidadesMedidas;

            query = query.AsNoTracking().OrderBy(un => un.Nome)
                    .Where(un => un.Nome
                        .ToLower()
                        .Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<UnidadeMedida[]> GetAllUnidadesMedidasByUnidadeAsync(string unidade)
        {
            IQueryable<UnidadeMedida> query = _context.UnidadesMedidas;

            query = query.AsNoTracking().OrderBy(un => un.Unidade)
                    .Where(us => us.Unidade
                        .ToLower()
                        .Contains(unidade.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<UnidadeMedida> GetUnidadeMedidaByIdAsync(int UnidadeId, string CNPJ)
        {
            IQueryable<UnidadeMedida> query = _context.UnidadesMedidas;

            query = query.AsNoTracking().OrderBy(f => f.Id)
                    .Where(un => un.Id == UnidadeId);

            return await query.FirstOrDefaultAsync();
        }        
    }
}