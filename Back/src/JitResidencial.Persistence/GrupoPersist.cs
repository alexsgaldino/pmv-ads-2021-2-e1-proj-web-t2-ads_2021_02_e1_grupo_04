using System;
using System.Linq;
using System.Threading.Tasks;
using JitResidencial.Domain;
using JitResidencial.Persistence.Contextos;
using JitResidencial.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace JitResidencial.Persistence
{
    public class GrupoPersist : GlobalPersist, IGrupoPersist
    {
        private readonly JitResidencialContext _context;
        public GrupoPersist(JitResidencialContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Grupo[]> GetAllGruposAsync()
        {
            IQueryable<Grupo> query = _context.Grupos;

            query = query.AsNoTracking().OrderBy(g => g.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Grupo[]> GetAllGruposByNomeGrupoAsync(string nomeGrupo)
        {
            IQueryable<Grupo> query = _context.Grupos;

            query = query.AsNoTracking().OrderBy(g => g.NomeGrupo)
                    .Where(g => g.NomeGrupo
                        .ToLower()
                        .Contains(nomeGrupo.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Grupo> GetGrupoByIdAsync(int grupoId)
        {
            IQueryable<Grupo> query = _context.Grupos;

            query = query.AsNoTracking().OrderBy(g => g.Id)
                    .Where(g => g.Id == grupoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}