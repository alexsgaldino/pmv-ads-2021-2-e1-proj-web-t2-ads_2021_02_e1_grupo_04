

using System;
using System.Threading.Tasks;
using JitResidencial.Application.Contratos;
using JitResidencial.Domain;
using JitResidencial.Persistence.Contratos;

namespace JitResidencial.Application
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IUsuarioPersist _usuarioPersist;

        public UsuarioService(IGeralPersist geralPersist, IUsuarioPersist usuarioPersist)
        {
            _usuarioPersist = usuarioPersist;
            _geralPersist = geralPersist;
        }
        public async Task<Usuario> AddUsuario(Usuario model)
        {
            try
            {
                 _geralPersist.Add<Usuario>(model);
                 if (await _geralPersist.SaveChangesAsync())
                 {
                     return await _usuarioPersist.GetUsuarioByIdAsync(model.Id);
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
        public async Task<Usuario> UpdateUsuario(int usuarioId, Usuario model)
        {
            try
            {
                var usuario = await _usuarioPersist.GetUsuarioByIdAsync(usuarioId);
                if (usuario == null)
                {
                    return null;
                }
                model.Id = usuario.Id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _usuarioPersist.GetUsuarioByIdAsync(model.Id);
                }
                return null;                

     
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }



        public async Task<Usuario[]> GetAllUsuariosAsync()
        {
            try
            {
                 var usuarios = await _usuarioPersist.GetAllUsuariosAsync();
                 if (usuarios == null) return null;

                 return usuarios;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario[]> GetAllUsuariosByPrimeiroNomeAsync(string primeiroNome)
        {
            try
            {
                 var usuarios = await _usuarioPersist.GetAllUsuariosByPrimeiroNomeAsync(primeiroNome);
                 if (usuarios == null) return null;

                 return usuarios;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario[]> GetAllUsuariosBySobrenomeAsync(string sobrenome)
        {
            try
            {
                 var usuarios = await _usuarioPersist.GetAllUsuariosBySobrenomeAsync(sobrenome);
                 if (usuarios == null) return null;

                 return usuarios;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<Usuario[]> GetAllUsuariosByUsuarioLoginAsync(string usuarioLogin)
        {
            try
            {
                 var usuarios = await _usuarioPersist.GetAllUsuariosByUsuarioLoginAsync(usuarioLogin);
                 if (usuarios == null) return null;

                 return usuarios;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
                public async Task<Usuario[]> GetAllUsuariosByEmailAsync(string email)
        {
            try
            {
                 var usuarios = await _usuarioPersist.GetAllUsuariosByEmailAsync(email);
                 if (usuarios == null) return null;

                 return usuarios;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<Usuario> GetUsuarioByIdAsync(int usuarioId)
        {
            try
            {
                var usuario = await _usuarioPersist.GetUsuarioByIdAsync(usuarioId);
                if (usuario == null) return null;

                return usuario;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }


    }
}