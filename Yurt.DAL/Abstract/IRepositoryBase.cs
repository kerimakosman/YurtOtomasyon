using System.Linq.Expressions;
using Yurt.Entites.Entities.Abstract;

namespace Yurt.DAL.Abstract
{
    public interface IRepositoryBase<T> : IRepository<T> where T : BaseEntity, new()
    {
        Task<bool> AddAsync(T entity);
        bool Remove(T entity);
        Task<bool> RemoveAsync(int id);
        bool Update(T entity);
        Task<T> GetByIdAsync(int id);
        Task<T> GetFirstAsync(Expression<Func<T, bool>> filter = null);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<int> SaveAsync();
    }
}
