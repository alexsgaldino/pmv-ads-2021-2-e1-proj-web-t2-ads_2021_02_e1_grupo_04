using System;
using System.Threading.Tasks;
using JitResidencial.Domain;

namespace JitResidencial.Persistence.Contratos
{
    public interface IFornecedorPersist : IGlobalPersist
    {
        Task<Fornecedor[]> GetAllFornecedoresByNomeAsync(string nome);
        Task<Fornecedor[]> GetAllFornecedoresAsync();
        Task<Fornecedor> GetFornecedorByIdAsync(int fornecedorId);
    }
}