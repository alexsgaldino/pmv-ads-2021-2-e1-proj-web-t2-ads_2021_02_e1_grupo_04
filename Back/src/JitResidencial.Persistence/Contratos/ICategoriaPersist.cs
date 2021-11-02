using System;
using System.Threading.Tasks;
using JitResidencial.Domain;

namespace JitResidencial.Persistence.Contratos
{
    public interface ICategoriaPersist
    {
        Task<Categoria[]> GetAllCategoriasByNomeAsync(string nome);
        Task<Categoria[]> GetAllCategoriasAsync();
        Task<Categoria> GetCategoriaByIdAsync(int categoriaId);
    }
}