using System;
using System.Collections.Generic;

namespace JitResidencial.Domain
{
    public class Produto

    {
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; } 
        public string Volume { get; set; }
        public string DataValidade { get; set; }
        public string DataInclusao { get; set; }
        public string DataAlteracao { get; set; }
        public int UnidadeMedidaId {get; set;}
        public int CategoriaId  {get; set;}
        public int MovimentoId { get; set; }
        public int EstoqueId { get; set; }
        public int ListaPrecoId { get; set; }
        public int FornecedorId { get; set; }        
    }
}
