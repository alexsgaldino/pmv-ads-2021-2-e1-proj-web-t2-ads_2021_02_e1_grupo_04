using System.Threading.Tasks;
using JitResidencial.Application.Dtos;
using Microsoft.AspNetCore.Identity;

namespace JitResidencial.Application.Contratos
{
    public interface IContaService
    {
        Task<bool> ContaExiste(string conta);
        Task<AlterarContaDto> RecuperarContasPorContaAsync(string conta);
        Task<SignInResult> VerificarSenhaContaAsync(AlterarContaDto AlterarContaDto, string senha);
        Task<AlterarContaDto> CriarContaAsync(ContaDto contaDto);
        Task<AlterarContaDto> AlterarContaAsync(AlterarContaDto AlterarContaDto);
    }

}