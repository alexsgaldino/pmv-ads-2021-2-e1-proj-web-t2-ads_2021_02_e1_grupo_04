using Microsoft.AspNetCore.Mvc;
using JitResidencial.Application.Contratos;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using JitResidencial.Application.Dtos;

namespace JitResidencial.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _eventoService;
        public ProdutosController(IProdutoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var produtos = await _eventoService.GetAllProdutosAsync();
                 if (produtos == null) return NoContent();

                 return Ok(produtos);
            }

            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar produtos. Erro: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                 var produto = await _eventoService.GetProdutoByIdAsync(id);
                 if (produto == null) return NoContent();

                 return Ok(produto);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar produtos por id. Erro: {ex.Message}");
            }
        }
        [HttpGet("{nomeProduto}/nomeProduto")]
        public async Task<ActionResult> GetByNomeProduto(string nomeProduto)
        {
            try
            {
                 var produto = await _eventoService.GetAllProdutosByNomeProdutoAsync(nomeProduto);
                 if (produto == null) return NoContent();

                 return Ok(produto);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar produtos por nome produto. Erro: {ex.Message}");
            }
        }
        [HttpGet("{codigoBarras}/codigoBarras")]
        public async Task<ActionResult> GetByCodigoBarras(string codigoBarras)
        {
            try
            {
                 var produto = await _eventoService.GetAllProdutosByCodigoBarrasAsync(codigoBarras);
                 if (produto == null) return NoContent();

                 return Ok(produto);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar produtos por código de barras. Erro: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProdutoDto model)
        {
            try
            {
                 var produto = await _eventoService.AddProdutos(model);
                 if (produto == null) return NoContent();;

                 return Ok(produto);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar produtos por código de barras. Erro: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProdutoDto model)
        {
            try
            {
                 var produto = await _eventoService.UpdateProduto(id, model);
                 if (produto == null) return NoContent();;

                 return Ok(produto);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar produtos por código de barras. Erro: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                 if (await _eventoService.DeleteProduto(id))
                     return Ok(new {message = "Deletado"});
                 else
                     return BadRequest("Evento não deletado");
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar produtos por código de barras. Erro: {ex.Message}");
            }
        }
    }
}
