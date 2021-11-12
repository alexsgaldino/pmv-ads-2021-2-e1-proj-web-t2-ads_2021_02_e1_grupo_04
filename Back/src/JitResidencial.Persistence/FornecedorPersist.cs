using System;
using System.Linq;
using System.Threading.Tasks;
using JitResidencial.Domain;
using JitResidencial.Persistence.Contextos;
using JitResidencial.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace JitResidencial.Persistence
{
    public class FornecedorPersist : GlobalPersist, IFornecedorPersist
    {
        private readonly JitResidencialContext _context;
        public FornecedorPersist(JitResidencialContext context) : base(context)
        {
            _context = context;

        }
        public async Task<Fornecedor[]> GetAllFornecedoresAsync()
        {
            IQueryable<Fornecedor> query = _context.Fornecedores;

            query = query.AsNoTracking().OrderBy(f => f.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Fornecedor[]> GetAllFornecedoresByNomeAsync(string nome)
        {
            IQueryable<Fornecedor> query = _context.Fornecedores;

            query = query.AsNoTracking().OrderBy(f => f.Nome)
                    .Where(f => f.Nome
                        .ToLower()
                        .Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Fornecedor> GetFornecedorByIdAsync(int fornecedorId)
        {
            IQueryable<Fornecedor> query = _context.Fornecedores;

            query = query.AsNoTracking().OrderBy(f => f.Id)
                    .Where(f => f.Id == fornecedorId);

            return await query.FirstOrDefaultAsync();
        }


    }
}