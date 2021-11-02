using System;

namespace JitResidencial.Domain
{
    public class Estoque
    {
        public int Id { get; set; }
        public DateTime DataMovimento { get; set; }
        public int EstoqueDisponivel { get; set; }
    }
}