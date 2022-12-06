using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using Yurt.DAL.Abstract;
using Yurt.Entites.Context;
using Yurt.Entites.Entities.Abstract;

namespace Yurt.DAL.Concrete
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity, new()
    {
        protected SqlDbContext db;
        public RepositoryBase()
        {
            db = new SqlDbContext();
        }
        public DbSet<T> Table => db.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            T model = await Table.FirstOrDefaultAsync(p => p.Id == id);
            return Remove(model);
        }
        public bool Update(T entity)
        {
            EntityEntry entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
         => await (filter != null ? Table.ToListAsync() : Table.Where(filter).ToListAsync());

        public async Task<T> GetByIdAsync(int id)
            => await Table.FindAsync(id);


        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter = null)
        => await Table.Where(filter).FirstOrDefaultAsync();


        public async Task<int> SaveAsync()
        => await db.SaveChangesAsync();

    }
}
