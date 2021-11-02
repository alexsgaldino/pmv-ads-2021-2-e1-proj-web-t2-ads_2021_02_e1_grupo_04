using System.Net.Http.Headers;
using System;

namespace JitResidencial.Domain
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public DateTime? DataInclusao { get; set; }
    }
}