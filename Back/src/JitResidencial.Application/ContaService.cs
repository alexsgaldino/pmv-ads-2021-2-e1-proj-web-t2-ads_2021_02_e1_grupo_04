using System;
using System.Threading.Tasks;

using AutoMapper;

using JitResidencial.Application.Contratos;
using JitResidencial.Application.Dtos;
using JitResidencial.Domain.Identity;
using JitResidencial.Persistence.Contratos;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JitResidencial.Application
{
    public class ContaService : IContaService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IContaPersist _contaPersist;

        public ContaService(UserManager<User> userManager,
                               SignInManager<User> signInManager,
                               IMapper mapper,
                               IContaPersist contaPersist)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _contaPersist = contaPersist;
        }

        public async Task<SignInResult> VerificarSenhaContaAsync(AlterarContaDto alterarContaDto, string senha)
        {
            try
            {
                var conta = await _userManager.Users
                           .SingleOrDefaultAsync(u => u.UserName == alterarContaDto.UserName.ToLower());
                return await _signInManager.CheckPasswordSignInAsync(conta, senha, false);
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar a senha. Erro: {ex.Message}");
            };
        }

        public async Task<AlterarContaDto> CriarContaAsync(ContaDto contaDto)
        {
            try
            {
                var conta = _mapper.Map<User>(contaDto);
                var resultado = await _userManager.CreateAsync(conta, contaDto.Password);

                if (resultado.Succeeded)
                {
                    var retornarConta = _mapper.Map<AlterarContaDto>(conta);
                    return retornarConta;
                }
                return null;
            }
            catch (System.Exception ex)
            {

                throw new Exception($"Erro ao tentar criar conta Erro: {ex.Message}");
            };
        }
 
        public async Task<AlterarContaDto> RecuperarContasPorContaAsync(string conta)
        {
            try
            {
                var contaRecuperada = await _contaPersist.RecuperarContaPorContaAsync(conta);
                if (contaRecuperada == null) return null;
                Console.Write(conta);
                var contaAlteracaoDto = _mapper.Map<AlterarContaDto>(contaRecuperada);

                return contaAlteracaoDto;
            }
            catch (System.Exception ex)
            {

                throw new Exception($"Erro ao tentar recuperar a conta. Erro: {ex.Message}");
            };
        }
        public async Task<AlterarContaDto> AlterarContaAsync(AlterarContaDto alterarContaDto)
        {
            try
            {
                var contaRecuperada = await _contaPersist.RecuperarContaPorContaAsync(alterarContaDto.UserName);
                if (contaRecuperada == null) return null;

                _mapper.Map(alterarContaDto, contaRecuperada);

                var token = await _userManager.GeneratePasswordResetTokenAsync(contaRecuperada);
                var result = await _userManager.ResetPasswordAsync(contaRecuperada, token, alterarContaDto.Password);

                _contaPersist.Alterar<User>(contaRecuperada);

                if (await _contaPersist.SalvarAlteracoesAsync())
                {
                    var contaRetorno = await _contaPersist.RecuperarContaPorContaAsync(contaRecuperada.UserName);

                    return _mapper.Map<AlterarContaDto>(contaRetorno);
                }

                return null;

            }
            catch (System.Exception ex)
            {

                throw new Exception($"Erro ao tentar atualizar a conta. Erro: {ex.Message}");
            };
        }

        public async Task<bool> ContaExiste(string conta)
        {
            try
            {
                return await _userManager.Users.AnyAsync(user => user.UserName == conta.ToLower());
            }
            catch (System.Exception ex)
            {

                throw new Exception($"Erro ao tentar verificar se a conta existe. Erro: {ex.Message}");
            };
        }
    }
}