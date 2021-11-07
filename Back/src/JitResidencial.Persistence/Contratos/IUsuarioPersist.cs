using System;
using System.Threading.Tasks;
using JitResidencial.Domain;

namespace JitResidencial.Persistence.Contratos
{
    public interface IUsuarioPersist
    {
        Task<Usuario[]> GetAllUsuariosByPrimeiroNomeAsync(string primeiroNome);
        Task<Usuario[]> GetAllUsuariosBySobrenomeAsync(string sobrenome);
        Task<Usuario[]> GetAllUsuariosByUsuarioLoginAsync(string usuarioLogin);
        Task<Usuario[]> GetAllUsuariosByEmailAsync(string email);
        Task<Usuario[]> GetAllUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(int usuarioId);
    }
}