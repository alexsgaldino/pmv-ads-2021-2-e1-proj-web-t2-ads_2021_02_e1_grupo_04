using System.Threading.Tasks;
using JitResidencial.Domain;

namespace JitResidencial.Application.Contratos
{
    public interface IUsuarioService
    {

        Task<Usuario> AddUsuario(Usuario model);
        Task<Usuario> UpdateUsuario(int usuarioId, Usuario model);
        Task<bool> DeleteUsuario(int produtoId);
        
        Task<Usuario[]> GetAllUsuariosByPrimeiroNomeAsync(string primeiroNome);
        Task<Usuario[]> GetAllUsuariosBySobrenomeAsync(string sobrenome);
        Task<Usuario[]> GetAllUsuariosByUsuarioLoginAsync(string usuarioLogin);
        Task<Usuario[]> GetAllUsuariosByEmailAsync(string email);
        Task<Usuario[]> GetAllUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(int usuarioId);
    }

}