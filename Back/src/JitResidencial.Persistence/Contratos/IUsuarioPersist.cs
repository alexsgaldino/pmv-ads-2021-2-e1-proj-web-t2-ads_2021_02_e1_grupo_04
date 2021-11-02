using System;
using System.Threading.Tasks;
using JitResidencial.Domain;

namespace JitResidencial.Persistence.Contratos
{
    public interface IUsuarioPersist
    {
        Task<Usuario[]> GetAllUsuariosByNomeAsync(string nome);
        Task<Usuario[]> GetAllUsuariosBySobrenomeAsync(string sobrenome);
        Task<Usuario[]> GetAllUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(int usuarioId);
    }
}