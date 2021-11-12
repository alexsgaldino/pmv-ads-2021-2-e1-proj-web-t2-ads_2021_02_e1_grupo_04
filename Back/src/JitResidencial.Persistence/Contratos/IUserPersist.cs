using System.Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JitResidencial.Domain;
using JitResidencial.Domain.Identity;

namespace JitResidencial.Persistence.Contratos
{
    public interface IUserPersist : IGlobalPersist
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);     
        Task<IEnumerable<User>> GetUsersByFirstNameAsync(string firstName);
        Task<IEnumerable<User>> GetUsersByLastNameAsync(string lastName);
        Task<User> GetUserByUserNameAsync(string userName);
        Task<IEnumerable<User>> GetUsersByEmailAsync(string email);
    }
}