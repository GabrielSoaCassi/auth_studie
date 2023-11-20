using AuthSystem.Model;

namespace AuthSystem.Repositories.UsuarioRepositoryFolder
{
    public interface IUsuarioRepository
    {
        public Task<Usuario> AddUsuario(Usuario usuario);
        public Task<Usuario> FindUsuarioByUsername (string username);
        public Task UpdateUsuarioAsync (Usuario username);
        public Usuario GetUsuarioByRefreshToken(string refreshToken);
        public void UpdateUsuario(Usuario usuario);
    }
}
