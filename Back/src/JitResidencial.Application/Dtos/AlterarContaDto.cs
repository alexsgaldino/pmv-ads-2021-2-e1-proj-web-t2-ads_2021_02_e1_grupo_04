using System.ComponentModel.DataAnnotations;

namespace JitResidencial.Application.Dtos
{
    public class AlterarContaDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }    
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string ImagemURL { get; set; }
        public string Token { get; set; }
        public string SobreMim { get; set; }
        public int EndercoId { get; set; }
    }
}