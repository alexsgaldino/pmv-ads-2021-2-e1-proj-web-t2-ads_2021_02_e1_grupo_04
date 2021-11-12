using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JitResidencial.Domain;
using JitResidencial.Domain.Identity;
using JitResidencial.Persistence.Contextos;
using JitResidencial.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace JitResidencial.Persistence
{
    public class UserPersist : GlobalPersist, IUserPersist
    {
        private readonly JitResidencialContext _context;
        public UserPersist(JitResidencialContext context): base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users
                                 .FindAsync(id);
        }
        public async Task<IEnumerable<User>> GetUsersByFirstNameAsync(string firstName)
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByLastNameAsync(string lastName)
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users
                                 .SingleOrDefaultAsync(
                                     user => user.UserName == userName.ToLower());
        }
        public async Task<IEnumerable<User>> GetUsersByEmailAsync(string email)
        {
            return await _context.Users.ToListAsync();
        }

    }
}