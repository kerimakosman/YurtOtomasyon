using Microsoft.EntityFrameworkCore;
using Yurt.Entites.Entities.Abstract;

namespace Yurt.DAL.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
