using Microsoft.EntityFrameworkCore;

namespace AuthSystem.Context
{
    public interface IUsuarioDbContext
    {
        public DbSet<T> Set<T>() where T : class;
        int SaveChanges();
    }
}
