using System;
using System.Threading.Tasks;
using JitResidencial.Domain;

namespace JitResidencial.Persistence.Contratos
{
    public interface IMovimentoPersist : IGlobalPersist
    {
        Task<Movimento[]> GetAllMovimentosAsync();
        Task<Movimento> GetMovimentoByIdAsync(int movimentoId);
    }
}