using JitResidencial.Domain;
using JitResidencial.Application.Dtos;
using AutoMapper;
using JitResidencial.Domain.Identity;

namespace JitResidencial.Application.Helpers
{
    public class JitResidencialProfile : Profile
    {
        public JitResidencialProfile()
        {
            CreateMap<Produto, ProdutoDto>().ReverseMap();
            
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}