using System.Linq.Expressions;
using Yurt.BL.Abstract;
using Yurt.DAL.Abstract;
using Yurt.DAL.Concrete;
using Yurt.Entites.Entities.Abstract;

namespace Yurt.BL.Concrete
{
    public class BaseManager<T> : IBaseManager<T> where T : BaseEntity, new()
    {
        protected IRepositoryBase<T> _repositoryBase;

        public BaseManager()
        {
            _repositoryBase = new RepositoryBase<T>();
        }
        public async Task<bool> AddAsync(T entity)
        => await _repositoryBase.AddAsync(entity);

        public bool Remove(T entity)
        => _repositoryBase.Remove(entity);

        public async Task<bool> RemoveAsync(int id)
        => await _repositoryBase.RemoveAsync(id);
        public bool Update(T entity)
        => _repositoryBase.Update(entity);
        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        => await _repositoryBase.GetAllAsync(filter);

        public async Task<T> GetByIdAsync(int id)
        => await _repositoryBase.GetByIdAsync(id);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter = null)
        => await _repositoryBase.GetSingleAsync(filter);


        public async Task<int> SaveAsync()
        => await _repositoryBase.SaveAsync();

    }
}
