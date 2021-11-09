using System.Threading.Tasks;
using JitResidencial.Application.Dtos;

namespace JitResidencial.Application.Contratos
{
    public interface IUsuarioService
    {

        Task<UsuarioDto> AddUsuario(UsuarioDto model);
        Task<UsuarioDto> UpdateUsuario(int usuarioId, UsuarioDto model);
        Task<bool> DeleteUsuario(int produtoId);
        
        Task<UsuarioDto[]> GetAllUsuariosByPrimeiroNomeAsync(string primeiroNome);
        Task<UsuarioDto[]> GetAllUsuariosBySobrenomeAsync(string sobrenome);
        Task<UsuarioDto[]> GetAllUsuariosByUsuarioLoginAsync(string usuarioLogin);
        Task<UsuarioDto[]> GetAllUsuariosByEmailAsync(string email);
        Task<UsuarioDto[]> GetAllUsuariosAsync();
        Task<UsuarioDto> GetUsuarioByIdAsync(int usuarioId);
    }

}