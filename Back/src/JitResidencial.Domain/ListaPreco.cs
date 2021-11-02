using System;
using System.Collections.Generic;

namespace JitResidencial.Domain
{
    public class ListaPreco
    {
        public int Id { get; set; }
        public int PrecoUnitario { get; set; }
        public int FornecedorId { get; set; }
        public IEnumerable<Fornecedor> Fornecedores { get; set; }
    }
}