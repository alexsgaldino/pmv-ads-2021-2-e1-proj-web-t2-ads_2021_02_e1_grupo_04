using System;
using System.Threading.Tasks;
using JitResidencial.Domain;

namespace JitResidencial.Persistence.Contratos
{
    public interface IGrupoPersist : IGlobalPersist
    {
        Task<Grupo[]> GetAllGruposByNomeGrupoAsync(string nomeGrupo);
        Task<Grupo[]> GetAllGruposAsync();
        Task<Grupo> GetGrupoByIdAsync(int grupoId);
    }
}