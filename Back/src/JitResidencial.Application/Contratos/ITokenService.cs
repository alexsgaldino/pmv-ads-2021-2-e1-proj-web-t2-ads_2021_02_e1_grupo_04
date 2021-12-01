using System.Threading.Tasks;
using JitResidencial.Application.Dtos;

namespace JitResidencial.Application.Contratos
{
    public interface ITokenService
    {
        Task<string> CreateToken(AlterarContaDto alterarContaDto);
    }
}