using System;
using System.Collections.Generic;

namespace JitResidencial.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public string UsuarioLogin { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; } 
        public DateTime DataInclusao { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public int GrupoId { get; set; }
        public int EnderecoId { get; set; }
        public int ProdutoId { get; set; }
    }
}