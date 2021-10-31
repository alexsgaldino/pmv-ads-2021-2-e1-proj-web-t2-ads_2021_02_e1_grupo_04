using System;
using System.Collections.Generic;

namespace JIT_Residencial.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; } 
        public string Volume { get; set; }
        public string DataValidade { get; set; }
//        public DateTime? DataInclusao { get; set; }
//        public DateTime? DataAlteracao { get; set; }
//        public IEnumerable<UnidadeMedida> UnidadesMedidas { get; set; }
//        public IEnumerable<Categoria> Categorias { get; set; }
//       public IEnumerable<Movimento> Movimentos { get; set; }
//        public Estoque Estoque { get; set; }
//        public IEnumerable<ListaPreco> ListasPrecos { get; set; }
//       public IEnumerable<Fornecedor> Fornecedores { get; set; }         
    }
}
