using System;
using System.Threading.Tasks;
using JitResidencial.Domain;

namespace JitResidencial.Persistence.Contratos
{
    public interface IProdutoPersist
    {
        Task<Produto[]> GetAllProdutosByNomeProdutoAsync(string nomeProduto);
        Task<Produto[]> GetAllProdutosByCodigoBarraAsync(string codigoBarras);
        Task<Produto[]> GetAllProdutosAsync();
        Task<Produto> GetProdutoByIdAsync(int produtoId);

    }
}