using AuthSystem.Context;
using AuthSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace AuthSystem.Repositories.UsuarioRepositoryFolder
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private IUsuarioDbContext _appDbContext;

        public UsuarioRepository(IUsuarioDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Usuario> FindUsuarioByUsername(string username)
        {
            var usuario = await _appDbContext.Set<Usuario>().FirstOrDefaultAsync(x => x.Username.Equals(username));
            if (usuario is null)
                return null;
            return usuario;
        }

        public async Task<Usuario> AddUsuario(Usuario usuarioToAdd)
        {
            var usuario = await _appDbContext.Set<Usuario>().AddAsync(usuarioToAdd);
            _appDbContext.SaveChanges();
            return usuario.Entity;
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            await Task.Run(() =>
            {
                _appDbContext.Set<Usuario>().Update(usuario);
                _appDbContext.SaveChanges();
            });
        }

        public  Usuario GetUsuarioByRefreshToken(string refreshToken)
        {   var usuario = _appDbContext.Set<Usuario>().SingleOrDefault(x => x.RefreshToken.Equals(refreshToken));
            if (usuario is null)
                return null;
            return usuario;
        }

        public void UpdateUsuario(Usuario usuario)
        {
            var usuarioAtt = _appDbContext.Set<Usuario>().Update(usuario);
            _appDbContext.SaveChanges();
        }
    }
}
