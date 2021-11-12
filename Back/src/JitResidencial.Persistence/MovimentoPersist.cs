using System;
using System.Linq;
using System.Threading.Tasks;
using JitResidencial.Domain;
using JitResidencial.Persistence.Contextos;
using JitResidencial.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace JitResidencial.Persistence
{
    public class MovimentoPersist : GlobalPersist, IMovimentoPersist
    {
        private readonly JitResidencialContext _context;
        public MovimentoPersist(JitResidencialContext context) : base(context)
        {
            _context = context;

        }
         public async Task<Movimento[]> GetAllMovimentosAsync()
        {
            IQueryable<Movimento> query = _context.Movimentos;

            query = query.OrderBy(m => m.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Movimento> GetMovimentoByIdAsync(int movimentoId)
        {
            IQueryable<Movimento> query = _context.Movimentos;

            query = query.AsNoTracking().OrderBy(m => m.Id)
                    .Where(m => m.Id == movimentoId);

            return await query.FirstOrDefaultAsync();
        }

    }
}