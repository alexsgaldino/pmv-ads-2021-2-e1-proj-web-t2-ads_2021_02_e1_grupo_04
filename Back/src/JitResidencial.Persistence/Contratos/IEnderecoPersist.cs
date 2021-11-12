using System;
using System.Threading.Tasks;
using JitResidencial.Domain;

namespace JitResidencial.Persistence.Contratos
{
    public interface IEnderecoPersist : IGlobalPersist
    {
        Task<Endereco[]> GetAllEnderecosByRuaAsync(string rua);
        Task<Endereco[]> GetAllEnderecosByBairroAsync(string bairro);
        Task<Endereco[]> GetAllEnderecosByCidadeAsync(string cidade);
        Task<Endereco[]> GetAllEnderecosAsync();
        Task<Endereco> GetEnderecoByIdAsync(int enderecoId);
        Task<Endereco[]> GetEnderecoByCEPAsync(string CEP);
    }
}