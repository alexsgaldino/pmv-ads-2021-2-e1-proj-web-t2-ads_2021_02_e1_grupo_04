using JitResidencial.Domain;
using JitResidencial.Application.Dtos;
using AutoMapper;

namespace JitResidencial.Application.Helpers
{
    public class JitResidencialProfile : Profile
    {
        public JitResidencialProfile()
        {
            CreateMap<Produto, ProdutoDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}