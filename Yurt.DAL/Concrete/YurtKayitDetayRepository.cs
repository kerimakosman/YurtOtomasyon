using Yurt.DAL.Abstract;
using Yurt.Entites.Context;
using Yurt.Entites.Entities.Concrete;

namespace Yurt.DAL.Concrete
{
    public class YurtKayitDetayRepository : RepositoryBase<YurtKayitDetay>, IYurtKayitDetayRepository
    {
        public YurtKayitDetayRepository(SqlDbContext db) : base(db)
        {
        }
    }
}
