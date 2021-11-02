using System;

namespace JitResidencial.Domain
{
    public class Movimento
    {
        public int Id { get; set; }
        public DateTime? DataMovimento { get; set; }
        public int QuantidadeEntrada { get; set; }
        public int QuantidadeSaida { get; set; }
    }
}