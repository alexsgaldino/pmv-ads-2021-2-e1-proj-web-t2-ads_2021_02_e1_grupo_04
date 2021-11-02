using System.Threading.Tasks;
using JitResidencial.Domain;

namespace JitResidencial.Application.Contratos
{
    public interface IProdutoService
    {
         Task<Produto> AddProdutos(Produto model);
        Task<Produto> UpdateProduto(int produtoId, Produto model);
        Task<bool> DeleteProduto(int produtoId);
        
        Task<Produto[]> GetAllProdutosByNomeProdutoAsync(string nomeProduto);
        Task<Produto[]> GetAllProdutosByCodigoBarrasAsync(string codigoBarras);
        Task<Produto[]> GetAllProdutosAsync();
        Task<Produto> GetProdutoByIdAsync(int produtoId);
    }
}