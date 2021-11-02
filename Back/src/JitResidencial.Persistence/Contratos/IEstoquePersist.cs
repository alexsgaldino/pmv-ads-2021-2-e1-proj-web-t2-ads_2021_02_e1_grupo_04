using System;
using System.Threading.Tasks;
using JitResidencial.Domain;

namespace JitResidencial.Persistence.Contratos
{
    public interface IEstoquePersist
    {
        Task<Estoque> GetEstoqueByIdAsync(int estoqueId);

    }
}