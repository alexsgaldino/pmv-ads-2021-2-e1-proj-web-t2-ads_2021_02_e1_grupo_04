using System.ComponentModel.DataAnnotations;

namespace JitResidencial.Application.Dtos
{
    public class ContaLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }    
    }
}