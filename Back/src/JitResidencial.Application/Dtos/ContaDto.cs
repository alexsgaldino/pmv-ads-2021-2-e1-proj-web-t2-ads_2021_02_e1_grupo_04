using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JitResidencial.Domain.Identity;

namespace JitResidencial.Application.Dtos
{
    public class ContaDto
    {
        public string UserName { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }

        public string ImagemURL { get; set; }
        public string SobreMim { get; set; }
        public int GrupoId { get; set; }
        public int EndercoId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }

}