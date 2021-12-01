using System.ComponentModel.DataAnnotations;

namespace JitResidencial.Application.Dtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        [Required]
        public string CodigoBarras { get; set; }
        [Required]
        public string NomeProduto { get; set; }
        [Required]
        public int Quantidade { get; set; } 
        [Required]
        public string Volume { get; set; }
        [Required]
        public string DataValidade { get; set; }
        [Required]
        public string DataInclusao { get; set; }
        [Required]
        public string DataAlteracao { get; set; }
        [Required]
        public int UnidadeMedidaId {get; set;}
        public int CategoriaId  {get; set;}
        public int MovimentoId { get; set; }
        public int EstoqueId { get; set; }
        public int UserId { get; set; }
        public ContaDto ContaDto { get; set; }
    }
}