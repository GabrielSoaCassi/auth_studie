using AuthSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace AuthSystem.Context
{
    public class UsuarioDbContext:DbContext,IUsuarioDbContext
    {
        DbSet<Usuario> Usuarios { get; set; }
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options): base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
        }
    }
}
