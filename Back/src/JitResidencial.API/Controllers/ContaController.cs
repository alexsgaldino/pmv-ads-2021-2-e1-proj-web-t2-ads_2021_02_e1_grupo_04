using System.Security.Claims;
using System;
using System.Threading.Tasks;
using JitResidencial.Application;
using JitResidencial.Application.Contratos;
using JitResidencial.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JitResidencial.API.Extensions;

namespace JitResidencial.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;
        private readonly ITokenService _tokenService;

        public ContaController(IContaService contaService,
                                 ITokenService tokenService)
        {
            _contaService = contaService;
            _tokenService = tokenService;
        }

        [HttpGet("RecuperarConta/")]
         public async Task<IActionResult> RecuperarConta()
        {
            try
            {
                var conta = User.GetUserName();
                
                var contaRecuperada = await _contaService.RecuperarContasPorContaAsync(conta);

                 return Ok(contaRecuperada);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar conta. Erro: {ex.Message}");
            }
        }
        [HttpPost("RegistrarConta")]
        [AllowAnonymous]
        public async Task<ActionResult> RegistrarConta(ContaDto contaDto)
        {
            try
            {
                if (await _contaService.ContaExiste(contaDto.UserName))
                    return BadRequest("Conta já cadastrada.");

                var conta = await _contaService.CriarContaAsync(contaDto);
                Console.Write(conta);
                if (conta != null)
                    return Ok(new
                    {
                        userName = contaDto.UserName,
                        primeiroNome = contaDto.PrimeiroNome,
                        token = _tokenService.CreateToken(conta).Result
                    });

                return BadRequest("Conta não criada, tente novamente.");
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar registrar conta. Erro: {ex.Message}");
            }
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(ContaLoginDto contaLogin)
        {
            try
            {
                var user = await _contaService.RecuperarContasPorContaAsync(contaLogin.UserName);
                if (user == null) return Unauthorized("Conta ou senha inválido.");

                var result = await _contaService.VerificarSenhaContaAsync(user, contaLogin.Password);
                if (!result.Succeeded) return Unauthorized();

                return Ok( new 
                {
                    Conta = user.UserName,
                     PrimeiroNome = user.PrimeiroNome,
                    token = _tokenService.CreateToken(user).Result
                });
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar ao logar na conta. Erro: {ex.Message}");
            }
        }
        [HttpPut("AlterarConta")]
        public async Task<ActionResult> AlterarConta(AlterarContaDto alterarContaDto)
        {
            try
            {
                var conta = await _contaService.RecuperarContasPorContaAsync(User.GetUserName());
                if (conta == null) return Unauthorized("Conta ou senha inválido.");

                var contaRetorno = await _contaService.AlterarContaAsync(alterarContaDto);
                if (contaRetorno == null) return NoContent();

                return Ok(contaRetorno);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar conta. Erro: {ex.Message}");
            }
        }

    }
}
