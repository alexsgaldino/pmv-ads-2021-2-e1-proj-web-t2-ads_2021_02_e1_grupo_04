using System.Diagnostics.Tracing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JIT_Residencial.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JitResidencial.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        public IEnumerable<Produto> _produto = new Produto[] 
        {
            new Produto()
            {
                Id = 1,
                CodigoBarras = "1234567",
                NomeProduto = "Açucar Cristal",
                Quantidade = 10,
                Volume = "5 KG",
                DataValidade = DateTime.Now.AddDays(0).ToString()
            },
            new Produto()
            {
                Id = 2,
                CodigoBarras = "2345678",
                NomeProduto = "Arroz Prato Fino",
                Quantidade = 20,
                Volume = "5 KG",
                DataValidade = DateTime.Now.AddDays(0).ToString()
            },
            new Produto()
            {
                Id = 3,
                CodigoBarras = "3456789",
                NomeProduto = "Feijão Carioquinha",
                Quantidade = 10,
                Volume = "1 KG",
                DataValidade = DateTime.Now.AddDays(0).ToString()
            }
        };
        public ProdutoController()
        {
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return _produto;
        }
        [HttpGet("{id}")]
        public IEnumerable<Produto> GetById(int id)
        {
            return _produto.Where(produto => produto.Id == id);
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
