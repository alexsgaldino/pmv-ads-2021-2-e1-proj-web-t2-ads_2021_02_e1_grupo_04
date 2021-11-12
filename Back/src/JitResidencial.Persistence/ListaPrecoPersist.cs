using System;
using System.Linq;
using System.Threading.Tasks;
using JitResidencial.Domain;
using JitResidencial.Persistence.Contextos;
using JitResidencial.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace JitResidencial.Persistence
{
    public class ListaPrecoPersist : GlobalPersist, IListaPrecoPersist
    {
        private readonly JitResidencialContext _context;
        public ListaPrecoPersist(JitResidencialContext context) : base(context)
        {
            _context = context;

        }
        public async Task<ListaPreco> GetListaPrecoByIdAsync(int listaPrecoId, int fornecedorId)
        {
            IQueryable<ListaPreco> query = _context.ListasPrecos;

            query = query.AsNoTracking().OrderBy(lp => lp.Id)
                    .Where(lp => lp.Id == listaPrecoId || lp.FornecedorId == fornecedorId);

            return await query.FirstOrDefaultAsync();
        }
    }
}