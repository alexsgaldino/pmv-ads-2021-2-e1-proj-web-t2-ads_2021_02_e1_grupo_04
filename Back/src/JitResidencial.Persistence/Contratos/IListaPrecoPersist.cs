using System;
using System.Threading.Tasks;
using JitResidencial.Domain;

namespace JitResidencial.Persistence.Contratos
{
    public interface IListaPrecoPersist : IGlobalPersist
    {
        Task<ListaPreco> GetListaPrecoByIdAsync(int listaPrecoId, int fornecedorId);
    }
}