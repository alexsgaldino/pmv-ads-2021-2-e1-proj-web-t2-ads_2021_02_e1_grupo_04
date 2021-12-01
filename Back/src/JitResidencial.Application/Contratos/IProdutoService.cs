using System.Threading.Tasks;
using JitResidencial.Application.Dtos;

namespace JitResidencial.Application.Contratos
{
    public interface IProdutoService
    {
        Task<ProdutoDto> IncluirProdutos(int userId, ProdutoDto model);
        Task<ProdutoDto> AlterarProduto(int userId, int id, ProdutoDto model);
        Task<bool> ExcluirProduto(int userId, int id);
        
        Task<ProdutoDto[]>RecuperarProdutosPorNomeProdutoAsync(int userId, string nomeProduto);
        Task<ProdutoDto[]> RecuperarProdutosPorCodigoBarrasAsync(int userId, string codigoBarras);
        Task<ProdutoDto[]> RecuperarProdutosAsync(int userId);
        Task<ProdutoDto> RecuperarProdutoPorIdAsync(int userId, int id);
    }
}