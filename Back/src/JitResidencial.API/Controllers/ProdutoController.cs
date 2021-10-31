using System.Diagnostics.Tracing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JIT_Residencial.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JitResidencial.API.Data;

namespace JitResidencial.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly DataContext _context;
        public ProdutoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return _context.Produtos;
        }
        [HttpGet("{id}")]
        public Produto GetById(int id)
        {
            return _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        }
        [HttpPost("{id}")]
        public string Post()
        {
            return "Exemplo de Post";
        }
        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete com id = {id}";
        }
    }
}
