using System.Threading.Tasks;
using JitResidencial.Application.Dtos;

namespace JitResidencial.Application.Contratos
{
    public interface IProdutoService
    {
        Task<ProdutoDto> AddProdutos(ProdutoDto model);
        Task<ProdutoDto> UpdateProduto(int produtoId, ProdutoDto model);
        Task<bool> DeleteProduto(int produtoId);
        
        Task<ProdutoDto[]> GetAllProdutosByNomeProdutoAsync(string nomeProduto);
        Task<ProdutoDto[]> GetAllProdutosByCodigoBarrasAsync(string codigoBarras);
        Task<ProdutoDto[]> GetAllProdutosAsync();
        Task<ProdutoDto> GetProdutoByIdAsync(int produtoId);
    }
}