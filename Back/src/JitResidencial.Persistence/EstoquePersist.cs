using System;
using System.Linq;
using System.Threading.Tasks;
using JitResidencial.Domain;
using JitResidencial.Persistence.Contextos;
using JitResidencial.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace JitResidencial.Persistence
{
    public class EstoquePersist : IEstoquePersist
    {
        private readonly JitResidencialContext _context;
        public EstoquePersist(JitResidencialContext context)
        {
            _context = context;

        }
        public async Task<Estoque> GetEstoqueByIdAsync(int estoqueId)
        {
            IQueryable<Estoque> query = _context.Estoques;

            query = query.AsNoTracking().OrderBy(es => es.Id)
                    .Where(es => es.Id == estoqueId);

            return await query.FirstOrDefaultAsync();
 
        }
    }
}