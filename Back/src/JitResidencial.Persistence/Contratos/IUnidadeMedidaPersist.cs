using System;
using System.Threading.Tasks;
using JitResidencial.Domain;

namespace JitResidencial.Persistence.Contratos
{
    public interface IUnidadeMedidaPersist
    {
        Task<UnidadeMedida[]> GetAllUnidadesMedidasByNomeAsync(string nome);
        Task<UnidadeMedida[]> GetAllUnidadesMedidasByUnidadeAsync(string unidade);
        Task<UnidadeMedida[]> GetAllUnidadesMedidasAsync();
        Task<UnidadeMedida> GetUnidadeMedidaByIdAsync(int UnidadeId, string CNPJ);

    }
}