using System;
using System.Collections.Generic;

namespace JitResidencial.Domain
{
    public class Endereco
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public DateTime? DataInclusao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public int ProdutoId { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}