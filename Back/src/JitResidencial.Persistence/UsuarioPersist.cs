using System;
using System.Linq;
using System.Threading.Tasks;
using JitResidencial.Domain;
using JitResidencial.Persistence.Contextos;
using JitResidencial.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace JitResidencial.Persistence
{
    public class UsuarioPersist : IUsuarioPersist
    {
        private readonly JitResidencialContext _context;
        public UsuarioPersist(JitResidencialContext context)
        {
            _context = context;

        }
 
        public async Task<Usuario[]> GetAllUsuariosAsync()
        {
            IQueryable<Usuario> query = _context.Usuarios;

            query = query.AsNoTracking().OrderBy(us => us.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Usuario[]> GetAllUsuariosByPrimeiroNomeAsync(string primeiroNome)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            query = query.AsNoTracking().OrderBy(us => us.PrimeiroNome)
                    .Where(us => us.PrimeiroNome
                        .ToLower()
                        .Contains(primeiroNome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Usuario[]> GetAllUsuariosBySobrenomeAsync(string sobrenome)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            query = query.AsNoTracking().OrderBy(us => us.Sobrenome)
                    .Where(us => us.Sobrenome
                        .ToLower()
                        .Contains(sobrenome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Usuario[]> GetAllUsuariosByUsuarioLoginAsync(string usuarioLogin)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            query = query.AsNoTracking().OrderBy(us => us.UsuarioLogin)
                    .Where(us => us.UsuarioLogin
                        .ToLower()
                        .Contains(usuarioLogin.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Usuario[]> GetAllUsuariosByEmailAsync(string email)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            query = query.AsNoTracking().OrderBy(us => us.Email)
                    .Where(us => us.Email
                        .ToLower()
                        .Contains(email.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Usuario> GetUsuarioByIdAsync(int usuarioId)
        {
            IQueryable<Usuario> query = _context.Usuarios;

            query = query.AsNoTracking().OrderBy(u => u.Id)
                    .Where(u => u.Id == usuarioId);

            return await query.FirstOrDefaultAsync();
        }
    }
}