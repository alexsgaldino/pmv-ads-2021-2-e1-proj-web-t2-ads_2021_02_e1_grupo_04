
using System;
using System.Threading.Tasks;
using JitResidencial.Application.Contratos;
using JitResidencial.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JitResidencial.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var usuario = await _usuarioService.GetAllUsuariosAsync();
                 if (usuario == null) return NotFound("Nenhum usuario encontrado");

                 return Ok(usuario);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar usuarios. Erro: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                 var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
                 if (usuario == null) return NotFound("Nenhum produto por id foi encontrado");

                 return Ok(usuario);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar usuarios por id. Erro: {ex.Message}");
            }
        }
        [HttpGet("{primeiroNome}/primeiroNome")]
        public async Task<ActionResult> GetByPrimeiroNome(string primeiroNome)
        {
            try
            {
                 var usuarios = await _usuarioService.GetAllUsuariosByPrimeiroNomeAsync(primeiroNome);
                 if (usuarios == null) return NotFound("Nenhum usuario por primeiro nome foi encontrado");

                 return Ok(usuarios);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar usuarios por primeiro nome. Erro: {ex.Message}");
            }
        }
        [HttpGet("{sobrenome}/sobrenome")]
        public async Task<ActionResult> GetBySobrenome(string sobrenome)
        {
            try
            {
                 var usuario = await _usuarioService.GetAllUsuariosBySobrenomeAsync(sobrenome);
                 if (usuario == null) return NotFound("Nenhum usuario por sobrenome foi encontrado");

                 return Ok(usuario);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar usuarios por sobrenome. Erro: {ex.Message}");
            }
        }
        [HttpGet("{usuarioLogin}/usuarioLogin")]
        public async Task<ActionResult> GetByUsuarioLogin(string usuarioLogin)
        {
            try
            {
                 var usuario = await _usuarioService.GetAllUsuariosByUsuarioLoginAsync(usuarioLogin);
                 if (usuario == null) return NotFound("Nenhum usuairo por usuario de login foi encontrado");

                 return Ok(usuario);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar usuarios por usuario de login. Erro: {ex.Message}");
            }
        }
        [HttpGet("{email}/email")]
        public async Task<ActionResult> GetByEmail(string email)
        {
            try
            {
                 var usuario = await _usuarioService.GetAllUsuariosByEmailAsync(email);
                 if (usuario == null) return NotFound("Nenhum usuario por email foi encontrado");

                 return Ok(usuario);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar usuarios por email. Erro: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Usuario model)
        {
            try
            {
                 var usuario = await _usuarioService.AddUsuario(model);
                 if (usuario == null) return BadRequest("Erro ao tentar adicionar usuario.");

                 return Ok(usuario);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar usuarios. Erro: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario model)
        {
            try
            {
                 var usuario = await _usuarioService.UpdateUsuario(id, model);
                 if (usuario == null) return BadRequest("Erro ao tentar atualizar usuario");

                 return Ok(usuario);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar usuario. Erro: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                 if (await _usuarioService.DeleteUsuario(id))
                     return Ok("Deletado");
                 else
                     return BadRequest("Evento não deletado");
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar usuario. Erro: {ex.Message}");
            }
        }
    }
}
