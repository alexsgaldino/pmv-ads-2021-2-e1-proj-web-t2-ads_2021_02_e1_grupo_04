using System.ComponentModel.DataAnnotations;

namespace JitResidencial.Application.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório."),
        MinLength(4, ErrorMessage = "{0} deve ter no mínimo 4 carcteres"),
        MaxLength(50, ErrorMessage = "{0} dever ter no máximo 50 caracteres")]
        public string PrimeiroNome { get; set; }
        [Required,
        StringLength(50, MinimumLength = 3,
                        ErrorMessage = "Intervalo permitido de 3 a 50 caracteres.")]
        public string Sobrenome { get; set; }
        [Required, Phone]
        public string Telefone { get; set; }
        [Required]
        public string UsuarioLogin { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; } 
        public string DataInclusao { get; set; }
        public string UltimaAtualizacao { get; set; }
        public int GrupoId { get; set; }
        public int EnderecoId { get; set; }
        public int ProdutoId { get; set; }
    }
}