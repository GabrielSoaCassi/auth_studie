using AuthSystem.Model;
using AuthSystem.Model.Dto;

namespace AuthSystem.Services.UsuarioServiceFolder
{
    public interface IUsuarioService
    {
        public Task<Usuario> RegistrarUsuario(UsuarioDTO usuario);
        public Task<string> LogarUsuario(UsuarioDTO usuario);
    }
}
