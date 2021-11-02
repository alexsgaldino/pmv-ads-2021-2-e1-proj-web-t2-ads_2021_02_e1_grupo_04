using System;
using System.Linq;
using System.Threading.Tasks;
using JitResidencial.Domain;
using JitResidencial.Persistence.Contextos;
using JitResidencial.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace JitResidencial.Persistence
{
    public class EnderecoPersist : IEnderecoPersist
    {
        private readonly JitResidencialContext _context;
        public EnderecoPersist(JitResidencialContext context)
        {
            _context = context;

        }
        public async Task<Endereco[]> GetAllEnderecosAsync()
        {
            IQueryable<Endereco> query = _context.Enderecos
                .Include(en => en.Produtos);

            query = query.AsNoTracking().OrderBy(en => en.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Endereco[]> GetAllEnderecosByBairroAsync(string bairro)
        {
            IQueryable<Endereco> query = _context.Enderecos
                .Include(en => en.Produtos);

            query = query.AsNoTracking().OrderBy(en => en.Bairro)
                    .Where(en => en.Bairro
                        .ToLower()
                        .Contains(bairro.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Endereco[]> GetAllEnderecosByCidadeAsync(string cidade)
        {
            IQueryable<Endereco> query = _context.Enderecos
                .Include(en => en.Produtos);

            query = query.AsNoTracking().OrderBy(en => en.Cidade)
                    .Where(en => en.Cidade
                        .ToLower()
                        .Contains(cidade.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Endereco[]> GetAllEnderecosByRuaAsync(string rua)
        {
            IQueryable<Endereco> query = _context.Enderecos
                .Include(en => en.Produtos);

            query = query.AsNoTracking().OrderBy(en => en.Rua)
                    .Where(en => en.Rua
                        .ToLower()
                        .Contains(rua.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Endereco> GetEnderecoByIdAsync(int enderecoId)
        {
            IQueryable<Endereco> query = _context.Enderecos
                .Include(en => en.Produtos);

            query = query.AsNoTracking().OrderBy(en => en.Id)
                    .Where(en => en.Id == enderecoId);

            return await query.FirstOrDefaultAsync();
        }  
        public async Task<Endereco[]> GetEnderecoByCEPAsync(string CEP)
        {
            IQueryable<Endereco> query = _context.Enderecos
                .Include(en => en.Produtos);

            query = query.AsNoTracking().OrderBy(en => en.CEP)
                    .Where(en => en.CEP
                        .ToLower()
                        .Contains(CEP.ToLower()));

            return await query.ToArrayAsync();
        }

    }
}