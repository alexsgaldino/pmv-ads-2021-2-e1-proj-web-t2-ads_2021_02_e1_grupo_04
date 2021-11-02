using System;

namespace JitResidencial.Domain
{
    public class UnidadeMedida
    {
        public int Id { get; set; }
        public DateTime? DataInclusao { get; set; }
        public string Unidade { get; set; }
        public string Nome { get; set; }
    }
}