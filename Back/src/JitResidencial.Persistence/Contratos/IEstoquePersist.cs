using System;
using System.Threading.Tasks;
using JitResidencial.Domain;

namespace JitResidencial.Persistence.Contratos
{
    public interface IEstoquePersist : IGlobalPersist
    {
        Task<Estoque> GetEstoqueByIdAsync(int estoqueId);

    }
}