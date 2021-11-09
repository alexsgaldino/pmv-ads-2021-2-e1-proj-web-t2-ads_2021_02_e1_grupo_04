

using System;
using System.Threading.Tasks;
using AutoMapper;
using JitResidencial.Application.Contratos;
using JitResidencial.Application.Dtos;
using JitResidencial.Domain;
using JitResidencial.Persistence.Contratos;

namespace JitResidencial.Application
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IUsuarioPersist _usuarioPersist;

        private readonly IMapper _mapper;

        public UsuarioService(  IGeralPersist geralPersist, 
                                IUsuarioPersist usuarioPersist,
                                IMapper mapper)
        {
            _geralPersist = geralPersist;
            _usuarioPersist = usuarioPersist;
            _mapper = mapper;
        }
        public async Task<UsuarioDto> AddUsuario( UsuarioDto model)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(model);
                 _geralPersist.Add<Usuario>(usuario);

                 if (await _geralPersist.SaveChangesAsync())
                 {
                    var usuarioRetorno = await _usuarioPersist.GetUsuarioByIdAsync(usuario.Id);     
                     return _mapper.Map<UsuarioDto>(usuarioRetorno); 
                 }
                 return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteUsuario(int usuarioId)
        {
            try
            {
                var usuario = await _usuarioPersist.GetUsuarioByIdAsync(usuarioId);
                if (usuario == null)
                {
                    throw new Exception("Usuario para deleção não foi encontrado");
                }

                _geralPersist.Delete<Usuario>(usuario);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<UsuarioDto> UpdateUsuario(int usuarioId,  UsuarioDto model)
        {
            try
            {
                var usuario = await _usuarioPersist.GetUsuarioByIdAsync(usuarioId);
                if (usuario == null)
                {
                    return null;
                }
                model.Id = usuario.Id;

                _mapper.Map(model, usuario);

                _geralPersist.Update<Usuario>(usuario);
                
                if (await _geralPersist.SaveChangesAsync())
                {
                    var usuarioRetorno = await _usuarioPersist.GetUsuarioByIdAsync(usuario.Id);
                    
                    return _mapper.Map<UsuarioDto>(usuarioRetorno);
                }
                return null;                

     
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }



        public async Task<UsuarioDto[]> GetAllUsuariosAsync()
        {
            try
            {
                 var usuarios = await _usuarioPersist.GetAllUsuariosAsync();
                 if (usuarios == null) return null;

                  var usuariosRetorno = _mapper.Map<UsuarioDto[]>(usuarios);

                return usuariosRetorno;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioDto[]> GetAllUsuariosByPrimeiroNomeAsync(string primeiroNome)
        {
            try
            {
                 var usuarios = await _usuarioPersist.GetAllUsuariosByPrimeiroNomeAsync(primeiroNome);
                 if (usuarios == null) return null;

                 var usuariosRetorno = _mapper.Map<UsuarioDto[]>(usuarios);

                return usuariosRetorno;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioDto[]> GetAllUsuariosBySobrenomeAsync(string sobrenome)
        {
            try
            {
                 var usuarios = await _usuarioPersist.GetAllUsuariosBySobrenomeAsync(sobrenome);
                 if (usuarios == null) return null;

                  var usuariosRetorno = _mapper.Map<UsuarioDto[]>(usuarios);

                return usuariosRetorno;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<UsuarioDto[]> GetAllUsuariosByUsuarioLoginAsync(string usuarioLogin)
        {
            try
            {
                 var usuarios = await _usuarioPersist.GetAllUsuariosByUsuarioLoginAsync(usuarioLogin);
                 if (usuarios == null) return null;

                 var usuariosRetorno = _mapper.Map<UsuarioDto[]>(usuarios);

                return usuariosRetorno;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
                public async Task<UsuarioDto[]> GetAllUsuariosByEmailAsync(string email)
        {
            try
            {
                 var usuarios = await _usuarioPersist.GetAllUsuariosByEmailAsync(email);
                 if (usuarios == null) return null;

                 var usuariosRetorno = _mapper.Map<UsuarioDto[]>(usuarios);

                return usuariosRetorno;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<UsuarioDto> GetUsuarioByIdAsync(int usuarioId)
        {
            try
            {
                var usuario = await _usuarioPersist.GetUsuarioByIdAsync(usuarioId);
                if (usuario == null) return null;

                var usuarioRetorno = _mapper.Map<UsuarioDto>(usuario);

                return usuarioRetorno;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }


    }
}