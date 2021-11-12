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
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService,
                                ITokenService   tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        [HttpGet("GetUser")]
         public async Task<IActionResult> GetUser()
        {
            try
            {
                var userName = User.GetUserName();
                var user = await _accountService.GetUserByUserNameAsync(userName);

                if (user == null) return NoContent();

                 return Ok(user);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar conta. Erro: {ex.Message}");
            }
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(UserDto userDto)
        {
            try
            {
                if (await _accountService.UserExists(userDto.UserName))
                    return BadRequest("Conta já cadastrada,");

                if (await _accountService.CreateAccountAsync(userDto) != null)
                    return Ok("Conta criada!");

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
        public async Task<ActionResult> Login(UserLoginDto userLogin)
        {
            try
            {
                var user = await _accountService.GetUserByUserNameAsync(userLogin.UserName);
                if (user == null) return Unauthorized("Conta ou senha inválido.");

                var result = await _accountService.CheckUserPasswordAsync(user, userLogin.Password);
                if (!result.Succeeded) return Unauthorized();

                return Ok( new 
                {
                    userName = user.UserName,
                    FirstName = user.FirstName,
                    token = _tokenService.CreateToken(user).Result
                });
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar ao logar na conta. Erro: {ex.Message}");
            }
        }
        [HttpPut("UpdateUser")]
        public async Task<ActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            try
            {
                var user = await _accountService.GetUserByUserNameAsync(User.GetUserName());
                if (user == null) return Unauthorized("Conta ou senha inválido.");

                var userReturn = await _accountService.UpdateAccountAsync(userUpdateDto);
                if (userReturn == null) return NoContent();

                return Ok(userReturn);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atulizar conta. Erro: {ex.Message}");
            }
        }

    }
}
