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
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int UnidadeMedidaId {get; set;}
        public IEnumerable<UnidadeMedida> UnidadesMedidas { get; set; }
        public int CategoriaId  {get; set;}
        public IEnumerable<Categoria> Categorias { get; set; }
        public int MovimentoId { get; set; }
        public IEnumerable<Movimento> Movimentos { get; set; }
        public int EstoqueId { get; set; }
        public IEnumerable<Estoque> Estoques { get; set; }
        public int ListaPrecoId { get; set; }
        public IEnumerable<ListaPreco> ListasPrecos { get; set; }
        public int FornecedorId { get; set; }
        public IEnumerable<Fornecedor> Fornecedores { get; set; }         
    }
}
