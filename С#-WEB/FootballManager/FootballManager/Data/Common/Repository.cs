using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FootballManager.Data.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext dbContext;

        public Repository(FootballManagerDbContext dbcontext)
        {
            dbContext = dbcontext;
        }

        public void Add<T>(T entity) where T : class
        {
            DbSet<T>().Add(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public void Remove<T>(T entity) where T : class
        {
            DbSet<T>().Remove(entity);
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }
    }
}
